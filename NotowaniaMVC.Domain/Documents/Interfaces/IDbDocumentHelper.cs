using FluentValidation.Results;
using NotowaniaMVC.Domain.DomainEntities; 

namespace NotowaniaMVC.Domain.Documents.Interfaces
{
    public interface IDbDocumentHelper
    {
        ValidationResult SaveDocumentToDb(Document document);
    }
}
