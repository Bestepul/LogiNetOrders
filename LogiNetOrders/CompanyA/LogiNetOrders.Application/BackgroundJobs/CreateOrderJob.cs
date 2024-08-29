using LogiNetOrders.Application.Repositories.Interfaces;
using LogiNetOrders.Domain.Entities;
using LogiNetOrders.Infrastructure.Responses;
using LogiNetOrders.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LogiNetOrders.Application.BackgroundJobs;

public class CreateOrderJob
{
    private readonly OrderService _orderService;
    private readonly IOrderRepository _repository;

    public CreateOrderJob(OrderService orderService, IOrderRepository repository)
    {
        _orderService = orderService;
        _repository = repository;
    }

    public async Task CreateOrder()
    {
        var ordersXml = await _orderService.GetOrdersWithDetailsAsync();
        var orders = ParseOrdersFromXml(ordersXml); // XML'i parse eden bir metod

        var today = DateTime.Now.Date;
        var previousDay = today.AddDays(-1);

        var previousOrders = orders.Where(x => x.OrderDate.Date == previousDay);

        var createOrders = previousOrders.Select(t => new Order
        {
            OrderDate = t.OrderDate,
            DispatchPoint=t.DispatchPoint,
            Surname=t.Consignee.Surname,
            Name=t.Consignee.Name,
            Phone=t.Consignee.Phone,
            OrderStatus=0,
            CompanyBOrderId=t.Id,

        }).ToList();

        await _repository.CreateAll(createOrders);



       
    }

    public IEnumerable<GetOrdersResponse> ParseOrdersFromXml(string xml)
    {
        var serializer = new XmlSerializer(typeof(Envelope));

        using (var stringReader = new StringReader(xml))
        {
            var envelope = (Envelope)serializer.Deserialize(stringReader);
            if (envelope?.Body?.GetOrdersWithDetailsResponse?.GetOrdersWithDetailsResult?.GetOrdersResponses == null)
            {
                throw new InvalidOperationException("Deserialization result is null. Please check the XML structure and class definitions.");
            }
            return envelope.Body.GetOrdersWithDetailsResponse.GetOrdersWithDetailsResult.GetOrdersResponses;
        }
    }
}
