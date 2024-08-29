using Autofac.Core;
using Hangfire;
using LogiNetOrders.Application;
using LogiNetOrders.Application.BackgroundJobs;
using LogiNetOrders.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddApplication(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHangfireDashboard();
RecurringJob.AddOrUpdate<CreateOrderJob>(
           "CreateOrders",
           job => job.CreateOrder(),
           Cron.Daily);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
