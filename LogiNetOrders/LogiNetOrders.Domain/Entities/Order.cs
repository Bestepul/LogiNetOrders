using LogiNetOrders.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.Domain.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public string DispatchPoint { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        //0 Bekliyor 1 Teslim Edildi
        public int OrderStatus { get; set; }

        public int CompanyBOrderId { get; set; }

    }
}
