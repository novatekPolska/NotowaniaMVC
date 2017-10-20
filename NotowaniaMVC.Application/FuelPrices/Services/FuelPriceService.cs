using NotowaniaMVC.Application.FuelPrices.Interfaces;
using NotowaniaMVC.Application.FuelPrices.ViewModels;
using NotowaniaMVC.Domain.DomainEntities;

namespace NotowaniaMVC.Application.FuelPrices.Services
{
    public class FuelPriceService : IFuelPriceService
    {
        public PriceList AddNewPriceList(FuelPricesViewModel fuelPriceViewModel) //todo to chyba powinien byc serwis domenowy
        {
            var priceList = PriceList.Factory.Create("", fuelPriceViewModel.FuelPriceMinNetto, fuelPriceViewModel.FuelPriceMaxNetto, fuelPriceViewModel.FuelPriceMinBrutto, fuelPriceViewModel.FuelPriceMaxBrutto);
            priceList.Validate();
            priceList.Add();
            return priceList;
        }
    }
}
