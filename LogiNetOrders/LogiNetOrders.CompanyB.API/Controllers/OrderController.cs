using LogiNetOrders.CompanyB.Application.Commands.OrderCommands;
using LogiNetOrders.CompanyB.Application.Commands.ProductCommands;
using LogiNetOrders.CompanyB.Application.Common;
using LogiNetOrders.CompanyB.Application.Queries.OrderQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogiNetOrders.CompanyB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : CustomBaseController
    {
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var response = await Mediator.Send(command);

            return CreateActionResultInstance(response);
        }

        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            var response = await Mediator.Send(new GetOrdersQuery());

            return CreateActionResultInstance(response);
        }


    }
}
