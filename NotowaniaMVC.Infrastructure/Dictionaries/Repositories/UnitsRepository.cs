using System.Linq;
using NotowaniaMVC.Infrastructure.Dictionaries.Interfaces;
using NotowaniaMVC.Infrastructure.Database.Entities;
using NHibernate;
using System.Collections.Generic;

namespace NotowaniaMVC.Infrastructure.Dictionaries.Repositories
{
    public class UnitsRepository : IUnitsRepository
    {
        private ISession Session { get; set; }

        public UnitsRepository(ISession session)
        {
            Session = session;
        }

        public Dictionary<int, string> GetAllIdNamePairs()
        {
            var data = Session.Query<UnitsDb>().Select(c => new { id = c.Id, name = c.Jm });
            return data.ToDictionary(p => p.id, p => p.name); 
        }
    }
}
