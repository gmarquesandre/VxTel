namespace VxTel.Shared.Dto
{
    public class CallPriceCompareDto
    {
        public string FromDDD { get; set; }
        public string ToDDD { get; set; }
        public int CallTime { get; set; }
        public string CallPlanName { get; set;}
        public double PriceWithoutPlan { get; set; }
        public double PriceWithPlan { get; set; }

    }
}
