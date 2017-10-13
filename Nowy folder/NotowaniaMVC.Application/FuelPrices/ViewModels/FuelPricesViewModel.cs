using System;
using System.Collections.Generic; 
using System.Linq;
using System.Web;

namespace NotowaniaMVC.Application.FuelPrices.ViewModels
{
    public class FuelPricesViewModel
    { 
        public int Id { get; set; }

        public decimal Netto { get; set; }
        public decimal Vat { get; set; }


        public decimal FuelPriceMinNetto { get; set; }

        public decimal FuelPriceMaxNetto { get; set; }

        public decimal FuelPriceMinBrutto { get; set; }

        public decimal FuelPriceMaxBrutto { get; set; }

        public decimal Rebate { get; set; }

        public int DeliveryMinValue { get; set; }
        public int DeliveryMaxValue { get; set; }

        public string DeliveryCombinedValue { get; set; }

        public int UGM { get; set; }

        public int Unit { get; set; }

        public int FormOfCooperationId { get; set; }
        public string FormOfCooperationName { get; set; }

        public int CurrencyId { get; set; } //id waluty
        public string CurrencyName { get; set; } //waluta skrót nazwy

        public decimal MinRebate { get; set; }
    }
}