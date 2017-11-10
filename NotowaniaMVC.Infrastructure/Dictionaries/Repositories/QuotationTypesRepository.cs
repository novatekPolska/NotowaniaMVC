using NHibernate;
using NotowaniaMVC.Infrastructure.Database.Entities;
using NotowaniaMVC.Infrastructure.Dictionaries.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NotowaniaMVC.Infrastructure.Dictionaries.Repositories
{
    public class QuotationTypesRepository: IQuotationTypesRepository
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
        public Dictionary<int, string> GetAllIdNamePairs() 
        {
            var data = Session.Query<XXX_R55_QuotationTypes>().Select(c => new { id = c.Id, name = c.Name });
            return data.ToDictionary(p => p.id, p => p.name); 
        } 
    }
}
