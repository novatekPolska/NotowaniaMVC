using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.Entities;

namespace NotowaniaMVC.Infrastructure.Database.Mappings
{
    public class RegionsMap : ClassMap<XXX_R55_Regions>
    {
        //Mapowanie encji Regionów sprzedaży na tabelę bazodanową
        public RegionsMap()
        {
            Table("XXX_R55_REGIONS");
            Id(c => c.Id, "ID").Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_REG")); ;
            Map(c => c.Guid, "GUID"); 
            Map(c => c.Code, "CODE");
            Map(c => c.Name, "NAME");
            Map(c => c.Created, "CREATED");
            Map(c => c.Modified, "MODIFIED");
            Map(c => c.Creator, "CREATOR");
            Map(c => c.Modifier, "MODIFIER");
        }
    }
}
