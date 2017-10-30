using System.Linq; 

namespace NotowaniaMVC.Infrastructure.Dictionaries.Interfaces
{
    public interface IQuotationTypesRepository
    {
        IQueryable GetAllIdNamePairs();
    }
}
