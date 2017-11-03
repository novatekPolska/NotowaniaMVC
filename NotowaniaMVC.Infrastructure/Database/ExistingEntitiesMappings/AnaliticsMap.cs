using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.ExistingEntities;

namespace NotowaniaMVC.Infrastructure.Database.ExistingEntitiesMappings
{
    public class AnaliticsMap : ClassMap<AnaliticsDb>
    {
        public AnaliticsMap()
        {
            Table("ANALITYKA");
            Id(c => c.Id, "ID_ANALITYKA").Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_ANL")); ;
            Map(c => c.Name, "NAZWA").Not.Nullable().Length(25);
            Map(c => c.Active, "AKTYWNY");
            Map(c => c.Type, "TYP");
            Map(c => c.Exceptions, "SAWYJATKI");
            Map(c => c.CharCount, "NAILUZNAKACH");
            Map(c => c.PonipCount, "NAILUPONIP");
            Map(c => c.ActionWhenPositionDoesNotExist, "AKCJAGDYBRAKPOZYCJI"); 
            Map(c => c.DistributorForWage, "ROZDZIELNIK_DLA_PLAC");
            Map(c => c.ROZRACHUNKOWA, "ROZRACHUNKOWA");
            Map(c => c.PRZYDRUKROZBIC, "PRZYDRUKROZBIC");
            Map(c => c.DOLACZ_ROZRACH_NAGLPK, "DOLACZ_ROZRACH_NAGLPK");
            Map(c => c.SPOSTWANALITYKI, "SPOSTWANALITYKI");
            References(c => c.TableId, "ID_DLATABELI");
            References(c => c.CardGroupTypeId, "ID_RODZGRUPKART");
            References(c => c.CardGroupTypeId2, "ID_RODZGRUPKTR");
            References(c => c.DictionaryTypeId, "ID_SLOWNIKINNAPOZYCJA");
            References(c => c.DictionaryId, "WYMAGANY");
        }
    }
}
