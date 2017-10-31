using NHibernate;
using NotowaniaMVC.Infrastructure.Database.Entities;
using NotowaniaMVC.Infrastructure.Dictionaries.Interfaces; 
using System.Linq;

namespace NotowaniaMVC.Infrastructure.Dictionaries.Repositories
{
    public class QuotationTypesRepository: IDictionaryRepository
    { 
        private ISession Session { get; set; }

        public QuotationTypesRepository(ISession session)
        {
            Session = session;
        }

        /// <summary>
        /// pobiera id i name dla typów notowań. Potrzebne jest to do kontrolki z listą rozwijalną w formularzu dodawania nowego notowania
        /// </summary>
        /// <returns></returns>
        public IQueryable<Dictionary> GetAllIdNamePairs() 
        {
            return Session.Query<XXX_R55_QuotationTypes>().Select(c => new Dictionary { Id = c.Id, Name = c.Name });
        } 
    }
}
