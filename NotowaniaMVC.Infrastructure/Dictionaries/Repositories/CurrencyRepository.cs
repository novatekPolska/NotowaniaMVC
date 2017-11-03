using System.Linq;
using NotowaniaMVC.Infrastructure.Dictionaries.Interfaces;
using NHibernate;
using NotowaniaMVC.Infrastructure.Database.ExistingEntities;

namespace NotowaniaMVC.Infrastructure.Dictionaries.Repositories
{
    public class CurrencyRepository : IDictionaryRepository
    {
        private ISession Session { get; set; }

        public CurrencyRepository(ISession session)
        {
            Session = session;
        }

        public IQueryable<Dictionary> GetAllIdNamePairs()
        {
            return Session.Query<CurrencyDb>().Select(c => new Dictionary { Id = c.Id, Name = c.Shortcut });
        }
    }
}
