﻿using NHibernate;
using NotowaniaMVC.Infrastructure.Database.DBConfiguration;
using NotowaniaMVC.Infrastructure.Database.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace NotowaniaMVC.Infrastructure.Common.Repositories
{
    public class NHibernateUniversalRepository<T>  
    { 
        ParameterExpression parameter = Expression.Parameter(typeof(T));
        private ISession Session { get; set; }

        public NHibernateUniversalRepository(ISession session)
        { 
            Session = session;
        }
         
        public void Create(T item)
        {
            Session.Save(item); 
        }

        public void Update(T item)
        {
            Session.Update(item);
        }

        public T GetByGuid(Guid guid)
        {
            var predicateGuid = Expression.Lambda<Func<T, bool>>(Expression.Equal(Expression.Property(parameter, "Guid"), Expression.Constant(guid)), parameter); 
            return Session.Query<T>().Single(predicateGuid);
        }

        public T GetById(int id)
        {
            var predicate = Expression.Lambda<Func<T, bool>>(Expression.Equal(Expression.Property(parameter, "Id"), Expression.Constant(id)), parameter);
            return Session.Query<T>().Single(predicate);
        }

        public void DeleteById(int id)
        { 
            var objectToDelete = Session.Load<T>(id);
            Session.Delete(objectToDelete); 
        }

        public void DeleteByGuid(Guid guid)
        {
          //  var predicate = Expression.Lambda<Func<T, bool>>(Expression.Equal(Expression.Property(parameter, "Guid"), Expression.Constant(guid)), parameter);
            //Session.Delete<T>(predicate);
        }  
    }
}