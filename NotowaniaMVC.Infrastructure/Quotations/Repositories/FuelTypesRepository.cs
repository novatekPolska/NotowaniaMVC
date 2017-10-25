using NHibernate;
using NotowaniaMVC.Infrastructure.Database.Entities;
using NotowaniaMVC.Infrastructure.Quotations.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NotowaniaMVC.Infrastructure.Quotations.Repositories
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
        public IQueryable<object> GetAllForDropDownList()
        {
            return Session.Query<XXX_R55_FuelTypes>().Select(c => new { c.Id, c.Name });
        }
    }
}
