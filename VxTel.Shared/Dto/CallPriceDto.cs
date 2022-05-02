namespace VxTel.Shared.Dto
{
    public class CallPriceDto
    {
        public int Id { get; set; }
        public string FromDDD { get; set; }
        public string ToDDD { get; set; }
        public double PricePerMinute { get; set; }
    }
}
