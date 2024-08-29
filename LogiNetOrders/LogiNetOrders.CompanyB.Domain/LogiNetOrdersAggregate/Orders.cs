using LogiNetOrders.CompanyB.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Domain.LogiNetOrdersAggregate;

public class Orders : BaseEntity
{
    public DateTime OrderDate { get; set; }
    public string DispatchPoint { get; set; } = string.Empty;
    public int PersonId { get; set; }
    public Person Consignee { get; set; }
    public string ContactPhoneNumber { get; set; } = string.Empty;
    public ICollection<OrderProducts> OrderProducts { get; set; } = new List<OrderProducts>();
}
