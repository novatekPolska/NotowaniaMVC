using System; 

namespace NotowaniaMVC.Domain.DomainEntities
{
    public class PriceList
    {
        private int Id { get; set; }
        private Guid Guid { get; set; }
        private String Code { get; set; }
        private decimal PriceMin { get; set; }
        private decimal PriceMax { get; set; }
        private DateTime DateTo { get; set; }
        private DateTime DateOfQuotation { get; set; }
        private DateTime Created { get; set; }
        private DateTime Modified { get; set; }
        private int Modifier { get; set; }
        private int Creator { get; set; }
        private int Unit { get; set; } //jednostka
        private int Currency { get; set; } //waluta todo dodac tabele waluta i dodac klucz obcy

        private PriceList(string code, decimal priceMin, decimal priceMax, DateTime dateTo, DateTime dateOfQuotation, int unit, int currency)
        {
            Code = code;
            PriceMin = priceMin;
            PriceMax = priceMax;
            DateTo = dateTo;
            DateOfQuotation = dateOfQuotation;
            Unit = unit;
            Currency = currency;
        }

        private PriceList(string code, decimal priceMin, decimal priceMax)
        {
            Code = code;
            PriceMin = priceMin;
            PriceMax = priceMax; 
        }

        public static class Factory
        {
            public static PriceList Create(string code, decimal priceMin, decimal priceMax, DateTime dateTo, DateTime dateOfQuotation, int unit, int currency)
            {
                return new PriceList(code, priceMin, priceMax, dateTo, dateOfQuotation, unit, currency);
            }

            public static PriceList Create(string code, decimal priceMin, decimal priceMax)
            {
                return new PriceList(code, priceMin, priceMax);
            }
        }
    }
}
