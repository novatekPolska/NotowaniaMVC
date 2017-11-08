using NHibernate;
using NotowaniaMVC.Infrastructure.Common.Interfaces; 
using System; 
using System.Linq;
using System.Linq.Expressions;

namespace NotowaniaMVC.Infrastructure.Common.Repositories
{
    public class NHibernateUniversalRepository<T> : INHibernateUniversalRepository<T>
    {  
        private ISession Session { get; set; }

        public NHibernateUniversalRepository(ISession session)
        { 
            Session = session;
        }
         
        public void Create(T item)
        {
            using (var transaction = Session.BeginTransaction())
            { 
                transaction.Begin();
                Session.Save(item);
                transaction.Commit();
            }   
        }

        public void Update(T item)
        {
            using (var transaction = Session.BeginTransaction())
            {
                transaction.Begin();
                //blokowanie obiektu na czas edycji -> optimistic locking. 
                //Czemu to jest wazne to jest wyjasnione gdzies w internetach, 
                //a dokladniej np w artykułach bottega it minds z zakresu architektury ddd
                Session.Lock(item, LockMode.Upgrade);
                Session.Update(item);
                transaction.Commit();
            }
        }

        public T GetByGuid(Guid guid)
        { 
             ParameterExpression parameter = Expression.Parameter(typeof(T));
             var predicateGuid = Expression.Lambda<Func<T, bool>>(Expression.Equal(Expression.Property(parameter, "Guid"), Expression.Constant(guid)), parameter);
             return Session.Query<T>().Single(predicateGuid); 
        } 

        public T GetById(int id)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T));
            var predicate = Expression.Lambda<Func<T, bool>>(Expression.Equal(Expression.Property(parameter, "Id"), Expression.Constant(id)), parameter);
            return Session.Query<T>().Single(predicate);
        }

        public void DeleteById(int id)
        {
            using (var transaction = Session.BeginTransaction())
            {
                transaction.Begin();
                var objectToDelete = Session.Load<T>(id);
                Session.Delete(objectToDelete);
                transaction.Commit();
            }
        }

        public void DeleteByGuid(Guid guid)
        {
            //using (var transaction = Session.BeginTransaction())
            //{
            //    transaction.Begin();
            //    var objectToDelete = Session.Load<T>();
            //    Session.Delete(objectToDelete);
            //    transaction.Commit();
            //}
        }

        public IQueryable<T> GetAll() 
        {
           return Session.Query<T>();
        } 
    } 
}
