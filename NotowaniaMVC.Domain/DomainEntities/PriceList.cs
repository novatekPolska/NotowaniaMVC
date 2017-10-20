using System;
using NotowaniaMVC.Infrastructure.FuelPrices.Interfaces;
using NotowaniaMVC.Infrastructure.FuelPrices.Repositories;

namespace NotowaniaMVC.Domain.DomainEntities
{
    public class PriceList
    {
        private int Id { get; set; }
        private Guid Guid { get; set; }
        private String Code { get; set; }
        private decimal PriceNettoMin { get; set; }
        private decimal PriceNettoMax { get; set; }
        private decimal PriceBruttoMin { get; set; }
        private decimal PriceBruttoMax { get; set; }
        private DateTime DateTo { get; set; }
        private DateTime DateOfQuotation { get; set; }
        private DateTime Created { get; set; }
        private DateTime Modified { get; set; }
        private int Modifier { get; set; }
        private int Creator { get; set; }
        private int Unit { get; set; } //jednostka
        private int Currency { get; set; } //waluta todo dodac tabele waluta i dodac klucz obcy

        private readonly IPriceListsRepository _priceListsRepository;
        public PriceList(IPriceListsRepository priceListsRepository)
        {
            _priceListsRepository = priceListsRepository;
        }

        private PriceList(string code, decimal priceNettoMin, decimal priceNettoMax, decimal priceBruttoMin, decimal priceBruttoMax, DateTime dateTo, DateTime dateOfQuotation, int unit, int currency)
        {
            Code = code;
            PriceNettoMin = priceNettoMin;
            PriceNettoMax = priceNettoMax;
            PriceBruttoMin = priceBruttoMin;
            PriceBruttoMax = priceBruttoMax;
            DateTo = dateTo;
            DateOfQuotation = dateOfQuotation;
            Unit = unit;
            Currency = currency;
        }

        private PriceList(string code, decimal priceNettoMin, decimal priceNettoMax, decimal priceBruttoMin, decimal priceBruttoMax)
        {
            Code = code;
            PriceNettoMin = priceNettoMin;
            PriceNettoMax = priceNettoMax;
            PriceBruttoMin = priceBruttoMin;
            PriceBruttoMax = priceBruttoMax;
        }

        public int GetId()
        {
            return Id;
        }

        public void Validate()
        { 
        }

        public void Add()
        { 
        }

        public void Update()
        { 
        }

        public void Save()
        {
        }

        public static class Factory
        {
            public static PriceList Create(string code, decimal priceNettoMin, decimal priceNettoMax, decimal priceBruttoMin, decimal priceBruttoMax, DateTime dateTo, DateTime dateOfQuotation, int unit, int currency)
            {
                return new PriceList(code, priceNettoMin, priceNettoMax, priceBruttoMin, priceBruttoMax, dateTo, dateOfQuotation, unit, currency);
            }

            public static PriceList Create(string code, decimal priceNettoMin, decimal priceNettoMax, decimal priceBruttoMin, decimal priceBruttoMax)
            {
                return new PriceList(code, priceNettoMin, priceNettoMax, priceBruttoMin, priceBruttoMax);
            }
        }
    }
}
