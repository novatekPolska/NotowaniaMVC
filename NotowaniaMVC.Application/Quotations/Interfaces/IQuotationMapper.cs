using NotowaniaMVC.Application.Quotations.ViewModels;
using NotowaniaMVC.Domain.DomainEntities;

namespace NotowaniaMVC.Application.Quotations.Interfaces
{
    public interface IQuotationMapper
    {
        Quotation MapNewQuotationViewModelToQuotationDomainModel(NewQuotationViewModel quotationViewModel);
    }
}
