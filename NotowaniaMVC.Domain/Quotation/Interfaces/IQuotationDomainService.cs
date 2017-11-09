namespace NotowaniaMVC.Domain.Quotation.Interfaces
{
    public interface IQuotationDomainService
    {
        int AddNewQuotation(DomainEntities.Quotation quotation);
        void AddDocumentToQuotation(int quotation, int documentId);
    }
}
