using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.Entities;

namespace NotowaniaMVC.Infrastructure.Database.Mappings
{
    public class UnitsMap : ClassMap<UnitsDb>
    {
        //Mapowanie encji jednostek dla jakiej podana jest cena - np litry, kilogramy na tabelę bazodanową
        public UnitsMap()
        {
            Table("JM");
            Id(c => c.Id, "ID_JM").Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_UNIT"));
            Map(c => c.Jm, "JM").Not.Nullable().Length(5);
            Map(c => c.JmDescription, "OPISJM").Not.Nullable().Length(15);
            Map(c => c.Count, "ILEMIEJSCURZZEW"); 
        }
    }
}
