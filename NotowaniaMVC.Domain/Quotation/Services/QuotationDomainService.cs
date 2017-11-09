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
        private readonly IQuotationToQuotationDbMapper _quotationMapper;

        public QuotationDomainService(INHibernateUniversalRepository<XXX_R55_Quotations> nHibernateQuotationUniversalRepository, 
            INHibernateUniversalRepository<XXX_R55_Documents> nHibernateDocumentUniversalRepository,
            IQuotationToQuotationDbMapper quotationMapper)
        {
            _nHibernateQuotationUniversalRepository = nHibernateQuotationUniversalRepository;
            _nHibernateDocumentUniversalRepository = nHibernateDocumentUniversalRepository;
            _quotationValidator = new QuotationValidator();
            _quotationMapper = quotationMapper;
        }

        public int AddNewQuotation(DomainEntities.Quotation quotation)
        { 
            var validationResult = _quotationValidator.Validate(quotation);
            var objectToAdd = _quotationMapper.Map(quotation); 
            if (validationResult.IsValid)
                _nHibernateQuotationUniversalRepository.Create(objectToAdd);
            else throw new System.Exception("błędy walidacji");
            return objectToAdd.Id;
        }

        public void AddDocumentToQuotation(int quotationId, int documentId)
        {
            var quotationDb = _nHibernateQuotationUniversalRepository.GetById(quotationId);
            quotationDb.Document = new XXX_R55_Documents { Id = documentId };
            _nHibernateQuotationUniversalRepository.Update(quotationDb); 
        }
    }
}
