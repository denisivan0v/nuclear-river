﻿using System;

namespace NuClear.CustomerIntelligence.Domain.Model.Facts
{
    public sealed class Client : IErmFactObject
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset? LastDisqualifiedOn { get; set; }

        public bool HasPhone { get; set; }

        public bool HasWebsite { get; set; }
    }
}