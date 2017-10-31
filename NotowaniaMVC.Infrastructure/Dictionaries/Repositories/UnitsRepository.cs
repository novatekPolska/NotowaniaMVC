using System.Linq;
using NotowaniaMVC.Infrastructure.Dictionaries.Interfaces;
using NotowaniaMVC.Infrastructure.Database.Entities;
using NHibernate;

namespace NotowaniaMVC.Infrastructure.Dictionaries.Repositories
{
    public class UnitsRepository : IDictionaryRepository
    {
        private ISession Session { get; set; }

        public UnitsRepository(ISession session)
        {
            Session = session;
        }

        public IQueryable<Dictionary> GetAllIdNamePairs()
        {
            return Session.Query<UnitsDb>().Select(c => new Dictionary { Id = c.Id, Name = c.Jm });
        }
    }
}
