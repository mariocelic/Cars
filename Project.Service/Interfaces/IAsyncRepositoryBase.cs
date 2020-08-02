using Project.Service.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IAsyncRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> FindAll();        
        Task<T> GetById(int id);       
        Task Create(T entity);
        void Update(T entity);
        Task Delete(int id);        
    }
}
