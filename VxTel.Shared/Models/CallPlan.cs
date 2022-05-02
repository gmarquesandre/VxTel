using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace VxTel.Shared.Models
{
    public class CallPlan
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int FreeTime { get; set; }
        public double ExcedeedTimeFeePercentage { get; set; }
        public double Price { get; set; }
    }
}
