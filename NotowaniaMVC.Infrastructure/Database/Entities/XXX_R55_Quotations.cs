using NHibernate.Mapping.Attributes;
using System; 

namespace NotowaniaMVC.Infrastructure.Database.Entities
{
    //Encja notowań paliw, bedzie powiązana z cennikami
    public class XXX_R55_Quotations
    {
        [Key]
        [Id] 
        public virtual int Id { get; set; }
        public virtual Guid Guid { get; set; }
        public virtual string Code { get; set; }  
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual int Modifier { get; set; }
        public virtual int Creator { get; set; }

        public virtual XXX_R55_Fuels Fuel { get; set; }
        public virtual XXX_R55_Regions Region { get; set; }
        public virtual XXX_R55_PriceLists PriceList { get; set; }
        public virtual XXX_R55_Companies Company { get; set; } 
    }
}
