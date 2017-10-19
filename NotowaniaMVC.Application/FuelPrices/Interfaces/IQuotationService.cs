using NotowaniaMVC.Application.FuelPrices.ViewModels;
using NotowaniaMVC.Domain.DomainEntities; 

namespace NotowaniaMVC.Application.FuelPrices.Interfaces
{
    public interface IQuotationService
    {
        Quotation AddNewQuotation(FuelPricesViewModel fuelPricesViewModel);
    }
}
