using FluentNHibernate.Mapping; 
using NotowaniaMVC.Infrastructure.Database.ExistingEntities;

namespace NotowaniaMVC.Infrastructure.Database.ExistingEntitiesMappings
{
    public class WalutaMap : ClassMap<Waluta>
    {
        public WalutaMap()
        {
            Id(c => c.Id_waluta);
            Map(c => c.Krotnosc);
            Map(c => c.Skrot).Length(5);
            Map(c => c.Symbol).Length(5);
            Map(c => c.waluta).Length(40);
            Map(c => c.Walutapodstawowa).Nullable();
            Map(c => c.Wydruk).Length(5);
            Map(c => c.Bilon).Length(5);
        }
    }
}
