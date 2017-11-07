using NotowaniaMVC.Domain.Documents.Interfaces;
using NotowaniaMVC.Domain.Documents.Validators;
using NotowaniaMVC.Domain.DomainEntities;
using NotowaniaMVC.Infrastructure.Common.Interfaces; 
using NotowaniaMVC.Infrastructure.Database.Entities;
using System.IO;
using System.Text;

namespace NotowaniaMVC.Domain.Documents.Services
{
    public class DocumentsDomainService: IDocumentsDomainService
    {
        private readonly INHibernateUniversalRepository<XXX_R55_Documents> _nHibernateUniversalRepository;
        public DocumentsDomainService(INHibernateUniversalRepository<XXX_R55_Documents> nHibernateUniversalRepository)
        {
            _nHibernateUniversalRepository = nHibernateUniversalRepository;
        }

        private void SaveDocumentToDb(Document document)
        {
            DocumentValidator validator = new DocumentValidator();
            var result = validator.Validate(document);
            if (result.IsValid)
            {
                var documentToAdd = XXX_R55_Documents.Factory.Create(document.Guid, document.Code, document.Link, document.Quotation, document.Created, document.Modified, document.Creator, document.Modifier);
                _nHibernateUniversalRepository.Create(documentToAdd);
            }
        }

        private void SaveDocumentOnDisk(Stream file, string Name, string Path)
        {
            StringBuilder sb = new StringBuilder(); 

            using (FileStream fs = File.Create(sb.AppendFormat("{0}, {1}", Path, Name).ToString(), (int)file.Length))
            {
                byte[] bytesInStream = new byte[file.Length];
                file.Read(bytesInStream, 0, bytesInStream.Length);
                fs.Write(bytesInStream, 0, bytesInStream.Length);
            }
        }
         
        public void SaveNewDocument(Document document, Stream file)
        {

        }
    }
}
