using System.ComponentModel.DataAnnotations;

namespace VxTel.Shared.Models
{
    public class CallPlan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "O tempo gratuíto do plano deve ser maior que zero")]
        public int FreeTime { get; set; }
        [Required]
        public double ExcedeedTimeFeePercentage { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage="O Preço deve ser maior do que zero")]
        public double Price { get; set; }
    }
}
