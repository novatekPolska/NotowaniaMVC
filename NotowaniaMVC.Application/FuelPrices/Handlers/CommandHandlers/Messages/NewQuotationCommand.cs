using NotowaniaMVC.Application.FuelPrices.ViewModels; 
using System.Collections.Generic; 
using MediatR;

namespace NotowaniaMVC.Application.FuelPrices.Handlers.CommandHandlers.Messages
{
    public class NewQuotationCommand : IRequest 
    {
        public IEnumerable<FuelPricesViewModel> FuelPricesViewModels { get; set; }
    }
}
