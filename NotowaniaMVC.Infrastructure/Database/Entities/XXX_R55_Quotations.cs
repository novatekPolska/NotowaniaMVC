using System; 

namespace NotowaniaMVC.Infrastructure.Database.Entities
{
    //Encja notowań paliw, bedzie powiązana z cennikami
    public class XXX_R55_Quotations
    {
        public virtual int Id { get; set; }
        public virtual Guid Guid { get; set; }
        public virtual string Code { get; set; } 
        public virtual int Fuel { get; set; }
        public virtual int Region { get; set; }
        public virtual int PriceList { get; set; }
        public virtual int Company { get; set; } 
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual int Modifier { get; set; }
        public virtual int Creator { get; set; }
    }
}
