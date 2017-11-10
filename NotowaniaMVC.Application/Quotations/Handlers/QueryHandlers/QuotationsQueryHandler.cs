using MediatR;
using NotowaniaMVC.Application.Quotations.Handlers.QueryHandlers.Messages;
using NotowaniaMVC.Application.Quotations.ViewModels;
using NotowaniaMVC.Infrastructure.Dictionaries.Interfaces;

namespace NotowaniaMVC.Application.Quotations.Handlers.QueryHandlers
{
    public class QuotationsQueryHandler : IRequestHandler<GetDataForNewQuotationQuery, NewQuotationViewModel>
    {
        private readonly IFuelTypesRepository _fuelsRepository;
        private readonly IUnitsRepository _unitsRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IQuotationTypesRepository _quotationTypesRepository;

        public QuotationsQueryHandler(IFuelTypesRepository fuelsRepository, IUnitsRepository unitsRepository, ICurrencyRepository currencyRepository, IQuotationTypesRepository quotationTypesRepository)
        {
            _fuelsRepository = fuelsRepository;
            _unitsRepository = unitsRepository;
            _currencyRepository = currencyRepository;
            _quotationTypesRepository = quotationTypesRepository;
        }

        public NewQuotationViewModel Handle(GetDataForNewQuotationQuery message)
        {
            var newQuotationViewModel = new NewQuotationViewModel();
            newQuotationViewModel.CurrencyTypes = _currencyRepository.GetAllIdNamePairs();
            newQuotationViewModel.FuelTypes = _fuelsRepository.GetAllIdNamePairs();
            newQuotationViewModel.QuotationTypes = _quotationTypesRepository.GetAllIdNamePairs();
            newQuotationViewModel.Units = _unitsRepository.GetAllIdNamePairs();

            return newQuotationViewModel;
        }
    }
}
