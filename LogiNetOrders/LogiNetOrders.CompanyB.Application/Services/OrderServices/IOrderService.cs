using LogiNetOrders.CompanyB.Application.Responses;
using LogiNetOrders.CompanyB.Domain.LogiNetOrdersAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Application.Services.OrderServices
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        Task<List<GetOrdersResponse>> GetOrdersWithDetails(Expression<Func<Orders, bool>> expression);
    }
}
