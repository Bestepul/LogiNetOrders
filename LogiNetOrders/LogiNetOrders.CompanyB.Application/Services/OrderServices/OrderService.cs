using AutoMapper;
using LogiNetOrders.CompanyB.Application.Repositories;
using LogiNetOrders.CompanyB.Application.Repositories.Interfaces;
using LogiNetOrders.CompanyB.Application.Responses;
using LogiNetOrders.CompanyB.Domain.LogiNetOrdersAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Application.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<GetOrdersResponse>> GetOrdersWithDetails(Expression<Func<Orders, bool>> expression)
        {
            var orders = await _orderRepository.GetOrdersWithDetails(x => x.Status);
            var response = _mapper.Map<List<GetOrdersResponse>>(orders);

            return response;
        }
    }
}
