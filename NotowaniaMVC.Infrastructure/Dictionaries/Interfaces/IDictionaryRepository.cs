using System.Linq; 

namespace NotowaniaMVC.Infrastructure.Dictionaries.Interfaces
{
    public interface IDictionaryRepository
    {
        IQueryable<Dictionary> GetAllIdNamePairs();
    }
}
