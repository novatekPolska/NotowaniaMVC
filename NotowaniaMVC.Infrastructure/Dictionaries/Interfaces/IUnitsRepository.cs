using System.Linq; 

namespace NotowaniaMVC.Infrastructure.Dictionaries.Interfaces
{
    public interface IUnitsRepository
    {
        IQueryable GetAllIdNamePairs();
    }
}
