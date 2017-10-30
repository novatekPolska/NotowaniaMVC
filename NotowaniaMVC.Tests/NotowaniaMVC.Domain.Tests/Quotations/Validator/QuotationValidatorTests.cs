using NHibernate;
using NotowaniaMVC.Domain.DomainEntities;
using NotowaniaMVC.Domain.Quotation.Validators;
using NotowaniaMVC.Infrastructure.Database.DBConfiguration;
using NotowaniaMVC.Infrastructure.Database.Entities;
using NotowaniaMVC.Infrastructure.Database.ExistingEntities;
using NUnit.Framework;
using System; 
 
namespace NotowaniaMVC.Tests.NotowaniaMVC.Domain.Tests.Quotations.Validator
{
    [TestFixture]
    public class QuotationValidatorTests
    {
        QuotationValidator quotationValidator;
        private TestContext testContextInstance;
        ISession session;
        DatabaseConfiguration dbConfiguration;


        public QuotationValidatorTests()
        {
            quotationValidator = new QuotationValidator();
            dbConfiguration = new DatabaseConfiguration();
            session = dbConfiguration.GetSession();
        }

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
        public void when_validate_correct_quotation_then_method_should_not_return_error()
        {
            DateTime date = DateTime.Now;
            date = date.AddDays(-1);
            var fakeQuotationObject = CreateFakeQuotation(date, 1, 10, 5, 1, 1, 1);
            var validationResult = quotationValidator.Validate(fakeQuotationObject);

            Assert.AreEqual(validationResult.IsValid, true);
        }

        [Test]
        public void when_price_min_is_less_than_0_then_validator_should_return_error()
        {
            DateTime date = DateTime.Now;
            date = date.AddDays(-1);
            var fakeQuotationObject = CreateFakeQuotation(date, 1, 10, -5, 1, 1, 1);
            var validationResult = quotationValidator.Validate(fakeQuotationObject);

            Assert.AreEqual(validationResult.IsValid, false);
        }

        [Test]
        public void when_price_max_is_less_than_0_then_validator_should_return_error()
        {
            DateTime date = DateTime.Now;
            date = date.AddDays(-1);
            var fakeQuotationObject = CreateFakeQuotation(date, 1, -10, 5, 1, 1, 1);
            var validationResult = quotationValidator.Validate(fakeQuotationObject);

            Assert.AreEqual(validationResult.IsValid, false);
        }

        [Test]
        public void when_price_max_is_less_then_price_min_then_validator_should_return_error()
        {
            DateTime date = DateTime.Now;
            date = date.AddDays(-1);
            var fakeQuotationObject = CreateFakeQuotation(date, 1, 10, 15, 1, 1, 1);
            var validationResult = quotationValidator.Validate(fakeQuotationObject);

            Assert.AreEqual(validationResult.IsValid, false);
        }  

        [Test]
        public void when_date_of_quotation_is_not_less_than_now_then_validator_should_return_error()
        {
            DateTime date = DateTime.Now;
            date = date.AddDays(1);
            var fakeQuotationObject = CreateFakeQuotation(date, 1, 10, 5, 1, 1, 1);
            var validationResult = quotationValidator.Validate(fakeQuotationObject);

            Assert.AreEqual(validationResult.IsValid, false);
        }

        [Test]
        public void when_price_min_is_equal_to_0_then_validator_should_return_error()
        {
            DateTime date = DateTime.Now;
            date = date.AddDays(-1);
            var fakeQuotationObject = CreateFakeQuotation(date, 1, 10, 0, 1, 1, 1);
            var validationResult = quotationValidator.Validate(fakeQuotationObject);

            Assert.AreEqual(validationResult.IsValid, false);
        }

        [Test]
        public void when_price_max_is_equal_to_0_then_validator_should_return_error()
        {
            DateTime date = DateTime.Now;
            date = date.AddDays(-1);
            var fakeQuotationObject = CreateFakeQuotation(date, 1, 0, 5, 1, 1, 1);
            var validationResult = quotationValidator.Validate(fakeQuotationObject);

            Assert.AreEqual(validationResult.IsValid, false);
        } 

        [Test]
        public void when_date_of_quotation_is_null_then_validator_should_return_error()
        { 
            var fakeQuotationObject = CreateFakeQuotation(new DateTime(), 1, 10, 5, 1, 1, 1);
            var validationResult = quotationValidator.Validate(fakeQuotationObject);

            Assert.AreEqual(validationResult.IsValid, false);
        }
          
        [Test]
        public void when_unit_is_0_then_validator_should_return_error()
        {
            DateTime date = DateTime.Now;
            date = date.AddDays(-1);
            var fakeQuotationObject = CreateFakeQuotation(date, 1, 10, 5, 0, 1, 1);
            var validationResult = quotationValidator.Validate(fakeQuotationObject);

            Assert.AreEqual(validationResult.IsValid, false);
        } 

        [Test]
        public void when_currency_is_0_then_validator_should_return_error()
        {
            DateTime date = DateTime.Now;
            date = date.AddDays(-1);
            var fakeQuotationObject = CreateFakeQuotation(date, 1, 10, 5, 1, 0, 1);
            var validationResult = quotationValidator.Validate(fakeQuotationObject);

            Assert.AreEqual(validationResult.IsValid, false);
        } 

        [Test]
        public void when_fuel_type_is_0_then_validator_should_return_error()
        {
            DateTime date = DateTime.Now;
            date = date.AddDays(-1);
            var fakeQuotationObject = CreateFakeQuotation(date, 0, 10, 5, 1, 1, 1);
            var validationResult = quotationValidator.Validate(fakeQuotationObject);

            Assert.AreEqual(validationResult.IsValid, false);
        } 

        [Test]
        public void when_quotation_type_is_0_then_validator_should_return_error()
        {
            DateTime date = DateTime.Now;
            date = date.AddDays(-1);
            var fakeQuotationObject = CreateFakeQuotation(date, 1, 10, 5, 1, 1, 0);
            var validationResult = quotationValidator.Validate(fakeQuotationObject);

            Assert.AreEqual(validationResult.IsValid, false); 
        }

        [Test]
        public void when_type_of_quotation_FK_does_not_exist_then_validator_should_return_error()
        {
            int id = 0;
            using (var transaction = session.BeginTransaction())
            {
                DateTime date = DateTime.Now;
                date = date.AddDays(-1);

                session.Save(new Waluta { Bilon = "test", Krotnosc = 1, Skrot = "test", Wydruk = "test", Symbol = "test", waluta = "test", Walutapodstawowa = true });
                session.Save(new XXX_R55_Units { Name = "test", Code = "test", Guid = new Guid() });
                session.Save(new XXX_R55_FuelTypes { Name = "test", Code = "test", Guid = new Guid() });
                var obj  = session.Save(new XXX_R55_QuotationTypes { Name = "test", Code = "test", Guid = new Guid() });

                id = (int)obj; 
                if (id != 0) id = id + 1;

                var fakeQuotationObject = CreateFakeQuotation(date, 1, 10, 5, 1, 1, id);
                var validationResult = quotationValidator.Validate(fakeQuotationObject);

                Assert.AreEqual(validationResult.IsValid, false);
                transaction.Rollback();
            }
        }

        [Test]
        public void when_type_of_quotation_FK_exists_then_validator_should_not_return_error()
        {
            int id = 0;
            using (var transaction = session.BeginTransaction())
            {
                DateTime date = DateTime.Now;
                date = date.AddDays(-1);

                session.Save(new Waluta { Bilon = "test", Krotnosc = 1, Skrot = "test", Wydruk = "test", Symbol = "test", waluta = "test", Walutapodstawowa = true });
                session.Save(new XXX_R55_Units { Name = "test", Code = "test", Guid = new Guid() });
                session.Save(new XXX_R55_FuelTypes { Name = "test", Code = "test", Guid = new Guid() });
                var obj = session.Save(new XXX_R55_QuotationTypes { Name = "test", Code = "test", Guid = new Guid() });

                id = (int)obj; 

                var fakeQuotationObject = CreateFakeQuotation(date, 1, 10, 5, 1, 1, id);
                var validationResult = quotationValidator.Validate(fakeQuotationObject);

                Assert.AreEqual(validationResult.IsValid, true);
                transaction.Rollback();
            }
        }

        [Test]
        public void when_fuel_type_FK_does_not_exist_then_validator_should_return_error()
        {
            int id = 0;
            using (var transaction = session.BeginTransaction())
            {
                DateTime date = DateTime.Now;
                date = date.AddDays(-1);

                session.Save(new Waluta { Bilon = "test", Krotnosc = 1, Skrot = "test", Wydruk = "test", Symbol = "test", waluta = "test", Walutapodstawowa = true });
                session.Save(new XXX_R55_Units { Name = "test", Code = "test", Guid = new Guid() });
                session.Save(new XXX_R55_QuotationTypes { Name = "test", Code = "test", Guid = new Guid() });
                var obj = session.Save(new XXX_R55_FuelTypes { Name = "test", Code = "test", Guid = new Guid() });

                id = (int)obj;
                if (id != 0) id = id + 1;

                var fakeQuotationObject = CreateFakeQuotation(date, id, 10, 5, 1, 1, 1);
                var validationResult = quotationValidator.Validate(fakeQuotationObject);

                Assert.AreEqual(validationResult.IsValid, false);
                transaction.Rollback();
            }
        }

        [Test]
        public void when_fuel_type_FK_exists_then_validator_should_not_return_error()
        {
            int id = 0;
            using (var transaction = session.BeginTransaction())
            {
                DateTime date = DateTime.Now;
                date = date.AddDays(-1);

                session.Save(new Waluta { Bilon = "test", Krotnosc = 1, Skrot = "test", Wydruk = "test", Symbol = "test", waluta = "test", Walutapodstawowa = true });
                session.Save(new XXX_R55_Units { Name = "test", Code = "test", Guid = new Guid() });
                session.Save(new XXX_R55_QuotationTypes { Name = "test", Code = "test", Guid = new Guid() });
                var obj = session.Save(new XXX_R55_FuelTypes { Name = "test", Code = "test", Guid = new Guid() });

                id = (int)obj; 

                var fakeQuotationObject = CreateFakeQuotation(date, id, 10, 5, 1, 1, 1);
                var validationResult = quotationValidator.Validate(fakeQuotationObject);

                Assert.AreEqual(validationResult.IsValid, true);
                transaction.Rollback();
            }
        }

        [Test]
        public void when_currency_FK_does_not_exist_then_validator_should_return_error()
        {
            int id = 0;
            using (var transaction = session.BeginTransaction())
            {
                DateTime date = DateTime.Now;
                date = date.AddDays(-1);

                session.Save(new Waluta { Bilon = "test", Krotnosc = 1, Skrot = "test", Wydruk = "test", Symbol = "test", waluta = "test", Walutapodstawowa = true });
                session.Save(new XXX_R55_QuotationTypes { Name = "test", Code = "test", Guid = new Guid() });
                session.Save(new XXX_R55_FuelTypes { Name = "test", Code = "test", Guid = new Guid() }); 
                var obj = session.Save(new XXX_R55_Units { Name = "test", Code = "test", Guid = new Guid() });

                id = (int)obj;
                if (id != 0) id = id + 1;

                var fakeQuotationObject = CreateFakeQuotation(date, 1, 10, 5, id, 1, 1);
                var validationResult = quotationValidator.Validate(fakeQuotationObject);

                Assert.AreEqual(validationResult.IsValid, false);
                transaction.Rollback();
            }
        }

        [Test]
        public void when_currency_FK_exists_then_validator_should_not_return_error()
        {
            int id = 0;
            using (var transaction = session.BeginTransaction())
            {
                DateTime date = DateTime.Now;
                date = date.AddDays(-1);

                session.Save(new Waluta { Bilon = "test", Krotnosc = 1, Skrot = "test", Wydruk = "test", Symbol = "test", waluta = "test", Walutapodstawowa = true });
                session.Save(new XXX_R55_QuotationTypes { Name = "test", Code = "test", Guid = new Guid() });
                session.Save(new XXX_R55_FuelTypes { Name = "test", Code = "test", Guid = new Guid() });
                var obj = session.Save(new XXX_R55_Units { Name = "test", Code = "test", Guid = new Guid() });

                id = (int)obj; 

                var fakeQuotationObject = CreateFakeQuotation(date, 1, 10, 5, id, 1, 1);
                var validationResult = quotationValidator.Validate(fakeQuotationObject);

                Assert.AreEqual(validationResult.IsValid, true);
                transaction.Rollback();
            }
        }

        [Test]
        public void when_unit_FK_does_not_exist_then_validator_should_return_error()
        {
            int id = 0;
            using (var transaction = session.BeginTransaction())
            {
                DateTime date = DateTime.Now;
                date = date.AddDays(-1);

                session.Save(new XXX_R55_QuotationTypes { Name = "test", Code = "test", Guid = new Guid() });
                session.Save(new XXX_R55_FuelTypes { Name = "test", Code = "test", Guid = new Guid() });
                session.Save(new XXX_R55_Units { Name = "test", Code = "test", Guid = new Guid() });
                var obj = session.Save(new Waluta {  Bilon = "test", Krotnosc = 1, Skrot= "test", Wydruk = "test", Symbol = "test", waluta = "test", Walutapodstawowa = true });

                id = (int)obj;
                if (id != 0) id = id + 1;

                var fakeQuotationObject = CreateFakeQuotation(date, 1, 10, 5, id, 1, 1);
                var validationResult = quotationValidator.Validate(fakeQuotationObject);

                Assert.AreEqual(validationResult.IsValid, false);
                transaction.Rollback();
            }
        }

        [Test]
        public void when_unit_FK_exists_then_validator_should_not_return_error()
        {
            int id = 0;
            using (var transaction = session.BeginTransaction())
            {
                DateTime date = DateTime.Now;
                date = date.AddDays(-1);

                session.Save(new XXX_R55_QuotationTypes { Name = "test", Code = "test", Guid = new Guid() });
                session.Save(new XXX_R55_FuelTypes { Name = "test", Code = "test", Guid = new Guid() });
                session.Save(new XXX_R55_Units { Name = "test", Code = "test", Guid = new Guid() });
                var obj = session.Save(new Waluta { Bilon = "test", Krotnosc = 1, Skrot = "test", Wydruk = "test", Symbol = "test", waluta = "test", Walutapodstawowa = true });

                id = (int)obj; 

                var fakeQuotationObject = CreateFakeQuotation(date, 1, 10, 5, id, 1, 1);
                var validationResult = quotationValidator.Validate(fakeQuotationObject);

                Assert.AreEqual(validationResult.IsValid, true);
                transaction.Rollback();
            }
        }

        //todo dodać testy dla kluczy obcych

        private Quotation CreateFakeQuotation(DateTime dateOfQuotation, int fuel, decimal priceNettoMax, decimal priceNettoMin, int unit, int currency, int quotationType)
        {
            return Quotation.Factory.Create(dateOfQuotation,
            fuel,
            priceNettoMin,
            priceNettoMax, 
            unit,
            currency,
            quotationType);
        }   
    }
}
