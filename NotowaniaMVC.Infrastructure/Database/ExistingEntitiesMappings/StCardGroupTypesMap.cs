using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.ExistingEntities; 

namespace NotowaniaMVC.Infrastructure.Database.ExistingEntitiesMappings
{
    class StCardGroupTypesMap : ClassMap<StCardGroupTypesDb>
    {
        public StCardGroupTypesMap()
        {
            Table("RODZGRUPKART");
            Id(c => c.Id, "ID_RODZGRUPST").Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_GKTS")); ;
            Map(c => c.Name, "NAZWARODZAJU").Not.Nullable().Length(25);
            Map(c => c.Required, "WYMAGANY").Not.Nullable(); 
        }
    }
}
