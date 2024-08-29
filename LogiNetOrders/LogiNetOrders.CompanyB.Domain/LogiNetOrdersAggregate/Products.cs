using LogiNetOrders.CompanyB.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Domain.LogiNetOrdersAggregate;

public class Products : BaseEntity
{
    public string ProductName { get; set; } = string.Empty;
}
