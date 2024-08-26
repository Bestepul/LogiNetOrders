using LogiNetOrders.CompanyB.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Application.Repositories.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<int> Create(T entity);
    Task<int> CreateAll(List<T> entities);
    Task<T> Find(Expression<Func<T, bool>> expression);
    Task<List<T>> GetAll();
    Task<List<T>> GetAll(Expression<Func<T, bool>> expression);
    Task<int> Update(T entity);
    Task<int> Delete(Expression<Func<T, bool>> predicate);

    Task<int> UpdateAll(List<T> entities);
}

