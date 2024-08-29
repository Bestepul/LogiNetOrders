using LogiNetOrders.CompanyB.Application.Repositories.Interfaces;
using LogiNetOrders.CompanyB.Domain.LogiNetOrdersAggregate;
using LogiNetOrders.CompanyB.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Application.Repositories;

public class OrderRepository : Repository<Orders>, IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;

    }

    public async Task<List<Orders>> GetOrdersWithDetails(Expression<Func<Orders, bool>> expression)
    {
        return await _dbContext.Orders
           .Include(o => o.OrderProducts)  
           .ThenInclude(op => op.Product)   
           .Include(o => o.Consignee)       
           .Where(expression)               
           .AsNoTracking()                 
           .ToListAsync();
    }
}
