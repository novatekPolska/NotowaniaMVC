using FluentValidation.Results;
using NotowaniaMVC.Domain.DomainEntities;
using System.IO;

namespace NotowaniaMVC.Domain.Documents.Interfaces
{
    public interface IDocumentsDomainService
    {
        ValidationResult SaveNewDocument(Document document, Stream file);
    }
}
