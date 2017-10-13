using System; 

namespace NotowaniaMVC.Infrastructure.Database.Entities
{
    //Encja ceników dla notowań paliw
    public class XXX_R55_PriceLists  
    {
        public virtual int Id { get; set; }
        public virtual Guid Guid { get; set; }
        public virtual String Code { get; set; }
        public virtual decimal PriceMin { get; set; }
        public virtual decimal PriceMax { get; set; }
        public virtual int Unit { get; set; }
        public virtual int Currency { get; set; }
        public virtual DateTime DateTo { get; set; }
        public virtual DateTime DateOfQuotation { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual int Modifier { get; set; }
        public virtual int Creator { get; set; }
    }
}
