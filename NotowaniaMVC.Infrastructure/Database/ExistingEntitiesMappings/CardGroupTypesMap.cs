using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.ExistingEntities; 

namespace NotowaniaMVC.Infrastructure.Database.ExistingEntitiesMappings
{
    class CardGroupTypesMap : ClassMap<CardGroupTypesDb>
    {
        public CardGroupTypesMap()
        {
            Table("RODZGRUPKART");
            Id(c => c.Id, "ID_RODZGRUPKART").Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_GKT")); ;
            Map(c => c.Name, "NAZWARODZAJU").Not.Nullable().Length(25);
            Map(c => c.Required, "WYMAGANY").Not.Nullable(); 
        }
    }
}
