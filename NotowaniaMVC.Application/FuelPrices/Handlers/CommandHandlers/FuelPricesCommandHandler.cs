using MediatR;
using NotowaniaMVC.Application.FuelPrices.Handlers.CommandHandlers.Messages;
using NotowaniaMVC.Domain.DomainEntities;
using NotowaniaMVC.Application.FuelPrices.ViewModels;

namespace NotowaniaMVC.Application.FuelPrices.Handlers.CommandHandlers
{
    public class FuelPricesCommandHandler : IRequestHandler<NewQuotationCommand>
    {
        public void Handle(NewQuotationCommand message)
        {
            foreach (var element in message.fuelPricesViewModels)
            {
                var quotation = AddNewQuotation(element);
                var priceList = AddNewPriceList(element);
                quotation.SetPriceList(priceList.GetId());
                priceList.Save();
                quotation.Save();
            }
        }
         
        private PriceList AddNewPriceList(FuelPricesViewModel fuelPriceViewModel) //todo wyniesc do osobnego serwisu
        {
            var priceList = PriceList.Factory.Create("", fuelPriceViewModel.FuelPriceMinNetto, fuelPriceViewModel.FuelPriceMaxNetto, fuelPriceViewModel.FuelPriceMinBrutto, fuelPriceViewModel.FuelPriceMaxBrutto);
            priceList.Validate();
            priceList.Add();
            return priceList;
        }

        private Quotation AddNewQuotation(FuelPricesViewModel fuelPricesViewModel) //todo wyniesc do osobnego serwisu
        {
            var quotation = Quotation.Factory.Create("");
            quotation.Validate();
            quotation.Add();
            return quotation;
        }
    }
}
