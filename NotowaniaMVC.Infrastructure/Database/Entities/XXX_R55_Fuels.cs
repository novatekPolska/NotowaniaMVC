using NHibernate.Mapping.Attributes;
using System; 

namespace NotowaniaMVC.Infrastructure.Database.Entities
{
    //Paliwa, slownik paliw
    public class XXX_R55_Fuels
    {
        [Key]
        [Id]
        public virtual int Id { get; set; }
        public virtual Guid Guid { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Density { get; set; } //gęstoć paliwa 
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual int Modifier { get; set; }
        public virtual int Creator { get; set; }
    }
}
