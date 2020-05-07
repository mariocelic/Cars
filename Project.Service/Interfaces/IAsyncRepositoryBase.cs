using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IAsyncRepositoryBase<T> where T : class
    {
        Task<IList<T>> GetAll();
        Task<T> GetById(int id);       
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(int id);        
    }
}
