using AutoMapper;
using LogiNetOrders.CompanyB.Application.Commands.PersonCommands;
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

namespace LogiNetOrders.CompanyB.Application.Handlers.ProductHandlers.CommandHandler;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, Response<bool>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _repository;

    public CreateProductHandler(IMapper mapper, IProductRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<bool>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {

        Products product = _mapper.Map<Products>(request);
        product.CreatedDate = DateTime.Now;
        product.Status = true;
        await _repository.Create(product);
        return Response<bool>.Success(true, 201);


    }
}
