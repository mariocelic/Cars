using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
