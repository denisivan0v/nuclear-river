namespace NuClear.ValidationRules.Domain.Model.Facts
{
    public sealed class DeniedPosition : IErmFactObject
    {
        public long Id { get; set; }
        public long PositionId { get; set; }
        public long PositionDeniedId { get; set; }
        public int ObjectBindingType { get; set; }
        public long PriceId { get; set; }
    }
}
