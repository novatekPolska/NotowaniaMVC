using NHibernate.Mapping.Attributes;
using System; 

namespace NotowaniaMVC.Infrastructure.Database.Entities
{
    //Encja jednostek w jakich będzie sprzedawane paliwo/dla jakiej będzie podawana cena - litry, kilogramy etc
    public class UnitsDb
    {
        [Key]
        [Id]
        public virtual int Id { get; set;  }
        public virtual string Jm { get; set; }
        public virtual string JmDescription { get; set; }
        public virtual int Count { get; set; } 
    }
}
