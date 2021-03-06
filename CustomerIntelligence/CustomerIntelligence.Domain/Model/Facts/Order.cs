﻿using System;

namespace NuClear.CustomerIntelligence.Domain.Model.Facts
{
    public sealed class Order : IErmFactObject
    {
        public long Id { get; set; }

        public DateTimeOffset EndDistributionDateFact { get; set; }

        public long FirmId { get; set; }
    }
}