using System; 

namespace NotowaniaMVC.Domain.DomainEntities
{
    public class Quotation
    {
        private int Id { get; set; }
        private Guid Guid { get; set; }
        private string Code { get; set; }
        private DateTime Created { get; set; }
        private DateTime Modified { get; set; }
        private int Modifier { get; set; }
        private int Creator { get; set; } 
        private int Fuel { get; set; }
        private int Region { get; set; }
        private int PriceList { get; set; }
        private int Company { get; set; }
    }
}
