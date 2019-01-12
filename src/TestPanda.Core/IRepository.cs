using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestPanda.Core
{
    public interface IRepository<T> where T : IEntity
    {
        Task<IEnumerable<T>> GetItemsAsync();
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T> FindByIdAsync(int Id);
    }
}
