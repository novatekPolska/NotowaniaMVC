using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.ExistingEntities; 

namespace NotowaniaMVC.Infrastructure.Database.ExistingEntitiesMappings
{
    public class DictionaryMap : ClassMap<DictionaryDb>
    {
        public DictionaryMap()
        {
            Table("SLOWNIK");
            Id(c => c.Id, "ID_SLOWNIK").Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_GK")); ;
            References(c => c.DictionaryId, "SLO_ID_SLOWNIK");
            References(c => c.TableId, "ID_DLATABELI");
            References(c => c.GroupCardTypeId, "ID_RODZGRUPKART").Not.Nullable();
            References(c => c.AnaliticsId, "ID_ANALITYKA").Not.Nullable();
            Map(c => c.Name, "NAZWA").Not.Nullable().Length(255);
            Map(c => c.BookkeepNumber, "NRKSIEGOWY").Not.Nullable();
            Map(c => c.Nip, "NIP").Not.Nullable().Length(6);
            Map(c => c.Ponip, "PONIP").Not.Nullable().Length(50);
            Map(c => c.Pesel, "PESEL").Not.Nullable(); 
            Map(c => c.Code, "KOD").Not.Nullable();
            Map(c => c.ConstantCode, "STALY_KOD").Not.Nullable();
            Map(c => c.CombinedCode, "KODZLOZONY").Not.Nullable();
            Map(c => c.CombinedName, "NAZWAZLOZONA").Not.Nullable();
            References(c => c.GroupCardTypeId2, "ID_RODZGRUPKTR").Not.Nullable();
            References(c => c.DictionaryTypeId, "ID_SLOWNIKRODZAJ").Not.Nullable();
            Map(c => c.SimpleCombinedCode, "KODZLOZONYBEZKRESEK").Not.Nullable();
        }
    }
}
