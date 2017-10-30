using System;
using System.Linq; 

namespace NotowaniaMVC.Infrastructure.Common.Interfaces
{
    public interface INHibernateUniversalRepository<T>
    {
        void Create(T item); 
        void Update(T item); 
        T GetByGuid(Guid guid); 
        T GetById(int id);
        void DeleteById(int id);
        void DeleteByGuid(Guid guid);
        IQueryable<T> GetAll(); 
    }
}
