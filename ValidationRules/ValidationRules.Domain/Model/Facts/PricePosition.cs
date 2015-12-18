namespace NuClear.ValidationRules.Domain.Model.Facts
{
    public sealed class PricePosition : IErmFactObject
    {
        public long Id { get; set; }
        public long PriceId { get; set; }
        public long PositionId { get; set; }
        public int MinAdvertisementAmount { get; set; }
        public int MaxAdvertisementAmount { get; set; }
    }
}
