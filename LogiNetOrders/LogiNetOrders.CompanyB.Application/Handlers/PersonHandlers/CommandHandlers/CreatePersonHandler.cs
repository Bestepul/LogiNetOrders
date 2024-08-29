using AutoMapper;
using LogiNetOrders.CompanyB.Application.Commands.PersonCommands;
using LogiNetOrders.CompanyB.Application.Common;
using LogiNetOrders.CompanyB.Application.Repositories.Interfaces;
using LogiNetOrders.CompanyB.Domain.LogiNetOrdersAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Application.Handlers.PersonHandlers.CommandHandlers;

public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, Response<bool>>
{
    private readonly IMapper _mapper;
    private readonly IPersonRepository _repository;

    public CreatePersonHandler(IMapper mapper, IPersonRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<bool>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {

        Person person = _mapper.Map<Person>(request);
        person.CreatedDate= DateTime.Now;
        person.Status = true;
        await _repository.Create(person);
        return Response<bool>.Success(true, 201);


    }
}
