using NHibernate;
using NotowaniaMVC.Infrastructure.Database.Entities;
using System;

namespace NotowaniaMVC.Infrastructure.Common.Repositories
{
    public class NHibernateUniversalRepository<T>  
    {
        private ISession Session { get; set; }
        public NHibernateUniversalRepository(ISession session)
        {
            Session = session;
        }


        public void Create(T item)
        {

        }

        public void Update(T item)
        {

        }

        public T GetByGuid(Guid guid)
        {
            return ReturnObject<T>();
        }

        public T GetById(int id)
        {
            return ReturnObject<T>();
        }

        public void DeleteById(int id)
        {

        }

        public void DeleteByGuid(Guid guid)
        {

        }

        private T ReturnObject<T>()
        {
            if (typeof(T) == typeof(XXX_R55_Quotations))
            { 
                return (T)Convert.ChangeType(CreateFakeQuotationObject(), typeof(T));
            }
            else if (typeof(T) == typeof(XXX_R55_PriceLists))
            {
               return (T)Convert.ChangeType(CreateFakePriceListObject(), typeof(T)); 
            } 
            return (T)Convert.ChangeType(CreateFakePriceListObject(), typeof(T)); 
        }

        private XXX_R55_Quotations CreateFakeQuotationObject()
        {
            return new XXX_R55_Quotations
            {
                Code = "testCode",
                Created = DateTime.Now,
                Guid = new Guid(),
                Modified = DateTime.Now,
                Modifier = 1,
                Creator = 1
            };
        }

        private XXX_R55_PriceLists CreateFakePriceListObject()
        {
            return new XXX_R55_PriceLists
            {
                Guid = new Guid(),
                Code = "testCode",
                PriceMin = 10,
                PriceMax = 20,
                DateTo = DateTime.Now,
                DateOfQuotation = DateTime.Now,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Modifier = 1,
                Creator = 1
            };
        }
    }
}
