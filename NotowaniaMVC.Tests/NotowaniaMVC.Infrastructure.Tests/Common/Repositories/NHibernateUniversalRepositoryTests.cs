using NHibernate;
using NotowaniaMVC.Infrastructure.Common.Repositories;
using NotowaniaMVC.Infrastructure.Database.DBConfiguration;
using NotowaniaMVC.Infrastructure.Database.Entities;
using NUnit.Framework;
using System;

namespace NotowaniaMVC.Tests.NotowaniaMVC.Infrastructure.Tests.Common.Repositories
{
    [TestFixture]
    public class NHibernateUniversalRepositoryTests
    {
        NHibernateUniversalRepository<XXX_R55_Quotations> nHibernateUniversalRepositoryQuotation;
        NHibernateUniversalRepository<XXX_R55_PriceLists> nHibernateUniversalRepositoryPriceLists;
        ISession session;
        DatabaseConfiguration dbConfiguratrion;
         
        public NHibernateUniversalRepositoryTests()
        {
            dbConfiguratrion = new DatabaseConfiguration();
            session = dbConfiguratrion.GetSession();
            nHibernateUniversalRepositoryQuotation = new NHibernateUniversalRepository<XXX_R55_Quotations>(session);
            nHibernateUniversalRepositoryPriceLists = new NHibernateUniversalRepository<XXX_R55_PriceLists>(session);
        }

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [Test]
        public void Can_Add_New_Quotation()
        {
            using (var transaction = session.BeginTransaction())
            {
                var quotation = CreateFakeQuotationObject(); 

                nHibernateUniversalRepositoryQuotation.Create(quotation); 

                Assert.AreNotEqual(quotation.Id, 0); 
                transaction.Rollback();
            }
        }
         
        [Test]
        public void Can_Update_Quotation()
        {
            using (var transaction = session.BeginTransaction())
            {
                var objectGuid = new Guid();
                var quotation = CreateFakeQuotationObject();
                objectGuid = quotation.Guid;

                nHibernateUniversalRepositoryQuotation.Create(quotation); 
                var addedObject = nHibernateUniversalRepositoryQuotation.GetByGuid(objectGuid); 
                addedObject.Modifier = 2; 
                nHibernateUniversalRepositoryQuotation.Update(addedObject); 
                var modifiedObject = nHibernateUniversalRepositoryQuotation.GetByGuid(objectGuid);

                Assert.AreEqual(modifiedObject.Modifier, 2); 
                Assert.AreEqual(addedObject.Id, modifiedObject.Id);
                Assert.AreNotEqual(addedObject.Modified, modifiedObject.Modified);
                Assert.AreEqual(addedObject.PriceList, modifiedObject.PriceList);
                Assert.AreEqual(addedObject.Region, modifiedObject.Region);
                Assert.AreEqual(addedObject.Guid, modifiedObject.Guid);
                Assert.AreEqual(addedObject.Fuel, modifiedObject.Fuel);
                Assert.AreEqual(addedObject.Creator, modifiedObject.Creator);
                Assert.AreEqual(addedObject.Created, modifiedObject.Created);
                Assert.AreEqual(addedObject.Company, modifiedObject.Company);
                Assert.AreEqual(addedObject.Code, modifiedObject.Code); 
                transaction.Rollback();
            }
        }

        [Test]
        public void Can_Delete_Quotation()
        {
            using (var transaction = session.BeginTransaction())
            {
                var objectGuid = new Guid();
                var quotationObject = CreateFakeQuotationObject();
                objectGuid = quotationObject.Guid;
                nHibernateUniversalRepositoryQuotation.Create(quotationObject);

                var addedObject = nHibernateUniversalRepositoryQuotation.GetByGuid(objectGuid);

                if (addedObject is null)
                {
                    throw new Exception("Nie udalo się dodać obiektu, więc nie ma co usuwać");
                }
                else
                {
                    nHibernateUniversalRepositoryQuotation.DeleteByGuid(objectGuid);
                    var deletedObject = nHibernateUniversalRepositoryQuotation.GetByGuid(objectGuid);
                    Assert.AreEqual(deletedObject, null);
                }

                transaction.Rollback();
            }
        }

        [Test]
        public void Can_Get_Quotation_By_Id()
        {
            using (var transaction = session.BeginTransaction())
            {
                var quotationObject = CreateFakeQuotationObject();
                nHibernateUniversalRepositoryQuotation.Create(quotationObject);

                var objectId = quotationObject.Id;

                if (objectId == 0)
                    throw new Exception("Nie udało się dodać do bazy więc nie ma co z niej wywlekać");
                else
                { 
                    var addedObject = nHibernateUniversalRepositoryQuotation.GetById(objectId);

                    Assert.AreEqual(quotationObject.Id, addedObject.Id);
                    Assert.AreEqual(quotationObject.Modified, addedObject.Modified);
                    Assert.AreEqual(quotationObject.Modifier, addedObject.Modifier);
                    Assert.AreEqual(quotationObject.PriceList, addedObject.PriceList);
                    Assert.AreEqual(quotationObject.Region, addedObject.Region);
                    Assert.AreEqual(quotationObject.Guid, addedObject.Guid);
                    Assert.AreEqual(quotationObject.Fuel, addedObject.Fuel);
                    Assert.AreEqual(quotationObject.Creator, addedObject.Creator);
                    Assert.AreEqual(quotationObject.Created, addedObject.Created);
                    Assert.AreEqual(quotationObject.Company, addedObject.Company);
                    Assert.AreEqual(quotationObject.Code, addedObject.Code); 
                }
                transaction.Rollback();
            }
        }

        [Test]
        public void Can_Get_Quotation_By_Guid()
        {
            using (var transaction = session.BeginTransaction())
            {  
                    var quotationObject = CreateFakeQuotationObject();

                    var objectGuid = quotationObject.Guid;
                    var objectId = quotationObject.Id;
                    nHibernateUniversalRepositoryQuotation.Create(quotationObject);
                     
                    if (objectId == 0)
                        throw new Exception("Nie udało się dodać do bazy więc nie ma co z niej wywlekać");
                    else
                    {
                        var addedObject = nHibernateUniversalRepositoryQuotation.GetByGuid(objectGuid);

                        Assert.AreEqual(quotationObject.Id, addedObject.Id);
                        Assert.AreEqual(quotationObject.Modified, addedObject.Modified);
                        Assert.AreEqual(quotationObject.Modifier, addedObject.Modifier);
                        Assert.AreEqual(quotationObject.PriceList, addedObject.PriceList);
                        Assert.AreEqual(quotationObject.Region, addedObject.Region);
                        Assert.AreEqual(quotationObject.Guid, addedObject.Guid);
                        Assert.AreEqual(quotationObject.Fuel, addedObject.Fuel);
                        Assert.AreEqual(quotationObject.Creator, addedObject.Creator);
                        Assert.AreEqual(quotationObject.Created, addedObject.Created);
                        Assert.AreEqual(quotationObject.Company, addedObject.Company);
                        Assert.AreEqual(quotationObject.Code, addedObject.Code);
                    }
                    transaction.Rollback(); 
            }
        }

        [Test]
        public void Can_Add_New_Quotation_With_Price_List()
        {
            using (var transaction = session.BeginTransaction())
            {

                transaction.Rollback();
            }
        }

        [Test]
        public void Can_Add_New_PriceList()
        {
            using (var transaction = session.BeginTransaction())
            {

                transaction.Rollback();
            }
        }
          
        [Test]
        public void Can_Update_PriceList()
        {
            using (var transaction = session.BeginTransaction())
            {

                transaction.Rollback();
            }
        }
          
        //Docelowo istniejące obiekty będziemy usuwać 
        //"swiadomie". Tzn sprawdzac wszelkie zależnosci. Usuwanie = zmiana statusu, odpowiednia informacja dla 
        //uzytkownika ze są powiązania z zapytaniem czy chce, a jesli chce to musi wiedziec co przy okazji zostanie usuniete. 
        //Nie będziemy fizycznie usuwać rekordow, a jedynie zmieniąc flagę "deleted". Taka metoda potrzebna nam np do słowników 
        //czyli np jakiegos słownika statusów/ról użytkownika które beda w module administracyjnym, albo jesli zdecydujemy się np 
        //na archiwizacje danych. Czemu? Wyobraźmy sobie ze uzytkownik cos usunie niechcący i poprosi o odzyskanie danych...
        //albo inaczej - usunie cos do czego mamy jakies klucze obce - dostanie wyjątkami po oczach, a tego nie chcemy
        [Test]
        public void Can_Delete_PriceList() 
        {
            using (var transaction = session.BeginTransaction())
            {

                transaction.Rollback();
            }
        }

        [Test]
        public void Can_Get_PriceList_By_Id()
        {
            using (var transaction = session.BeginTransaction())
            {

                transaction.Rollback();
            }
        }
         
        [Test]
        public void Can_Get_PriceList_By_Guid()
        {
            using (var transaction = session.BeginTransaction())
            {

                transaction.Rollback();
            }
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
