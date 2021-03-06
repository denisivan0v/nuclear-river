﻿using System.Collections.Generic;

using NuClear.AdvancedSearch.Common.Metadata.Model.Operations;

namespace NuClear.Replication.Core.API.Aggregates
{
    public interface IStatisticsRecalculator
    {
        void Recalculate(IEnumerable<RecalculateStatisticsOperation> operations);
    }
}