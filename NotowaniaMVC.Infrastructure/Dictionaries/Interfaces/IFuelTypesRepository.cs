using System.Linq; 

namespace NotowaniaMVC.Infrastructure.Dictionaries.Interfaces
{
    public interface IFuelTypesRepository
    {
        IQueryable GetAllIdNamePairs();
    }
}
