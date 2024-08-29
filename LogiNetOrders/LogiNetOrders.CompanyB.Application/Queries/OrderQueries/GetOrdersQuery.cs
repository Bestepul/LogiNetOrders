using LogiNetOrders.CompanyB.Application.Common;
using LogiNetOrders.CompanyB.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Application.Queries.OrderQueries;

public record GetOrdersQuery : IRequest<Response<List<GetOrdersResponse>>>;

