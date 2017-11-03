using MediatR;
using NotowaniaMVC.Application.Quotations.Handlers.CommandHandlers.Messages; 
using NotowaniaMVC.Application.Quotations.ViewModels;
using NotowaniaMVC.Domain.DomainEntities;
using NotowaniaMVC.Domain.Quotation.Interfaces;

namespace NotowaniaMVC.Application.Quotations.Handlers.CommandHandlers
{
    public class QuotationsCommandHandler : IRequestHandler<NewQuotationCommand>
    {
        private readonly IQuotationDomainService _quotationDomainService;
        public QuotationsCommandHandler(IQuotationDomainService quotationDomainService)
        {
            _quotationDomainService = quotationDomainService;
        }

        public void Handle(NewQuotationCommand message)
        {
            //todo logika domenowa sie tu wkradła niechcący w postaci tworzenia obiektu domenowego. Obiekt domenowy powinna tworzyc domena
            NewQuotationViewModel quotationViewModel = message.QuotationViewModels; 
            Quotation quotation = Quotation.Factory.Create(quotationViewModel.QuotationDate, quotationViewModel.PriceNettoMin, quotationViewModel.PriceNettoMax);

           if (quotationViewModel.Currency != 0) quotation.SetCurrency(quotationViewModel.Currency);
           if (quotationViewModel.FuelType != 0) quotation.SetFuelType(quotationViewModel.FuelType);
           if (quotationViewModel.Unit != 0) quotation.SetUnit(quotationViewModel.Unit);
           if (quotationViewModel.QuotationType != 0) quotation.SetQuotationType(quotationViewModel.QuotationType);

            _quotationDomainService.AddNewQuotation(quotation);
        }
    }
}
