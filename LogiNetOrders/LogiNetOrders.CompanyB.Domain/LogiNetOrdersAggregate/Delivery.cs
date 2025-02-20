﻿using LogiNetOrders.CompanyB.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Domain.LogiNetOrdersAggregate;

public class Delivery : BaseEntity
{
    public DateTime DeliveryDate { get; set; }

    public string LicensePlate { get; set; } = string.Empty;

    public int DeliveryPersonId { get; set; }
    public Person DeliveryPerson { get; set; } = new Person();

    public int? OrderId { get; set; } 
    public Orders? Order { get; set; } = new Orders(); 
}
