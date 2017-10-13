using System; 

namespace NotowaniaMVC.Infrastructure.Database.Entities
{
    //Encja jednostek w jakich będzie sprzedawane paliwo/dla jakiej będzie podawana cena - litry, kilogramy etc
    public class XXX_R55_Units
    {
        public virtual int Id { get; set;  }
        public virtual Guid Guid { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual int Modifier { get; set; }
        public virtual int Creator { get; set; }
    }
}
