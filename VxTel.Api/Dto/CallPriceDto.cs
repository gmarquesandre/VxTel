namespace VxTel.Api.Dto
{
    public class CallPriceDto
    {
        public int FromDDD { get; set; }
        public int ToDDD { get; set; }
        public decimal PricePerMinute { get; set; }
    }
}
