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
    }
}
