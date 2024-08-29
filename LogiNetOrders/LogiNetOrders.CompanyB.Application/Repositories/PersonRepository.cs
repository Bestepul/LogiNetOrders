using LogiNetOrders.CompanyB.Application.Repositories.Interfaces;
using LogiNetOrders.CompanyB.Domain.LogiNetOrdersAggregate;
using LogiNetOrders.CompanyB.Persistence;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Application.Repositories
{
    public class PersonRepository : Repository<Person>,IPersonRepository
    {

        public PersonRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
