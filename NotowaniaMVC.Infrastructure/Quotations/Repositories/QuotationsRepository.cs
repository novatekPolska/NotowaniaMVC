using NHibernate;
using NotowaniaMVC.Infrastructure.Database.Entities;
using NotowaniaMVC.Infrastructure.Quotations.Interfaces;

namespace NotowaniaMVC.Infrastructure.Quotations.Repositories
{
    public class QuotationsRepository : IQuotationsRepository
    {
        private ISession Session { get; set; }

        public QuotationsRepository(ISession session)
        {
            Session = session;
        }
         
    }
}
