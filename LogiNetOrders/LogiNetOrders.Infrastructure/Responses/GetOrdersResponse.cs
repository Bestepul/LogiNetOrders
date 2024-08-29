using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LogiNetOrders.Infrastructure.Responses;


[XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
public class Envelope
{
    [XmlElement(ElementName = "Body")]
    public Body Body { get; set; }
}

public class Body
{
    [XmlElement(ElementName = "GetOrdersWithDetailsResponse", Namespace = "http://tempuri.org/")]
    public GetOrdersWithDetailsResponse GetOrdersWithDetailsResponse { get; set; }
}

public class GetOrdersWithDetailsResponse
{
    [XmlElement(ElementName = "GetOrdersWithDetailsResult")]
    public GetOrdersWithDetailsResult GetOrdersWithDetailsResult { get; set; }
}

public class GetOrdersWithDetailsResult
{
    [XmlElement(ElementName = "GetOrdersResponse", Namespace = "http://schemas.datacontract.org/2004/07/LogiNetOrders.CompanyB.Application.Responses")]
    public List<GetOrdersResponse> GetOrdersResponses { get; set; }
}

public class GetOrdersResponse
{
    public Consignee Consignee { get; set; }
    public string DispatchPoint { get; set; }
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public List<GetOrderProductsResponse> OrderProducts { get; set; }
}

public class Consignee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Surname { get; set; }
}

public class GetOrderProductsResponse
{
    public decimal Amount { get; set; }
    public int Id { get; set; }
    public Product Product { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
}

