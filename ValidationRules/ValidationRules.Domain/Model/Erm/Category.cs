namespace NuClear.ValidationRules.Domain.Model.Erm
{
    public sealed class Category
    {
        public long Id { get; set; }
        public long ParentId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
