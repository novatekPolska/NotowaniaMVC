using NHibernate;
using NotowaniaMVC.Domain.DomainEntities;
using NotowaniaMVC.Domain.Quotation.Validators;
using NUnit.Framework;
using System;


namespace NotowaniaMVC.Tests.NotowaniaMVC.Domain.Tests.Quotations.Validator
{
    [TestFixture]
    public class QuotationValidatorTests
    {
        QuotationValidator quotationValidator;
        private TestContext testContextInstance;
         
        public QuotationValidatorTests()
        {
            quotationValidator = new QuotationValidator();
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

        //todo dodać testy dla kluczy obcych

        public Quotation CreateFakeQuotation(DateTime dateOfQuotation, int fuel, decimal priceNettoMax, decimal priceNettoMin, int unit, int currency, int quotationType)
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
