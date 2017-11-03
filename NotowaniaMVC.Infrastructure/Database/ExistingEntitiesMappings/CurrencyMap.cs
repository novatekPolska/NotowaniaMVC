using FluentNHibernate.Mapping; 
using NotowaniaMVC.Infrastructure.Database.ExistingEntities;

namespace NotowaniaMVC.Infrastructure.Database.ExistingEntitiesMappings
{
    public class CurrencyMap : ClassMap<CurrencyDb>
    {
        public CurrencyMap()
        {
            Table("WALUTA");
            Id(c => c.Id, "ID_WALUTA").Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_WAL"));
            Map(c => c.Multiplicity, "KROTNOSC").Default("1").Not.Nullable();
            Map(c => c.Shortcut, "SKROT").Length(5).Not.Nullable();
            Map(c => c.Symbol, "SYMBOL").Length(5).Not.Nullable();
            Map(c => c.Currency, "WALUTA").Length(40).Not.Nullable();
            Map(c => c.BasicCurrency, "WALUTAPODSTAWOWA").Nullable();
            Map(c => c.Print, "WYDRUK").Length(5).Not.Nullable();
            Map(c => c.Specie, "BILON").Length(5).Not.Nullable();
        }
    }
}
