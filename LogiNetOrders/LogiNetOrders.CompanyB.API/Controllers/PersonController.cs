using LogiNetOrders.CompanyB.Application.Commands.PersonCommands;
using LogiNetOrders.CompanyB.Application.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogiNetOrders.CompanyB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : CustomBaseController
    {
        [HttpPost("CreatePerson")]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonCommand command)
        {
            var response = await Mediator.Send(command);

            return CreateActionResultInstance(response);
        }
    }
}
