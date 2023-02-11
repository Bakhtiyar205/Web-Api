using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Domain.Entities.Common;

namespace E_Commerce.Application.Repositories;

public interface IWriteRepository<T>:IRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T model);
    Task<bool> AddRangeAsync(List<T> datas);
    bool Remove(T model);
    Task<bool> Remove(string id);
    bool RemoveRange(List<T> datas);
    bool Update(T model);
    Task<int> SaveAsync();
}