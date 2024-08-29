using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.Infrastructure.Services;

public class OrderService
{
    private readonly HttpClient _httpClient;

    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetOrdersWithDetailsAsync()
    {
        var requestXml = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:temp=""http://tempuri.org/"">
    <soapenv:Header/>
    <soapenv:Body>
        <temp:GetOrdersWithDetails>
      
        </temp:GetOrdersWithDetails>
</soapenv:Body>
</soapenv:Envelope>";

        var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:6182/OrderService.asmx")
        {
            Content = new StringContent(requestXml, Encoding.UTF8, "text/xml")
        };

        var response = await _httpClient.SendAsync(request);
        return await response.Content.ReadAsStringAsync();
    }
}
