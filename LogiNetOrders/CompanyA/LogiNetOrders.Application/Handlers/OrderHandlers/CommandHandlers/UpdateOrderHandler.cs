using AutoMapper;
using LogiNetOrders.Application.Commands.OrderCommands;
using LogiNetOrders.Application.Common;
using LogiNetOrders.Application.Repositories.Interfaces;
using LogiNetOrders.CompanyB.Application.Commands.OrderCommands;
using LogiNetOrders.CompanyB.Domain.LogiNetOrdersAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.Application.Handlers.OrderHandlers.CommandHandlers;

public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, Response<bool>>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _repository;

    public UpdateOrderHandler(IMapper mapper, IOrderRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<bool>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {

        var order = await _repository.Find(x=>x.Id==request.Id);
        if (order == null) return Response<bool>.Fail($"The order with this {request.Id} could not be found in the system.", 409);


        order.DispatchPoint = request.DispatchPoint;
        order.OrderDate = request.OrderDate;
        order.Name = request.Name;
        order.OrderStatus = 1;
        order.Phone = request.Phone;
        order.Surname = request.Surname;
        order.ModifiedDate = DateTime.Now;

         await _repository.Update(order);

        return Response<bool>.Success(true, 201);


    }
}
