using LogiNetOrders.CompanyB.Application.Commands.PersonCommands;
using LogiNetOrders.CompanyB.Application.Commands.ProductCommands;
using LogiNetOrders.CompanyB.Application.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogiNetOrders.CompanyB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var response = await Mediator.Send(command);

            return CreateActionResultInstance(response);
        }

    }
}
