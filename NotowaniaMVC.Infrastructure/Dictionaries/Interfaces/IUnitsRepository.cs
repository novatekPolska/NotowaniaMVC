using System.Collections.Generic;
using System.Linq; 

namespace NotowaniaMVC.Infrastructure.Dictionaries.Interfaces
{
    public interface IUnitsRepository
    {
        Dictionary<int, string> GetAllIdNamePairs();
    }
}
