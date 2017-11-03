using MediatR;
using NotowaniaMVC.Application.Quotations.Handlers.CommandHandlers.Messages; 
using NotowaniaMVC.Application.FuelPrices.ViewModels;
using NotowaniaMVC.Application.FuelPrices.Interfaces;

namespace NotowaniaMVC.Application.FuelPrices.Handlers.CommandHandlers
{
    public class FuelPricesCommandHandler// : IRequestHandler<NewQuotationCommand>
    {
        private readonly IFuelPriceService _fuelPriceService; 

        public FuelPricesCommandHandler(IFuelPriceService fuelPriceService)
        {
            _fuelPriceService = fuelPriceService; 
        }

        //public void Handle(NewQuotationCommand message)
        //{
        //    foreach (var element in message.QuotationViewModels)
        //    {
        //        SaveFuelPriceData(element);
        //    }
        //}

        private void SaveFuelPriceData(FuelPricesViewModel fuelPriceDataToSave)
        { 
            var priceList = _fuelPriceService.AddNewPriceList(fuelPriceDataToSave); 
            priceList.Save(); 
        } 
    }
}
