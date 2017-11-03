using NHibernate.Mapping.Attributes;  

namespace NotowaniaMVC.Infrastructure.Database.ExistingEntities
{
    
    public class CurrencyDb
    {
        [Key]
        [Id] 
        public virtual int Id { get; set; }
        public virtual string Shortcut { get; set; }
        public virtual string Currency { get; set; }
        public virtual string Specie { get; set; } //bilon
        public virtual int Multiplicity { get; set; } //krotnosc
        public virtual bool BasicCurrency { get; set; }
        public virtual string Symbol { get; set; }
        public virtual string Print { get; set; }
    }
}
