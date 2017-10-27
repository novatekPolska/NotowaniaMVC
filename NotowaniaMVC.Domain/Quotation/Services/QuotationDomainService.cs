using NotowaniaMVC.Domain.Quotation.Interfaces;
using NotowaniaMVC.Domain.DomainEntities;

namespace NotowaniaMVC.Domain.Quotation.Services
{
    public class QuotationDomainService : IQuotationDomainService
    { 
        public void AddNewQuotation(DomainEntities.Quotation quotation)
        {
            quotation.Validate(); 
            quotation.Save();
        }
    }
}
