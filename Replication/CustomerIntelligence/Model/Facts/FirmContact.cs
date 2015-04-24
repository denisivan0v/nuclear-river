﻿using NuClear.AdvancedSearch.Replication.Model;

namespace NuClear.AdvancedSearch.Replication.CustomerIntelligence.Model.Facts
{
    public sealed class FirmContact : IIdentifiableObject
    {
        public long Id { get; set; }

        public bool HasPhone { get; set; }
        
        public bool HasWebsite { get; set; }

        public long FirmAddressId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is FirmContact && IdentifiableObjectEqualityComparer<FirmContact>.Default.Equals(this, (FirmContact)obj);
        }

        public override int GetHashCode()
        {
            return IdentifiableObjectEqualityComparer<FirmContact>.Default.GetHashCode(this);
        }
    }
}