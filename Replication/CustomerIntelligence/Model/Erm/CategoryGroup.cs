﻿using NuClear.AdvancedSearch.Replication.Model;

namespace NuClear.AdvancedSearch.Replication.CustomerIntelligence.Model.Erm
{
    public sealed class CategoryGroup : IIdentifiableObject
    {
        public CategoryGroup()
        {
            IsActive = true;
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public float Rate { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CategoryGroup && IdentifiableObjectEqualityComparer<CategoryGroup>.Default.Equals(this, (CategoryGroup)obj);
        }

        public override int GetHashCode()
        {
            return IdentifiableObjectEqualityComparer<CategoryGroup>.Default.GetHashCode(this);
        }
    }
}