using LogiNetOrders.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.Application.Commands.OrderCommands
{
    public class UpdateOrderCommand : IRequest<Response<bool>>
    {
        public int Id { get; set; }
        public string DispatchPoint { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
    }
}
