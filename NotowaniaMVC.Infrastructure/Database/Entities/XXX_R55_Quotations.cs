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
        public virtual UnitsDb Unit { get; set; } //jednostka
        public virtual CurrencyDb Currency { get; set; } //waluta todo dodac tabele waluta i dodac klucz obcy
        public virtual XXX_R55_Fuels Fuel { get; set; }
        public virtual XXX_R55_Regions Region { get; set; }
        public virtual XXX_R55_Companies Company { get; set; }
        public virtual XXX_R55_QuotationTypes QuotationType { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual int Modifier { get; set; }
        public virtual int Creator { get; set; }

        public static class Factory
        {
            public static XXX_R55_Quotations Create(decimal priceMin, decimal priceMax,  DateTime dateOfQuotation)
            {
                return new XXX_R55_Quotations
                {
                    Guid = Guid.NewGuid(),
                    PriceMin = priceMin,
                    PriceMax = priceMax,
                    DateOfQuotation = dateOfQuotation, 
                    Created = DateTime.Now,
                    Modified = DateTime.Now 
                };
            }
        }
    }
}
