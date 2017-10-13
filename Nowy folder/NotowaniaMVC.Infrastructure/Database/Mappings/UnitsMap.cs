using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.Entities;

namespace NotowaniaMVC.Infrastructure.Database.Mappings
{
    public class UnitsMap : ClassMap<XXX_R55_Units>
    {
        //Mapowanie encji jednostek dla jakiej podana jest cena - np litry, kilogramy na tabelę bazodanową
        public UnitsMap()
        {
            Id(c => c.Id);
            Map(c => c.Guid);
            Map(c => c.Name);
            Map(c => c.Code);
            Map(c => c.Created);
            Map(c => c.Modified);
            Map(c => c.Creator);
            Map(c => c.Modifier);
        }
    }
}
