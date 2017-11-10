using MediatR;
using NotowaniaMVC.Application.Quotations.ViewModels;

namespace NotowaniaMVC.Application.Quotations.Handlers.QueryHandlers.Messages
{
    public class GetDataForNewQuotationQuery : IRequest<NewQuotationViewModel>
    {   
    }
}
