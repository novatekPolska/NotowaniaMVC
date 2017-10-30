using System.Linq;
using NotowaniaMVC.Infrastructure.Fuels.Interfaces;
using NotowaniaMVC.Infrastructure.Database.Entities;
using NHibernate;

namespace NotowaniaMVC.Infrastructure.Dictionaries.Repositories
{
    public class UnitsRepository : IUnitsRepository
    {
        private ISession Session { get; set; }

        public UnitsRepository(ISession session)
        {
            Session = session;
        }

        public IQueryable GetAllIdNamePairs()
        {
            return Session.Query<XXX_R55_Units>().Select(c => new { c.Id, c.Name });
        }
    }
}
