using FluentValidation.Results;
using NotowaniaMVC.Domain.Documents.Interfaces; 
using NotowaniaMVC.Domain.DomainEntities; 
using System.IO; 

namespace NotowaniaMVC.Domain.Documents.Services
{
    public class DocumentsDomainService : IDocumentsDomainService
    {
        private readonly IDbDocumentHelper _dbDocumentHelper;
        private readonly IDiskDocumentHelper _diskDocumentHelper;

        public DocumentsDomainService(IDbDocumentHelper dbDocumentHelper, IDiskDocumentHelper diskDocumentHelper)
        {
            _dbDocumentHelper = dbDocumentHelper;
            _diskDocumentHelper = diskDocumentHelper;
        }
          
        public ValidationResult SaveNewDocument(Document document, string name, Stream file)  
        {
            _diskDocumentHelper.SaveDocumentOnDisk(file, name, document.Link);  
            var validationResult = _dbDocumentHelper.SaveDocumentToDb(document);
            return validationResult;
        }
    }
}
