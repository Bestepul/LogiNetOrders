using LogiNetOrders.Application.Commands.OrderCommands;
using LogiNetOrders.Application.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogiNetOrders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : CustomBaseController
    {
        [HttpPut("UpdateOrder/{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderCommand command)
        {
            var response = await Mediator.Send(command);

            return CreateActionResultInstance(response);
        }
    }
}
