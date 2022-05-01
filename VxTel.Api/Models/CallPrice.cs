using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Models
{
    public class CallPrice
    {
        [Key]
        public int Id { get; set; }
        public int FromDDD { get; set; } 
        public int ToDDD { get; set; } 
        public decimal PricePerMinute { get; set; }
    }
}
