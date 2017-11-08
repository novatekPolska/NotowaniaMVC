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

        protected XXX_R55_Documents()
        {

        }

        private XXX_R55_Documents(string name, Guid guid, string code, string link, DateTime created, DateTime modified, int creator, int modifier)
        {
            Guid = guid;
            Code = code;
            Link = link; 
            Created = created;
            Modified = modified;
            Creator = creator;
            Modifier = modifier;
            Name = name;
        }

        public static class Factory
        {
            public static XXX_R55_Documents Create(string name, Guid guid, string code, string link, DateTime created, DateTime modified, int creator, int modifier)
            {
                return new XXX_R55_Documents(name, guid, code, link, created, modified, creator, modifier);
            }
        }
    }
}
