using System.Collections.Generic;
using System.Linq; 

namespace NotowaniaMVC.Infrastructure.Dictionaries.Interfaces
{
    public interface IQuotationTypesRepository
    {
        Dictionary<int, string> GetAllIdNamePairs();
    }
}
