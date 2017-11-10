using System.Collections.Generic;
using System.Linq; 

namespace NotowaniaMVC.Infrastructure.Dictionaries.Interfaces
{
    public interface ICurrencyRepository
    {
        Dictionary<int, string> GetAllIdNamePairs();
    }
}
