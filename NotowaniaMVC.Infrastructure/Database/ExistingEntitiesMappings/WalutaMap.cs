using FluentNHibernate.Mapping; 
using NotowaniaMVC.Infrastructure.Database.ExistingEntities;

namespace NotowaniaMVC.Infrastructure.Database.ExistingEntitiesMappings
{
    public class WalutaMap : ClassMap<WalutaDb>
    {
        public WalutaMap()
        {
            Table("WALUTA");
            Id(c => c.Id_waluta, "ID_WALUTA").Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_WAL"));
            Map(c => c.Krotnosc, "KROTNOSC").Default("1").Not.Nullable();
            Map(c => c.Skrot, "SKROT").Length(5).Not.Nullable();
            Map(c => c.Symbol, "SYMBOL").Length(5).Not.Nullable();
            Map(c => c.waluta, "WALUTA").Length(40).Not.Nullable();
            Map(c => c.Walutapodstawowa, "WALUTAPODSTAWOWA").Nullable();
            Map(c => c.Wydruk, "WYDRUK").Length(5).Not.Nullable();
            Map(c => c.Bilon, "BILON").Length(5).Not.Nullable();
        }
    }
}
