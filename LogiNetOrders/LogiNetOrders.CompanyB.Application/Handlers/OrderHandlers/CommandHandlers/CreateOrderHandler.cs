using AutoMapper;
using LogiNetOrders.CompanyB.Application.Commands.OrderCommands;
using LogiNetOrders.CompanyB.Application.Commands.ProductCommands;
using LogiNetOrders.CompanyB.Application.Common;
using LogiNetOrders.CompanyB.Application.Repositories.Interfaces;
using LogiNetOrders.CompanyB.Domain.LogiNetOrdersAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Application.Handlers.OrderHandlers.CommandHandlers;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Response<bool>>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _repository;

    public CreateOrderHandler(IMapper mapper, IOrderRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<bool>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {

        Orders order = _mapper.Map<Orders>(request);

        order.OrderProducts = request.OrderProducts
            .Select(opc => new OrderProducts
            {
                ProductId = opc.ProductId,
                Amount = opc.Amount
            }).ToList();

        order.CreatedDate = DateTime.Now;
        order.Status = true;

        await _repository.Create(order);

        return Response<bool>.Success(true, 201);


    }
}
