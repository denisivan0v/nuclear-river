﻿using Microsoft.Practices.Unity;

using NuClear.AdvancedSearch.Common.Metadata.Elements;
using NuClear.Replication.Core.Aggregates;
using NuClear.Replication.Core.API.Aggregates;

namespace NuClear.Replication.EntryPoint.Factories.Replication
{
    public class UnityValueObjectProcessorFactory : IValueObjectProcessorFactory
    {
        private readonly IUnityContainer _unityContainer;

        public UnityValueObjectProcessorFactory(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public IValueObjectProcessor Create(IValueObjectMetadataElement metadata)
        {
            var processorType = typeof(ValueObjectProcessor<>).MakeGenericType(metadata.ValueObjectType);
            var processor = _unityContainer.Resolve(processorType, new DependencyOverride(metadata.GetType(), metadata));
            return (IValueObjectProcessor)processor;
        }
    }
}