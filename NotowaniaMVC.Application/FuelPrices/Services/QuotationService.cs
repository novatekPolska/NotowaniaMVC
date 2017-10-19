using NotowaniaMVC.Application.FuelPrices.ViewModels;
using NotowaniaMVC.Domain.DomainEntities;

namespace NotowaniaMVC.Application.FuelPrices.Services
{
    public class QuotationService
    {
        public Quotation AddNewQuotation(FuelPricesViewModel fuelPricesViewModel) //todo wyniesc do osobnego serwisu
        {
            var quotation = Quotation.Factory.Create("");
            quotation.Validate();
            quotation.Add();
            return quotation;
        } 
    }
}
