﻿using System;

using NuClear.AdvancedSearch.Replication.Transforming;

namespace NuClear.AdvancedSearch.Replication.CustomerIntelligence.Transforming.Operations
{
    public abstract class FactOperation : IOperation
    {
        protected FactOperation(Type factType, long factId)
        {
            if (factType == null)
            {
                throw new ArgumentNullException("factType");
            }

            FactType = factType;
            FactId = factId;
        }

        public Type FactType { get; private set; }

        public long FactId { get; private set; }

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
            return obj is FactOperation && Equals((FactOperation)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (FactType != null ? FactType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ FactId.GetHashCode();
                return hashCode;
            }
        }

        private bool Equals(FactOperation other)
        {
            return FactType == other.FactType && FactId == other.FactId;
        }
    }
}