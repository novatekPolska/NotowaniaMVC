using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.Entities;

namespace NotowaniaMVC.Infrastructure.Database.Mappings
{
    public class CompaniesMap : ClassMap<XXX_R55_Companies>
    {
        //Mapowanie encji Jednostek sprzedających paliwa na tabelę bazodanową
        public CompaniesMap()
        {
            Table("XXX_R55_COMPANIES");
            Id(c => c.Id, "ID").Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_COMP")); ;
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
