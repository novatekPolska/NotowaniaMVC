using NotowaniaMVC.Domain.DomainEntities;
using System.IO;

namespace NotowaniaMVC.Domain.Documents.Interfaces
{
    public interface IDocumentsDomainService
    {
        void SaveNewDocument(Document document, Stream file);
    }
}
