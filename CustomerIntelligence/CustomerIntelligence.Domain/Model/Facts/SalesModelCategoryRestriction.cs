﻿namespace NuClear.CustomerIntelligence.Domain.Model.Facts
{
    public sealed class SalesModelCategoryRestriction : IErmFactObject
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public long ProjectId { get; set; }
        public int SalesModel { get; set; }
    }
}