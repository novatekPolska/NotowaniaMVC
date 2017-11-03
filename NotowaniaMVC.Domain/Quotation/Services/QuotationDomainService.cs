using NotowaniaMVC.Domain.Quotation.Interfaces;
using NotowaniaMVC.Domain.DomainEntities;
using NotowaniaMVC.Infrastructure.Common.Interfaces;
using NotowaniaMVC.Domain.Quotation.Validators;
using NotowaniaMVC.Infrastructure.Database.Entities;

namespace NotowaniaMVC.Domain.Quotation.Services
{
    public class QuotationDomainService : IQuotationDomainService
    {
        private readonly INHibernateUniversalRepository<XXX_R55_Quotations> _nHibernateUniversalRepository;
        public QuotationDomainService(INHibernateUniversalRepository<XXX_R55_Quotations> nHibernateUniversalRepository)
        {
            _nHibernateUniversalRepository = nHibernateUniversalRepository;
        }

        public void AddNewQuotation(DomainEntities.Quotation quotation)
        {
            QuotationValidator validator = new QuotationValidator();
            var validationResult = validator.Validate(quotation);
            var objectToAdd = XXX_R55_Quotations.Factory.Create(quotation.PriceMin, quotation.PriceMax, quotation.DateOfQuotation);
         //   if (validationResult.IsValid)
                _nHibernateUniversalRepository.Create(objectToAdd);
          //  else throw new System.Exception("błędy walidacji");
        }
    }
}
