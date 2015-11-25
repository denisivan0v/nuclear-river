﻿using NuClear.AdvancedSearch.Common.Metadata.Model;

namespace NuClear.CustomerIntelligence.Domain.Model.Facts
{
    public sealed class Account : IFactObject
    {
        public long Id { get; set; }

        public decimal Balance { get; set; }

        public long BranchOfficeOrganizationUnitId { get; set; }

        public long LegalPersonId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Account && IdentifiableObjectEqualityComparer<Account>.Default.Equals(this, (Account)obj);
        }

        public override int GetHashCode()
        {
            return IdentifiableObjectEqualityComparer<Account>.Default.GetHashCode(this);
        }
    }
}