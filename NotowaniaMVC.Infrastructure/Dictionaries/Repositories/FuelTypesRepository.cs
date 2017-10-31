using Microsoft.EntityFrameworkCore.Extensions.Internal;
using NHibernate;
using NotowaniaMVC.Infrastructure.Database.Entities;
using NotowaniaMVC.Infrastructure.Dictionaries.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NotowaniaMVC.Infrastructure.Dictionaries.Repositories
{
    public class FuelTypesRepository : IDictionaryRepository
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
        public IEnumerable<Dictionary> GetAllIdNamePairs()
        {
            IQuery query = Session.CreateSQLQuery("select GRU_ID_GRUPAKART, NAZWAGRUPY from XXX_GRUPAKART(10003)");
           
            foreach (var element in query.List())
            {
                yield return new Dictionary { Id = (int)((IList)element)[0], Name = (string)((IList)element)[1] };
            } 
        }

        IQueryable<Dictionary> IDictionaryRepository.GetAllIdNamePairs()
        {
            throw new System.NotImplementedException();
        }
    }
}
