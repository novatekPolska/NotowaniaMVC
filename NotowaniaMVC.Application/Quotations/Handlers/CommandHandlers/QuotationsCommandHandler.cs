using MediatR;
using NotowaniaMVC.Application.Quotations.Handlers.CommandHandlers.Messages; 
using NotowaniaMVC.Application.Quotations.ViewModels;
using NotowaniaMVC.Domain.Documents.Interfaces;
using NotowaniaMVC.Domain.DomainEntities;
using NotowaniaMVC.Domain.Quotation.Interfaces;
using System.IO;

namespace NotowaniaMVC.Application.Quotations.Handlers.CommandHandlers
{
    public class QuotationsCommandHandler : IRequestHandler<NewQuotationCommand>
    {
        private readonly IQuotationDomainService _quotationDomainService;
        private readonly IDocumentsDomainService _documentsDomainService;

        public QuotationsCommandHandler(IQuotationDomainService quotationDomainService, IDocumentsDomainService documentsDomainService)
        {
            _quotationDomainService = quotationDomainService;
            _documentsDomainService = documentsDomainService;
        }

        public void Handle(NewQuotationCommand message)
        {
            int newQuotationId = AddNewQuotation(message.QuotationViewModels);
            var document = Document.Factory.Create(message.QuotationViewModels.PdfName, "", message.QuotationViewModels.PdfPath, 1, 1, null);
            int newDocumentId = _documentsDomainService.SaveNewDocument(document ,message.QuotationViewModels.PdfFile);
            _quotationDomainService.AddDocumentToQuotation(newQuotationId, newDocumentId);
        }

        private int AddNewQuotation(NewQuotationViewModel quotationViewModel)
        { 
            var quotation = Quotation.Factory.Create(quotationViewModel.QuotationDate, quotationViewModel.PriceNettoMin, quotationViewModel.PriceNettoMax);

            if (quotationViewModel.Currency != 0) quotation.SetCurrency(quotationViewModel.Currency);
            if (quotationViewModel.FuelType != 0) quotation.SetFuelType(quotationViewModel.FuelType);
            if (quotationViewModel.Unit != 0) quotation.SetUnit(quotationViewModel.Unit);
            if (quotationViewModel.QuotationType != 0) quotation.SetQuotationType(quotationViewModel.QuotationType);

            return _quotationDomainService.AddNewQuotation(quotation); 
        } 

        private int AddNewDocument(string fileName, string path, Stream fileStream)
        {
            var document = Document.Factory.Create(fileName, "", path, 1, 1, null); 
            return _documentsDomainService.SaveNewDocument(document, fileStream);
        }
    }
}
