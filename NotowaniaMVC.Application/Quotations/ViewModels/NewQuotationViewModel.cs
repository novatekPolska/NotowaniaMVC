using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace NotowaniaMVC.Application.Quotations.ViewModels
{
    public class NewQuotationViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime QuotationDate { get; set; }
        public int? FuelType { get; set; }
        public string FuelTypeName { get; set; }
        public int? Currency { get; set; } //waluta
        public string CurrencyName { get; set; } //waluta - nazwa
        public int? QuotationType { get; set; } //typ notowania np propan/butan/mix
        public string QuotationTypeName { get; set; }
        public decimal PriceNettoMin { get; set; }
        public decimal PriceNettoMax { get; set; }
        public Stream PdfFile { get; set; }
        public int? PdfId { get; set; }
        public string PdfName { get; set; }
        public string PdfPath { get; set; }
        public int? Unit { get; set; }

        //Zmiennne do wypelnienia kontrole ListBoxFor (Listy rozwijalne)
        //Teoretycznie powinny mieć one możliwosc załadowania źródła danych
        //ale akurat te nie maja
        //TODO spróbować później załadować to źródło ajaxem
        public IDictionary CurrencyTypes { get; set; } //TODO to nie powinno byc w modelu ale kontrolka mnie ogranicza
        public IDictionary FuelTypes { get; set; }
        public IDictionary QuotationTypes { get; set; }
        public IDictionary Units { get; set; }
    }
}
