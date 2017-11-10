using NHibernate.Mapping.Attributes;
using NotowaniaMVC.Infrastructure.Database.ExistingEntities;
using System; 

namespace NotowaniaMVC.Infrastructure.Database.Entities
{
    //Encja notowań paliw 
    public class XXX_R55_Quotations
    {
        [Key]
        [Id]
        public virtual int Id { get; set; }
        public virtual Guid Guid { get; set; }
        public virtual string Code { get; set; } 
        public virtual decimal PriceMin { get; set; }
        public virtual decimal PriceMax { get; set; }
        public virtual DateTime DateTo { get; set; }
        public virtual DateTime DateOfQuotation { get; set; } 
        public virtual CardGroupsDb Fuel { get; set; }
        public virtual XXX_R55_Regions Region { get; set; }
        public virtual XXX_R55_Companies Company { get; set; }
        public virtual XXX_R55_QuotationTypes QuotationType { get; set; }
        public virtual UnitsDb Unit { get; set; } //jednostka
        public virtual CurrencyDb Currency { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual int Modifier { get; set; }
        public virtual int Creator { get; set; }
        public virtual XXX_R55_Documents Document { get; set; }  
    }
}
