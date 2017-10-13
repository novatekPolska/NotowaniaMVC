using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.Entities;

namespace NotowaniaMVC.Infrastructure.Database.Mappings
{
    public class FuelsMap : ClassMap<XXX_R55_Fuels>
    {
        //Mapowanie encji Paliw na tabelę bazodanową
        public FuelsMap()
        {
            Id(c => c.Id);
            Map(c => c.Guid);
            Map(c => c.Name);
            Map(c => c.Code); 
            Map(c => c.Density); 
            Map(c => c.Created);
            Map(c => c.Modified);
            Map(c => c.Creator);
            Map(c => c.Modifier);
        } 
    }
}
