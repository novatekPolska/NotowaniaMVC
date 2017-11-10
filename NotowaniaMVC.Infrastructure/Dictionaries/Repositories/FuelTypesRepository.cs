using NHibernate; using Microsoft.EntityFrameworkCore.Extensions.Internal;

using NotowaniaMVC.Infrastructure.Dictionaries.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NotowaniaMVC.Infrastructure.Dictionaries.Repositories
{
    public class FuelTypesRepository : IFuelTypesRepository
    {
        private ISession Session { get; set; }

        public FuelTypesRepository(ISession session)
        {
            Session = session;
        }

        /// <summary>
        /// Pobranie tylko id i nazwy wszystkich rodzajów dostępnych paliw -> obecnie propan, butan, mix dla kontrolki dropDownList
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetAllIdNamePairs()
        {
            IQuery query = Session.CreateSQLQuery("select ID_GRUPAKART, NAZWAGRUPY from XXX_GRUPAKART(10003)");
            var dictionary = new Dictionary<int, string>();

            foreach (var element in query.List())
            {  
                dictionary.Add((int)((IList)element)[0], (string)((IList)element)[1]); 
            }

            return dictionary;
        }   
    }
}
