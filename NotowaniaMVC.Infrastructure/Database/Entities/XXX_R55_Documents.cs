using NHibernate.Mapping.Attributes;
using System; 

namespace NotowaniaMVC.Infrastructure.Database.Entities
{
    //Tabela dla dokumentów 
    public class XXX_R55_Documents
    {
        [Key]
        [Id]
        public virtual int Id { get; set; }
        public virtual Guid Guid { get; set; }
        public virtual string Code { get; set; }
        public virtual string Link { get; set; } 
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual int Modifier { get; set; }
        public virtual int Creator { get; set; }
        public virtual string Name { get; set; }  
    }
}
