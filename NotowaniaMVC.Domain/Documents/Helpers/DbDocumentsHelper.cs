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
        public DbDocumentsHelper(INHibernateUniversalRepository<XXX_R55_Documents> nHibernateUniversalRepository)
        {
            _nHibernateUniversalRepository = nHibernateUniversalRepository;
        }

        public ValidationResult SaveDocumentToDb(Document document)
        {
            DocumentValidator validator = new DocumentValidator();
            var result = validator.Validate(document);
            if (result.IsValid)
            {
                //todo automapper
                var documentToAdd = XXX_R55_Documents.Factory.Create(document.Name, document.Guid, document.Code, document.Link, document.Created, document.Modified, document.Creator, document.Modifier);
                _nHibernateUniversalRepository.Create(documentToAdd);
            } 
            return result;
        }


    }
}
