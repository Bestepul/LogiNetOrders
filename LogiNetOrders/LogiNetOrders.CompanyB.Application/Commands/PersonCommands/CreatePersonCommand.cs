using LogiNetOrders.CompanyB.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Application.Commands.PersonCommands
{
    public class CreatePersonCommand : IRequest<Response<bool>>
    {
        [Required(ErrorMessage = "Surname cannot be null or empty.")]
        public string Surname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name cannot be null or empty.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone cannot be null or empty.")]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        //1 alıcı 2 teslim eden 
        public int PersonTypeId { get; set; }

        public string CreatedBy { get; set; } = string.Empty;
    }
}
