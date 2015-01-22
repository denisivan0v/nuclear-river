using System.Data.Entity.Infrastructure;
using System.Web.OData.Query;

using EntityDataModel.EntityFramework.Tests;

using Microsoft.OData.Edm;

using NuClear.AdvancedSearch.EntityDataModel.OData.Building;

using NUnit.Framework;

namespace NuClear.AdvancedSearch.QueryExecution.Tests
{
    public class CustomerIntelligenceBaseFixture : EdmxBuilderBaseFixture
    {
        protected DbCompiledModel Model { get; private set; }
        protected IEdmModel EdmModel { get; private set; }

        [TestFixtureSetUp]
        public void Setup()
        {
            var metadataProvider = CreateMetadataProvider(CustomerIntelligenceMetadataSource);
            var context = LookupContext(metadataProvider);

            var dbModel = BuildModel(context, CustomerIntelligenceTypeProvider);
            Model = dbModel.Compile();
            var clrTypes = dbModel.GetClrTypes();

            EdmModel = EdmModelBuilder.Build(context);
            EdmModel.AddClrAnnotations(clrTypes);
        }

        public ODataQueryOptions CreateValidQueryOptions<T>(string query = null)
        {
            var request = TestHelper.CreateRequest(query);
            var queryOptions = TestHelper.CreateValidQueryOptions(EdmModel, typeof(T), request, new ODataValidationSettings());
            return queryOptions;
        }
    }
}