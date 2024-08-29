using LogiNetOrders.CompanyB.Domain.LogiNetOrdersAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Application.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Orders>
    {
        Task<List<Orders>> GetOrdersWithDetails(Expression<Func<Orders, bool>> expression);
    }
}
