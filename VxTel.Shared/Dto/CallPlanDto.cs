namespace VxTel.Shared.Dto
{
    public class CallPlanDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FreeTime { get; set; }
        public double ExcedeedTimeFeePercentage { get; set; }
        public double Price { get; set; }
    }
}