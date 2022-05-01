﻿using Microsoft.EntityFrameworkCore;
using VxTel.Shared.DefaultValues;
using VxTel.Shared.Models;

namespace VxTel.Api
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


            var _defaultValues = new DefaultCallPrice();
            modelBuilder.Entity<CallPrice>().HasData(_defaultValues.GetDefaultPrices());

            var _defaultPlans = new DefaultCallPlan();
            modelBuilder.Entity<CallPlan>().HasData(_defaultPlans.GetDefaultPlans());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            if (options.IsConfigured) return;

            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        }

    }
}
