using MediatR; 
using NotowaniaMVC.Domain.Documents.Interfaces;
using NotowaniaMVC.Domain.DomainEntities; 
using System.IO;

namespace NotowaniaMVC.Application.Documents.Handlers.CommandHandlers.Messages
{
    public class TemporaryDocumentsCommandHandler : IRequestHandler<NewTemporaryDocumentCommand>
    {
        private readonly IDocumentsDomainService _documentsDomainService;

        public TemporaryDocumentsCommandHandler(IDocumentsDomainService documentsDomainService)
        {
            _documentsDomainService = documentsDomainService;
        }

        public void Handle(NewTemporaryDocumentCommand message)
        {
            if (message.PdfFile != null)
            {
                AddNewDocument(message.PdfName, message.PdfPath, message.PdfFile);
            }
        }
         
        private int AddNewDocument(string fileName, string path, Stream fileStream)
        {
            var document = Document.Factory.Create(fileName, "", path, 1, 1, null);
            return _documentsDomainService.SaveNewDocument(document, fileStream);
        } //todo to wyciągnac do serwisu bo juz sie powtarza w handlerze notowania i tu
    }
}
