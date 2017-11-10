using NotowaniaMVC.Domain.DomainEntities; 

namespace NotowaniaMVC.Domain.Documents.Interfaces
{
    public interface IDbDocumentHelper
    {
        int SaveDocumentToDb(Document document);
    }
}
