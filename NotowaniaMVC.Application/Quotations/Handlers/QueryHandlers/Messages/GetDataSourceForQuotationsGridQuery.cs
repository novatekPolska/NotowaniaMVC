using MediatR;
using NotowaniaMVC.Application.Quotations.ViewModels;
using System.Collections.Generic;

namespace NotowaniaMVC.Application.Quotations.Handlers.QueryHandlers.Messages
{
    public class GetDataSourceForQuotationsGridQuery : IRequest<IEnumerable<QuotationsViewModel>>
    {
    }
}
