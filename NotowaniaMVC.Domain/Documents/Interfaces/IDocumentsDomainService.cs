using NotowaniaMVC.Domain.DomainEntities;
using System.IO;

namespace NotowaniaMVC.Domain.Documents.Interfaces
{
    public interface IDocumentsDomainService
    {
        int SaveNewDocument(Document document, Stream file);
    }
}
