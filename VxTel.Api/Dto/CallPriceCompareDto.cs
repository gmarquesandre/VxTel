namespace VxTel.Api.Dto
{
    public class CallPriceCompareDto
    {
        public int FromDDD { get; set; }
        public int ToDDD { get; set; }
        public int Time { get; set; }
        public string CallPlanName { get; set;}
        public decimal WithoutPlan { get; set; }
        public decimal WithPlan { get; set; }

    }
}
