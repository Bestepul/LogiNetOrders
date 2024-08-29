using LogiNetOrders.CompanyB.Application.Common;
using LogiNetOrders.CompanyB.Domain.LogiNetOrdersAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Application.Commands.OrderCommands
{
    public class CreateOrderCommand : IRequest<Response<bool>>
    {
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public string DispatchPoint { get; set; } = string.Empty;

        [Required]
        public int PersonId { get; set; }

        public List<OrderProductsCommand> OrderProducts { get; set; }

    }

    public class OrderProductsCommand
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}


