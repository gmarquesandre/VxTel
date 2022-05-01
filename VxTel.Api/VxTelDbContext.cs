using Microsoft.EntityFrameworkCore;
using VxTel.Api.Models;

namespace VxTel.Api
{
 

    public class VxTelDbContext : DbContext
    {
        public VxTelDbContext(DbContextOptions<VxTelDbContext> options) : base(options)
        {

        }
        public DbSet<CallPrice> CallPrices { get; set; }
        public DbSet<CallPlan> CallPlans { get; set; }

    }
}
