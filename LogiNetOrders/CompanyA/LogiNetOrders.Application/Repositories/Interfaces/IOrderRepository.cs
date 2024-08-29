using LogiNetOrders.CompanyB.Domain.LogiNetOrdersAggregate;
using LogiNetOrders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.Application.Repositories.Interfaces;

public interface IOrderRepository : IRepository<Order>
{
}
