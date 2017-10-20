using MediatR;
using NotowaniaMVC.Application.FuelPrices.Handlers.CommandHandlers.Messages; 
using NotowaniaMVC.Application.FuelPrices.ViewModels;
using NotowaniaMVC.Application.FuelPrices.Interfaces;

namespace NotowaniaMVC.Application.FuelPrices.Handlers.CommandHandlers
{
    public class FuelPricesCommandHandler : IRequestHandler<NewQuotationCommand>
    {
        private readonly IFuelPriceService _fuelPriceService;
        private readonly IQuotationService _quotationService;

        public FuelPricesCommandHandler(IFuelPriceService fuelPriceService, IQuotationService quotationService)
        {
            _fuelPriceService = fuelPriceService;
            _quotationService = quotationService;
        }

        public void Handle(NewQuotationCommand message)
        {
            foreach (var element in message.FuelPricesViewModels)
            {
                SaveFuelPriceData(element);
            }
        }
         
        private void SaveFuelPriceData(FuelPricesViewModel fuelPriceDataToSave)
        {
            var quotation = _quotationService.AddNewQuotation(fuelPriceDataToSave);
            var priceList = _fuelPriceService.AddNewPriceList(fuelPriceDataToSave);
            quotation.SetPriceListId(priceList.GetId());
            priceList.Save();
            quotation.Save();
        } 
    }
}
