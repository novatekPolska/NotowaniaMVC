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
        public virtual XXX_R55_Quotations Quotation { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual int Modifier { get; set; }
        public virtual int Creator { get; set; }

        private XXX_R55_Documents(Guid guid, string code, string link, int quotation, DateTime created, DateTime modified, int creator, int modifier)
        {
            Guid = guid;
            Code = code;
            Link = link;
            Quotation.Id = quotation;
            Created = created;
            Modified = modified;
            Creator = creator;
            Modifier = modifier;
        }

        public static class Factory
        {
            public static XXX_R55_Documents Create(Guid guid, string code, string link, int quotation, DateTime created, DateTime modified, int creator, int modifier)
            {
                return new XXX_R55_Documents(guid, code, link, quotation, created, modified, creator, modifier);
            }
        }
    }
}
