using System; 
using System.ComponentModel.DataAnnotations; 

namespace NotowaniaMVC.Application.Quotations.ViewModels
{
    public class QuotationsViewModel
    {
        public int Id { get; set; } 
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime QuotationDate { get; set; }
        public int FuelType { get; set; }
        public string FuelTypeName { get; set; }
        public int Currency { get; set; } //waluta
        public string CurrencyName { get; set; } //waluta - nazwa
        public int QuotationType { get; set; } //typ notowania np propan/butan/mix
        public string QuotationTypeName { get; set; }
        public decimal PriceNettoMin { get; set; }
        public decimal PriceNettoMax { get; set; } 
        public int PdfId { get; set; }
        public string PdfName { get; set; }
        public string PdfPath { get; set; }
        public int Unit { get; set; } 
        public string UnitName { get; set; }
    }
}
