using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.ExistingEntities; 

namespace NotowaniaMVC.Infrastructure.Database.ExistingEntitiesMappings
{
    public class CardGroupsMap : ClassMap<CardGroupsDb>
    {
        public CardGroupsMap()
        {
            Table("GRUPAKART");
            Id(c => c.Id, "ID_GRUPAKART").Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_GK")); ;
            Map(c => c.Active, "AKTYWNY");
            References(c => c.CardGroupId, "GRU_ID_GRUPAKART");
            References(c => c.CardGroupType, "ID_RODZGRUPKART").Not.Nullable();
            Map(c => c.CombinedCode, "KODZLOZONY").Not.Nullable().Length(50);
            Map(c => c.CombinedName, "NAZWAZLOZONA").Not.Nullable().Length(255);
            References(c => c.DictionaryId, "ID_SLOWNIK").Not.Nullable();
            Map(c => c.GroupCode, "KODGRUPY").Not.Nullable().Length(6);
            Map(c => c.GroupName, "NAZWAGRUPY").Not.Nullable().Length(50);
            Map(c => c.Zero, "ZEROWY").Not.Nullable(); 
        }
    }
}
