using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.Entities; 

namespace NotowaniaMVC.Infrastructure.Database.Mappings
{
    class FuelTypesMap : ClassMap<XXX_R55_FuelTypes>
    {
        //Mapowanie encji rodzajów paliw na tabelę bazodanową
        public FuelTypesMap()
        {
            Table("XXX_R55_FUEL_TYPES");
            Id(c => c.Id, "ID").Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_FUET")); ;
            Map(c => c.Guid, "GUID");
            Map(c => c.Name, "NAME");
            Map(c => c.Code, "CODE"); 
            Map(c => c.Created, "CREATED");
            Map(c => c.Modified, "MODIFIED");
            Map(c => c.Creator, "CREATOR");
            Map(c => c.Modifier, "MODIFIER");
        }
    }
}
