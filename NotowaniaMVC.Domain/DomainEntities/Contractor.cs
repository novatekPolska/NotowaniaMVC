using System; 

namespace NotowaniaMVC.Domain.DomainEntities
{
    public class Contractor
    {
        private int Id { get; set; } 
        private DateTime Created { get; set; }
        private DateTime Modified { get; set; }
        private int Modifier { get; set; }
        private int Creator { get; set; }
    }
}
