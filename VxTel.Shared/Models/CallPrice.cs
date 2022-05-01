using System.ComponentModel.DataAnnotations;

namespace VxTel.Shared.Models
{
    public class CallPrice
    {
        [Key]
        public int Id { get; set; }
        public string FromDDD { get; set; } 
        public string ToDDD { get; set; } 
        public double PricePerMinute { get; set; }
    }
}
