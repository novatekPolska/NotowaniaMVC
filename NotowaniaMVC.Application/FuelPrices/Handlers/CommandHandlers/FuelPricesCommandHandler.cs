using System; 
using MediatR;
using NotowaniaMVC.Application.FuelPrices.Handlers.CommandHandlers.Messages;

namespace NotowaniaMVC.Application.FuelPrices.Handlers.CommandHandlers
{
    public class FuelPricesCommandHandler : IRequestHandler<NewQuotationCommand>
    {
        public void Handle(NewQuotationCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
