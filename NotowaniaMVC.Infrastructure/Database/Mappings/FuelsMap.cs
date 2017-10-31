using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.Entities;

namespace NotowaniaMVC.Infrastructure.Database.Mappings
{
    public class FuelsMap : ClassMap<XXX_R55_Fuels>
    {
        //Mapowanie encji Paliw na tabelę bazodanową
        public FuelsMap()
        {
            Table("XXX_R55_FUELS");
            Id(c => c.Id, "ID").Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_FUEL")); ;
            Map(c => c.Guid, "GUID");
            Map(c => c.Name, "NAME");
            Map(c => c.Code, "CODE"); 
            Map(c => c.Density, "DENSITY"); 
            Map(c => c.Created, "CREATED");
            Map(c => c.Modified, "MODIFIED");
            Map(c => c.Creator, "CREATOR");
            Map(c => c.Modifier, "MODIFIER");
        } 
    }
}
