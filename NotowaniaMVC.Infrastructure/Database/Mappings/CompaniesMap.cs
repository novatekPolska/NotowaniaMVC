using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.Entities;

namespace NotowaniaMVC.Infrastructure.Database.Mappings
{
    public class CompaniesMap : ClassMap<XXX_R55_Companies>
    {
        //Mapowanie encji Jednostek sprzedających paliwa na tabelę bazodanową
        public CompaniesMap()
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
