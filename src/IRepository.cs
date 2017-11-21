using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace todo
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetItemAsync(string id, string category);
        Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate);

        Task<Object> CreateItemAsync(T item);

        Task<Object> UpdateItemAsync(string id, T item);

        Task DeleteItemAsync(string id, string category);

        void Initialize();
    }
}
