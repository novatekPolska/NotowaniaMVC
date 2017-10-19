using NotowaniaMVC.Application.FuelPrices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NotowaniaMVC.Application.FuelPrices.Handlers.CommandHandlers.Messages
{
    public class NewQuotationCommand : IRequest<IEnumerable<FuelPricesViewModel>>
    {
        IEnumerable<FuelPricesViewModel> fuelPricesViewModels { get; set; }
    }
}
