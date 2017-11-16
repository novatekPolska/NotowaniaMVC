using MediatR;
using NotowaniaMVC.Application.Quotations.Handlers.QueryHandlers.Messages;
using NotowaniaMVC.Application.Quotations.ViewModels;
using NotowaniaMVC.Infrastructure.Common.Interfaces;
using NotowaniaMVC.Infrastructure.Database.Entities;
using NotowaniaMVC.Infrastructure.Dictionaries.Interfaces;
using System.Collections.Generic;

namespace NotowaniaMVC.Application.Quotations.Handlers.QueryHandlers
{
    public class QuotationsQueryHandler 
        : IRequestHandler<GetDataForNewQuotationQuery, NewQuotationViewModel>,
        IRequestHandler<GetDataSourceForQuotationsGridQuery, IEnumerable<QuotationsViewModel>>
    {
        private readonly IFuelTypesRepository _fuelsRepository;
        private readonly IUnitsRepository _unitsRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IQuotationTypesRepository _quotationTypesRepository;
        private readonly INHibernateUniversalRepository<XXX_R55_Quotations> _nHibernateUniversalRepository;

        public QuotationsQueryHandler
            (IFuelTypesRepository fuelsRepository, IUnitsRepository unitsRepository, ICurrencyRepository currencyRepository, IQuotationTypesRepository quotationTypesRepository, INHibernateUniversalRepository<XXX_R55_Quotations> nHibernateUniversalRepository)
        {
            _fuelsRepository = fuelsRepository;
            _unitsRepository = unitsRepository;
            _currencyRepository = currencyRepository;
            _quotationTypesRepository = quotationTypesRepository;
            _nHibernateUniversalRepository = nHibernateUniversalRepository;
        }

        public NewQuotationViewModel Handle(GetDataForNewQuotationQuery message)
        {
            var newQuotationViewModel = new NewQuotationViewModel();
            newQuotationViewModel.CurrencyTypes = _currencyRepository.GetAllIdNamePairs(); //todo to zaorac i to ma byc ajax
            newQuotationViewModel.FuelTypes = _fuelsRepository.GetAllIdNamePairs();
            newQuotationViewModel.QuotationTypes = _quotationTypesRepository.GetAllIdNamePairs();
            newQuotationViewModel.Units = _unitsRepository.GetAllIdNamePairs();

            return newQuotationViewModel;
        }

        public IEnumerable<QuotationsViewModel> Handle(GetDataSourceForQuotationsGridQuery message)
        {
            var dbQuotations = _nHibernateUniversalRepository.GetAll();

            foreach (var element in dbQuotations)
            {
                yield return new QuotationsViewModel
                { //todo to domena
                    Id = element.Id,
                    CurrencyName = element.Currency == null ? "" : element.Currency.Currency,
                    FuelTypeName = element.Fuel == null ? "" : element.Fuel.GroupName,
                    QuotationDate = element.DateOfQuotation,
                    UnitName = element.Unit == null ? "" : element.Unit.Jm,
                    PriceNettoMin = element.PriceMin,
                    PriceNettoMax = element.PriceMax,
                    PdfPath = element.Document == null ? "" : element.Document.Link
                };
            } 
        }
    }
}
