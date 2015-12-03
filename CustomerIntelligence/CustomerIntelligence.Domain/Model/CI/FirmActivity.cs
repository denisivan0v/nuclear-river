﻿using System;

using NuClear.AdvancedSearch.Common.Metadata.Model;

namespace NuClear.CustomerIntelligence.Domain.Model.CI
{
    public sealed class FirmActivity : ICustomerIntelligenceObject
    {
        public long FirmId { get; set; }

        public DateTimeOffset? LastActivityOn { get; set; }
    }
}