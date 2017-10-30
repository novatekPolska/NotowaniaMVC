using NHibernate; 
using NotowaniaMVC.Infrastructure.Common.Repositories;
using NotowaniaMVC.Infrastructure.Database.DBConfiguration;
using NotowaniaMVC.Infrastructure.Database.Entities;
using NotowaniaMVC.Infrastructure.Database.ExistingEntities;
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
        DatabaseConfiguration dbConfiguration;
         
        //todo rozbic na osobne klasy dla osobnych encji
        public NHibernateUniversalRepositoryTests()
        {
            dbConfiguration = new DatabaseConfiguration();
            session = dbConfiguration.GetSession();
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
        public void when_add_new_quotation_then_database_should_have_new_quotation_with_correct_properties()
        {
            using (var transaction = session.BeginTransaction())
            {
                var quotation = CreateFakeQuotationObject(); 
                nHibernateUniversalRepositoryQuotation.Create(quotation);

                Assert.AreNotEqual(quotation.Id, 0);
                var id = quotation.Id;

                var addedObject = nHibernateUniversalRepositoryQuotation.GetById(id);

                Assert.AreEqual(quotation.Id, addedObject.Id);
                Assert.AreEqual(quotation.PriceMax, addedObject.PriceMax);
                Assert.AreEqual(quotation.PriceMin, addedObject.PriceMin);
                Assert.AreEqual(quotation.DateOfQuotation, addedObject.DateOfQuotation);
                Assert.AreEqual(quotation.Code, addedObject.Code);
                Assert.AreEqual(quotation.DateTo, addedObject.DateTo);
                Assert.AreEqual(quotation.Guid, addedObject.Guid);
                Assert.AreEqual(quotation.Created, addedObject.Created);
                Assert.AreEqual(quotation.Creator, addedObject.Creator);
                Assert.AreEqual(quotation.Modified, addedObject.Modified);
                Assert.AreEqual(quotation.Modifier, addedObject.Modifier);

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
        public void Can_Add_New_PriceList()
        {
            using (var transaction = session.BeginTransaction())
            {
                var priceList = CreateFakePriceListObject();

                nHibernateUniversalRepositoryPriceLists.Create(priceList);

                Assert.AreNotEqual(priceList.Id, 0);
                transaction.Rollback(); 
            }
        }
          
        [Test]
        public void Can_Update_PriceList()
        {
            using (var transaction = session.BeginTransaction())
            {
                var objectGuid = new Guid();
                var priceList = CreateFakePriceListObject();
                objectGuid = priceList.Guid;

                nHibernateUniversalRepositoryPriceLists.Create(priceList);
                var addedObject = nHibernateUniversalRepositoryPriceLists.GetByGuid(objectGuid);
                addedObject.Modifier = 2;
                nHibernateUniversalRepositoryPriceLists.Update(addedObject);
                var modifiedObject = nHibernateUniversalRepositoryPriceLists.GetByGuid(objectGuid);

                Assert.AreEqual(modifiedObject.Modifier, 2);
                Assert.AreEqual(addedObject.Id, modifiedObject.Id);
                Assert.AreNotEqual(addedObject.Modified, modifiedObject.Modified);  
                Assert.AreEqual(addedObject.Guid, modifiedObject.Guid); 
                Assert.AreEqual(addedObject.Creator, modifiedObject.Creator);
                Assert.AreEqual(addedObject.Created, modifiedObject.Created); 
                Assert.AreEqual(addedObject.Code, modifiedObject.Code);
                Assert.AreEqual(addedObject.PriceMin, modifiedObject.PriceMin);
                Assert.AreEqual(addedObject.PriceMax, modifiedObject.PriceMax);
                Assert.AreEqual(addedObject.Unit, modifiedObject.Unit);
                Assert.AreEqual(addedObject.Currency, modifiedObject.Currency);
                Assert.AreEqual(addedObject.DateOfQuotation, modifiedObject.DateOfQuotation);
                Assert.AreEqual(addedObject.DateTo, modifiedObject.DateTo); 

                transaction.Rollback();
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
                var objectGuid = new Guid();
                var priceListObject = CreateFakePriceListObject();
                objectGuid = priceListObject.Guid;
                nHibernateUniversalRepositoryPriceLists.Create(priceListObject);

                var addedObject = nHibernateUniversalRepositoryPriceLists.GetByGuid(objectGuid);

                if (addedObject is null)
                {
                    throw new Exception("Nie udalo się dodać obiektu, więc nie ma co usuwać");
                }
                else
                {
                    nHibernateUniversalRepositoryPriceLists.DeleteByGuid(objectGuid);
                    var deletedObject = nHibernateUniversalRepositoryPriceLists.GetByGuid(objectGuid);
                    Assert.AreEqual(deletedObject, null);
                }

                transaction.Rollback();
            }
        }

        [Test]
        public void Can_Get_PriceList_By_Id()
        {
            using (var transaction = session.BeginTransaction())
            {
                var priceListObject = CreateFakePriceListObject();
                nHibernateUniversalRepositoryPriceLists.Create(priceListObject);

                var objectId = priceListObject.Id;

                if (objectId == 0)
                    throw new Exception("Nie udało się dodać do bazy więc nie ma co z niej wywlekać");
                else
                {
                    var addedObject = nHibernateUniversalRepositoryPriceLists.GetById(objectId);

                    Assert.AreEqual(priceListObject.Id, addedObject.Id);
                    Assert.AreEqual(priceListObject.Guid, addedObject.Guid);
                    Assert.AreEqual(priceListObject.Creator, addedObject.Creator);
                    Assert.AreEqual(priceListObject.Created, addedObject.Created);
                    Assert.AreEqual(priceListObject.Code, addedObject.Code);
                    Assert.AreEqual(priceListObject.PriceMin, addedObject.PriceMin);
                    Assert.AreEqual(priceListObject.PriceMax, addedObject.PriceMax);
                    Assert.AreEqual(priceListObject.Unit, addedObject.Unit);
                    Assert.AreEqual(priceListObject.Currency, addedObject.Currency);
                    Assert.AreEqual(priceListObject.DateOfQuotation, addedObject.DateOfQuotation);
                    Assert.AreEqual(priceListObject.DateTo, addedObject.DateTo);
                    Assert.AreEqual(priceListObject.Modified, addedObject.Modified);
                    Assert.AreEqual(priceListObject.Modifier, addedObject.Modifier);
                }
                transaction.Rollback();
            }
        }
         
        [Test]
        public void Can_Get_PriceList_By_Guid()
        {
            using (var transaction = session.BeginTransaction())
            {
                var priceListObject = CreateFakePriceListObject();

                var objectGuid = priceListObject.Guid;
                var objectId = priceListObject.Id;
                nHibernateUniversalRepositoryPriceLists.Create(priceListObject);

                if (objectId == 0)
                    throw new Exception("Nie udało się dodać do bazy więc nie ma co z niej wywlekać");
                else
                {
                    var addedObject = nHibernateUniversalRepositoryPriceLists.GetByGuid(objectGuid);

                    Assert.AreEqual(priceListObject.Id, addedObject.Id);
                    Assert.AreEqual(priceListObject.Guid, addedObject.Guid);
                    Assert.AreEqual(priceListObject.Creator, addedObject.Creator);
                    Assert.AreEqual(priceListObject.Created, addedObject.Created);
                    Assert.AreEqual(priceListObject.Code, addedObject.Code);
                    Assert.AreEqual(priceListObject.PriceMin, addedObject.PriceMin);
                    Assert.AreEqual(priceListObject.PriceMax, addedObject.PriceMax);
                    Assert.AreEqual(priceListObject.Unit, addedObject.Unit);
                    Assert.AreEqual(priceListObject.Currency, addedObject.Currency);
                    Assert.AreEqual(priceListObject.DateOfQuotation, addedObject.DateOfQuotation);
                    Assert.AreEqual(priceListObject.DateTo, addedObject.DateTo);
                    Assert.AreEqual(priceListObject.Modified, addedObject.Modified);
                    Assert.AreEqual(priceListObject.Modifier, addedObject.Modifier);
                }
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
                Creator = 1,
                DateTo = DateTime.Now,
                DateOfQuotation = DateTime.Now,
                PriceMax = 10,
                PriceMin = 10
                //Unit = new XXX_R55_Units { Id = 1 },
                //Currency = new Waluta { Id_waluta = 1 },
                //Fuel = new XXX_R55_Fuels { Id = 1 },
                //Region = new XXX_R55_Regions { Id = 1 },
                //Company = new XXX_R55_Companies { Id = 1 } 
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
