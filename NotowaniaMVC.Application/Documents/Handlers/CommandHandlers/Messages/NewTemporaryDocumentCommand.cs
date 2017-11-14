using MediatR; 
using System.IO;

namespace NotowaniaMVC.Application.Documents.Handlers.CommandHandlers.Messages
{
    public class NewTemporaryDocumentCommand : IRequest
    {
        public Stream PdfFile { get; set; }
        public string PdfPath { get; set; }
        public string PdfName { get; set; }
    } 
}
