using NotowaniaMVC.Domain.Quotation.Interfaces; 
using NotowaniaMVC.Infrastructure.Common.Interfaces;
using NotowaniaMVC.Domain.Quotation.Validators;
using NotowaniaMVC.Infrastructure.Database.Entities;

namespace NotowaniaMVC.Domain.Quotation.Services
{
    public class QuotationDomainService : IQuotationDomainService
    {
        private readonly INHibernateUniversalRepository<XXX_R55_Quotations> _nHibernateQuotationUniversalRepository;
        private readonly INHibernateUniversalRepository<XXX_R55_Documents> _nHibernateDocumentUniversalRepository;
        private readonly QuotationValidator _quotationValidator;

        public QuotationDomainService(INHibernateUniversalRepository<XXX_R55_Quotations> nHibernateQuotationUniversalRepository, INHibernateUniversalRepository<XXX_R55_Documents> nHibernateDocumentUniversalRepository)
        {
            _nHibernateQuotationUniversalRepository = nHibernateQuotationUniversalRepository;
            _nHibernateDocumentUniversalRepository = nHibernateDocumentUniversalRepository;
            _quotationValidator = new QuotationValidator();
        }

        public void AddNewQuotation(DomainEntities.Quotation quotation)
        { 
            var validationResult = _quotationValidator.Validate(quotation);
            var objectToAdd = XXX_R55_Quotations.Factory.Create(quotation.PriceMin, quotation.PriceMax, quotation.DateOfQuotation);
            if (validationResult.IsValid)
                _nHibernateQuotationUniversalRepository.Create(objectToAdd);
            else throw new System.Exception("błędy walidacji");
        }

        public void AddDocumentToQuotation(DomainEntities.Quotation quotation, int documentId)
        {
            quotation.SetDocumentId(documentId);
            var validationResult = _quotationValidator.Validate(quotation);
            //var quotationDb;// = XXX_R55_Quotations.Factory.Create
   
            //_nHibernateQuotationUniversalRepository.Update(quotationDb);
        }
    }
}
