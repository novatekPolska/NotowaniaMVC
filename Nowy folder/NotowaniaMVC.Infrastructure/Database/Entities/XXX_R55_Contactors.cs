using System; 

namespace NotowaniaMVC.Infrastructure.Database.Entities
{
    //Kontrahenci. Będzie wykorzystane w przyszlosci
    public class XXX_R55_Contactors
    {
        public int Id { get; set;  }

        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual int Modifier { get; set; }
        public virtual int Creator { get; set; }
    }
}
