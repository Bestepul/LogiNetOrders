using LogiNetOrders.CompanyB.Application.Repositories.Interfaces;
using LogiNetOrders.CompanyB.Domain.Common;
using LogiNetOrders.CompanyB.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Application.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _dbContext;

    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Create(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return await Save();
    }

    public async Task<int> CreateAll(List<T> entities)
    {
        await _dbContext.Set<T>().AddRangeAsync(entities);
        return await Save();

    }

    public async Task<int> Delete(Expression<Func<T, bool>> predicate)
    {
        var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        if (entity != null)
        {
            _dbContext.Set<T>().Remove(entity);
            return await Save();
        }
        return 0;
    }

    public async Task<T> Find(Expression<Func<T, bool>> expression)
    {
        return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
    }

    public async Task<List<T>> GetAll()
    {
        return await _dbContext.Set<T>().AsQueryable().AsNoTracking().ToListAsync();
    }

    public async Task<List<T>> GetAll(Expression<Func<T, bool>> expression)
    {
        return await _dbContext.Set<T>().AsQueryable().AsNoTracking().Where(expression).ToListAsync();
    }

    public async Task<int> Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        return await Save();
    }

    public async Task<int> Save()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAll(List<T> entities)
    {
        _dbContext.Set<T>().UpdateRange(entities);
        return await Save();
    }

   
}
