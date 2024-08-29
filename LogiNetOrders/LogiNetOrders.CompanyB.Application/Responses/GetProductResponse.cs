using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Application.Responses;

public class GetProductResponse
{
    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
}
