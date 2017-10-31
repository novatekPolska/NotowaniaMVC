using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.ExistingEntities; 

namespace NotowaniaMVC.Infrastructure.Database.ExistingEntitiesMappings
{
    class DictionaryTypeMap: ClassMap<DictionaryTypeDb>
    { 
        public DictionaryTypeMap()
        {
            Table("SLOWNIKRODZAJ");
            Id(c => c.Id, "ID_SLOWNIKRODZAJ").Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_DT")); ;
            References(c => c.TableId, "ID_DLATABELI").Not.Nullable();
            References(c => c.CardGroupTypeId, "ID_RODZGRUPKART");
            References(c => c.CardGroupTypeId2, "ID_RODZGRUPKTR");
            Map(c => c.Name, "NAZWA").Length(50);
            Map(c => c.IsSubjectToSettlement, "PODLEGAROZRACH").Not.Nullable();
            Map(c => c.LawType, "RODZAJPRAWA").Default("0").Not.Nullable();
            Map(c => c.DictionaryType, "TYPSLOWNIKA").Default("0").Not.Nullable();
            References(c => c.StGroupTypeId, "ID_RODZGRUPST");
        }
    }
}
