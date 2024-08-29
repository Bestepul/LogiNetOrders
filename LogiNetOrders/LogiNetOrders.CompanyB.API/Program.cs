using LogiNetOrders.CompanyB.Application;
using LogiNetOrders.CompanyB.Application.Services.OrderServices;
using LogiNetOrders.CompanyB.Persistence;
using SoapCore;
using System.ServiceModel;
using static SoapCore.DocumentationWriter.SoapDefinition;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddSoapCore();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.UseSoapEndpoint<IOrderService>("/OrderService.svc", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
//});

app.UseSoapEndpoint<IOrderService>("/OrderService.asmx",new SoapEncoderOptions());
app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapControllers();

app.Run();
