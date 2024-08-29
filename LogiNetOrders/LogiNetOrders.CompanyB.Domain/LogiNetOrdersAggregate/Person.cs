using LogiNetOrders.CompanyB.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Domain.LogiNetOrdersAggregate;

public class Person : BaseEntity
{
    [Required]
    public string Surname { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Phone]
    public string Phone { get; set; }= string.Empty;

    //1 alıcı 2 teslim eden 
    public int PersonTypeId { get; set; }
    
}
