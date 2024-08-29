using LogiNetOrders.CompanyB.Domain.LogiNetOrdersAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Application.Responses;

[DataContract]
public class GetOrdersResponse
{
    [DataMember]
    public int Id { get; set; }
    
    [DataMember]
    public DateTime OrderDate { get; set; }

    [DataMember]
    public string DispatchPoint { get; set; } = string.Empty;

    [DataMember]
    public GetPersonResponse Consignee { get; set; } = new();

    [DataMember]
    public List<GetOrderProductsResponse> OrderProducts { get; set; } = new List<GetOrderProductsResponse>();
}
