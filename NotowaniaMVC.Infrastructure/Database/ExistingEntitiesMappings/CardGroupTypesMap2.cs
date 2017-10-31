using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.ExistingEntities; 

namespace NotowaniaMVC.Infrastructure.Database.ExistingEntitiesMappings
{
    class CardGroupTypesMap2 : ClassMap<CardGroupTypesDb2>
    {
        public CardGroupTypesMap2()
        {
            Table("RODZGRUPKTR");
            Id(c => c.Id, "ID_RODZGRUPKTR").Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_GKTR")); ;
            Map(c => c.Name, "NAZWARODZAJU").Not.Nullable().Length(25);
            Map(c => c.Required, "WYMAGANY").Not.Nullable(); 
        }
    }
}
