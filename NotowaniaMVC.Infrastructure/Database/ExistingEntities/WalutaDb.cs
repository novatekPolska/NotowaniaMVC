using NHibernate.Mapping.Attributes;  

namespace NotowaniaMVC.Infrastructure.Database.ExistingEntities
{
    
    public class WalutaDb
    {
        [Key]
        [Id] 
        public virtual int Id_waluta { get; set; }
        public virtual string Skrot { get; set; }
        public virtual string waluta { get; set; }
        public virtual string Bilon { get; set; }
        public virtual int Krotnosc { get; set; }
        public virtual bool Walutapodstawowa { get; set; }
        public virtual string Symbol { get; set; }
        public virtual string Wydruk { get; set; }
    }
}
