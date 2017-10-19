using NotowaniaMVC.Application.FuelPrices.ViewModels;
using NotowaniaMVC.Domain.DomainEntities;

namespace NotowaniaMVC.Application.FuelPrices.Services
{
    public class FuelPriceService
    {
        public PriceList AddNewPriceList(FuelPricesViewModel fuelPriceViewModel) 
        {
            var priceList = PriceList.Factory.Create("", fuelPriceViewModel.FuelPriceMinNetto, fuelPriceViewModel.FuelPriceMaxNetto, fuelPriceViewModel.FuelPriceMinBrutto, fuelPriceViewModel.FuelPriceMaxBrutto);
            priceList.Validate();
            priceList.Add();
            return priceList;
        }
    }
}
