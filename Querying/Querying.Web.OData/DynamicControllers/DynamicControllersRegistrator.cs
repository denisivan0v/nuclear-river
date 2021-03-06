﻿using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Web.Http;
using System.Web.OData;

using NuClear.AdvancedSearch.Common.Metadata.Elements;
using NuClear.AdvancedSearch.Common.Metadata.Features;
using NuClear.Metamodeling.Elements;
using NuClear.Metamodeling.Provider;
using NuClear.Querying.EntityFramework.Building;
using NuClear.Querying.Web.OData.Controllers;

namespace NuClear.Querying.Web.OData.DynamicControllers
{
    public sealed class DynamicControllersRegistrator
    {
        private readonly IMetadataProvider _metadataProvider;
        private readonly ITypeProvider _typeProvider;
        private readonly IDynamicAssembliesRegistry _registry;

        public DynamicControllersRegistrator(IMetadataProvider metadataProvider, ITypeProvider typeProvider, IDynamicAssembliesRegistry registry)
        {
            _metadataProvider = metadataProvider;
            _typeProvider = typeProvider;
            _registry = registry;
        }

        public void RegisterDynamicControllers(Uri uri)
        {
            BoundedContextElement boundedContextElement;
            if (!_metadataProvider.TryGetMetadata(uri, out boundedContextElement))
            {
                throw new ArgumentException();
            }

            var dynamicAssembly = CreateDynamicControllersAssembly(boundedContextElement);
            _registry.RegisterDynamicAssembly(dynamicAssembly);
        }

        private static void AddParentConstructor(TypeBuilder typeBuilder, Type parentType)
        {
            var parentConstructor = parentType.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance | BindingFlags.Instance).First();
            var parentParameters = parentConstructor.GetParameters();

            var parameterTypes = parentParameters.Select(x => x.ParameterType).ToArray();
            var constructorBuilder = typeBuilder.DefineConstructor(parentConstructor.Attributes | MethodAttributes.Public, parentConstructor.CallingConvention, parameterTypes);
            var generator = constructorBuilder.GetILGenerator();

            // load 'this' pointer
            generator.Emit(OpCodes.Ldarg_0);

            for (var i = 1; i <= parentParameters.Length; i++)
            {
                var parentParameter = parentParameters[i - 1];
                constructorBuilder.DefineParameter(i, parentParameter.Attributes, parentParameter.Name);

                generator.Emit(OpCodes.Ldarg_S, i);
            }

            generator.Emit(OpCodes.Call, parentConstructor);
            generator.Emit(OpCodes.Ret);
        }

        private static void AddEntityElementIdAnnotation(TypeBuilder typeBuilder, EntityElement entity)
        {
            var id = entity.Identity.Id.ToString();
            var constructor = typeof(EntityElementIdAttribute).GetConstructors().First();
            var customAttributeBuilder = new CustomAttributeBuilder(constructor, new object[] { id });

            typeBuilder.SetCustomAttribute(customAttributeBuilder);
        }

        private static void AddContainmentEntitiesMethods(TypeBuilder typeBuilder, Type parentType, EntityElement entity, Type entityType)
        {
            var propertyInfos = entity.Relations
                .Where(x => x.Uses<EntityRelationContainmentFeature>())
                .Select(x =>
                {
                    var propertyName = x.ResolveName();
                    return entityType.GetProperty(propertyName);
                });

            foreach (var propertyInfo in propertyInfos)
            {
                AddContainmentEntitiesMethod(typeBuilder, parentType, propertyInfo);
            }
        }

        private static void AddContainmentEntitiesMethod(TypeBuilder typeBuilder, Type parentType, PropertyInfo propertyInfo)
        {
            var methodBuilder = typeBuilder.DefineMethod("Get" + propertyInfo.Name, MethodAttributes.Public , typeof(IHttpActionResult), new[] { typeof(long) });
            var keyParameter = methodBuilder.DefineParameter(1, ParameterAttributes.None, "key");

            var dynamicEnableQueryAttribute = typeof(DynamicEnableQueryAttribute).GetConstructor(Type.EmptyTypes);
            if (dynamicEnableQueryAttribute == null)
            {
                throw new ArgumentException();
            }
            methodBuilder.SetCustomAttribute(new CustomAttributeBuilder(dynamicEnableQueryAttribute, new object[0]));

            var fromODataUriAttribute = typeof(FromODataUriAttribute).GetConstructor(Type.EmptyTypes);
            if (fromODataUriAttribute == null)
            {
                throw new ArgumentException();
            }
            keyParameter.SetCustomAttribute(new CustomAttributeBuilder(fromODataUriAttribute, new object[0]));

            var getContainedEntityMethodInfo = parentType.GetMethod("GetContainedEntity", BindingFlags.Instance | BindingFlags.NonPublic).MakeGenericMethod(propertyInfo.PropertyType.GetGenericArguments());

            var generator = methodBuilder.GetILGenerator();

            // push "this"
            generator.Emit(OpCodes.Ldarg_0);
            // push "key"
            generator.Emit(OpCodes.Ldarg_1);
            // push propertyName
            generator.Emit(OpCodes.Ldstr, propertyInfo.Name);
            // call
            generator.Emit(OpCodes.Call, getContainedEntityMethodInfo);
            generator.Emit(OpCodes.Ret);
        }

        private Assembly CreateDynamicControllersAssembly(BoundedContextElement boundedContextElement)
        {
            var assemblyModuleName = boundedContextElement.Identity.Id.Segments.LastOrDefault() + "Controllers";

            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(assemblyModuleName), AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyModuleName);

            var entities = boundedContextElement.ConceptualModel.Entities.Where(x => !string.IsNullOrEmpty(x.EntitySetName));

            foreach (var entity in entities)
            {
                var entityType = _typeProvider.Resolve(entity);
                var parentType = typeof(GenericODataController<>).MakeGenericType(entityType);

                var controllerTypeName = entity.EntitySetName + "Controller";
                var typeBuilder = moduleBuilder.DefineType(controllerTypeName, TypeAttributes.Public | TypeAttributes.Sealed, parentType);

                AddParentConstructor(typeBuilder, parentType);
                AddEntityElementIdAnnotation(typeBuilder, entity);
                AddContainmentEntitiesMethods(typeBuilder, parentType, entity, entityType);

                typeBuilder.CreateType();
            }

            return assemblyBuilder;
        }
    }
}