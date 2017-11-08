using FluentValidation.Results;
using NotowaniaMVC.Domain.Documents.Interfaces;
using NotowaniaMVC.Domain.Documents.Validators;
using NotowaniaMVC.Domain.DomainEntities;
using NotowaniaMVC.Infrastructure.Common.Interfaces;
using NotowaniaMVC.Infrastructure.Database.Entities; 

namespace NotowaniaMVC.Domain.Documents.Helpers
{
    public class DbDocumentsHelper : IDbDocumentHelper
    {
        private readonly INHibernateUniversalRepository<XXX_R55_Documents> _nHibernateUniversalRepository;
        private readonly IDocumentToDocumentDbMapper _documentMapper;

        public DbDocumentsHelper(INHibernateUniversalRepository<XXX_R55_Documents> nHibernateUniversalRepository, IDocumentToDocumentDbMapper documentMapper)
        {
            _nHibernateUniversalRepository = nHibernateUniversalRepository;
            _documentMapper = documentMapper;
        }

        public ValidationResult SaveDocumentToDb(Document document)
        {
            DocumentValidator validator = new DocumentValidator();
            var result = validator.Validate(document);
            if (result.IsValid)
            { 
                var documentToAdd = _documentMapper.Map(document); 
                _nHibernateUniversalRepository.Create(documentToAdd);
            } 
            return result;
        }


    }
}
