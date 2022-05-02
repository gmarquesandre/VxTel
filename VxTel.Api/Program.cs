using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using VxTel.Core.Domains;
using VxTel.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<CallPlanDomain, CallPlanDomain>();
builder.Services.AddScoped<CallPriceDomain, CallPriceDomain>();
builder.Services.AddScoped<ComparePriceDomain, ComparePriceDomain>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    { c.SwaggerDoc("v1", new OpenApiInfo { Title = "VxTel Api", Version = "v1" });
});

builder.Services.AddDbContext<VxTelDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));

});

var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
