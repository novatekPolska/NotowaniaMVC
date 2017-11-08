namespace NotowaniaMVC.Domain.Quotation.Interfaces
{
    public interface IQuotationDomainService
    {
        void AddNewQuotation(DomainEntities.Quotation quotation);
        void AddDocumentToQuotation(DomainEntities.Quotation quotation, int documentId);
    }
}
