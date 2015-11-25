﻿namespace NuClear.CustomerIntelligence.Domain.Model.CI
{
    public sealed class FirmBalance : ICustomerIntelligenceObject
    {
        public long ProjectId { get; set; }

        public long FirmId { get; set; }

        public long AccountId { get; set; }

        public decimal Balance { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return obj is FirmBalance && Equals((FirmBalance)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = AccountId.GetHashCode();
                hashCode = (hashCode * 397) ^ FirmId.GetHashCode();
                return hashCode;
            }
        }

        private bool Equals(FirmBalance other)
        {
            return AccountId == other.AccountId && FirmId == other.FirmId;
        }
    }
}