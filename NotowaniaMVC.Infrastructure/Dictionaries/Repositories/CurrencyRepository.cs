using System.Linq;
using NotowaniaMVC.Infrastructure.Dictionaries.Interfaces;
using NHibernate;
using NotowaniaMVC.Infrastructure.Database.ExistingEntities;
using System.Collections.Generic;

namespace NotowaniaMVC.Infrastructure.Dictionaries.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private ISession Session { get; set; }

        public CurrencyRepository(ISession session)
        {
            Session = session;
        }

        public Dictionary<int, string> GetAllIdNamePairs()
        {
            var data = Session.Query<CurrencyDb>().Select(c => new { id = c.Id, name = c.Shortcut });
            return data.ToDictionary(p=>p.id, p=> p.name);
        }
    }
}
