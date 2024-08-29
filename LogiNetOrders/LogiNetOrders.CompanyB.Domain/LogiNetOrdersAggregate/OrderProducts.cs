using LogiNetOrders.CompanyB.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Domain.LogiNetOrdersAggregate;

public class OrderProducts : BaseEntity
{
    public  int OrderId { get; set; }
    public Orders Order { get; set; } =new Orders();
    public int ProductId { get; set; }
    public  Products Product { get; set; }
    public  decimal Amount { get; set; }
}
