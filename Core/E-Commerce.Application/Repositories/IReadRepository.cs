using System.Linq.Expressions;
using E_Commerce.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
    Task<T?> GetSingleAsync(Expression<Func<T, bool>> method);
    Task<T> GetByIdAsync(string id);
}