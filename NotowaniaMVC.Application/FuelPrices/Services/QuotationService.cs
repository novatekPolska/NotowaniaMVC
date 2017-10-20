using NotowaniaMVC.Application.FuelPrices.Interfaces;
using NotowaniaMVC.Application.FuelPrices.ViewModels;
using NotowaniaMVC.Domain.DomainEntities; 
using NotowaniaMVC.Infrastructure.FuelPrices.Interfaces;

namespace NotowaniaMVC.Application.FuelPrices.Services
{
    public class QuotationService : IQuotationService
    { 
        public Quotation AddNewQuotation(FuelPricesViewModel fuelPricesViewModel)  //todo to chyba powinien byc serwis domenowy
        {
            var quotation = Quotation.Factory.Create("");
            quotation.Validate();
            quotation.Add();
            return quotation;
        } 
    }
}
