using Microsoft.EntityFrameworkCore;
using VxTel.EntityFramework.DefaultValues;
using VxTel.Shared.Models;

namespace VxTel.EntityFramework
{
    public class VxTelDbContext : DbContext
    {

        public VxTelDbContext(DbContextOptions<VxTelDbContext> options)
            : base(options)
        {

        }

        public VxTelDbContext()
        {

        }

        public DbSet<CallPrice> CallPrices { get; set; }
        public DbSet<CallPlan> CallPlans { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Modeling

            modelBuilder.Entity<CallPrice>()
                    .HasIndex(p => new { p.FromDDD, p.ToDDD })
                    .IsUnique(true);


            modelBuilder.Entity<CallPlan>().HasIndex(u => u.Name).IsUnique();

            //Default Values 
            var _defaultValues = new DefaultCallPrice();
            modelBuilder.Entity<CallPrice>().HasData(_defaultValues.GetDefaultPrices());

            var _defaultPlans = new DefaultCallPlan();
            modelBuilder.Entity<CallPlan>().HasData(_defaultPlans.GetDefaultPlans());

        }

    }
}
