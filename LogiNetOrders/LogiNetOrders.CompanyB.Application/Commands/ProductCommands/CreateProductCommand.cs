using LogiNetOrders.CompanyB.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Application.Commands.ProductCommands
{
    public class CreateProductCommand : IRequest<Response<bool>>
    {
        [Required(ErrorMessage = "Name cannot be null or empty.")]
        public string ProductName { get; set; } = string.Empty;

        public string CreatedBy { get; set; } = string.Empty;
    }
}
