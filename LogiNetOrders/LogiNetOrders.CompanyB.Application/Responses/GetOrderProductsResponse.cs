using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Application.Responses;

public class GetOrderProductsResponse
{
    public int Id { get; set; }
    public GetProductResponse Product { get; set; } = new GetProductResponse();
    public decimal Amount { get; set; }
}
