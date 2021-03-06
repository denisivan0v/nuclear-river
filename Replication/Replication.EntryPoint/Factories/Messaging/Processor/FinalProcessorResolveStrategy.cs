﻿using NuClear.Messaging.DI.Factories.Unity.Processors.Resolvers;
using NuClear.Metamodeling.Provider;
using NuClear.OperationsProcessing.API.Metadata;
using NuClear.OperationsProcessing.Final;

namespace NuClear.Replication.EntryPoint.Factories.Messaging.Processor
{
    public sealed class FinalProcessorResolveStrategy : MessageFlowProcessorResolveStrategyBase
    {
        public FinalProcessorResolveStrategy(IMetadataProvider metadataProvider)
            : base(metadataProvider, typeof(PerformedOperationsFinalFlowProcessor), PerformedOperations.IsPerformedOperationsFinalSource)
        {
        }
    }
}