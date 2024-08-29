using AutoMapper;
using LogiNetOrders.CompanyB.Application.Common;
using LogiNetOrders.CompanyB.Application.Queries.OrderQueries;
using LogiNetOrders.CompanyB.Application.Repositories;
using LogiNetOrders.CompanyB.Application.Repositories.Interfaces;
using LogiNetOrders.CompanyB.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Application.Handlers.OrderHandlers.QueryHandlers;

public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, Response<List<GetOrdersResponse>>>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _repository;

    public GetOrdersHandler(IMapper mapper, IOrderRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<List<GetOrdersResponse>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _repository.GetOrdersWithDetails(x=>x.Status);
        var response = _mapper.Map<List<GetOrdersResponse>>(orders);

        return Response<List<GetOrdersResponse>>.Success(response, 200);
    }
}
