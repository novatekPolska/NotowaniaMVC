using System;

namespace NotowaniaMVC.Domain.DomainEntities
{
    public class Deliveries
    {
        private int Id { get; set; }
        private Guid Guid { get; set; }
        private decimal MinValue { get; set; }
        private decimal MaxValue { get; set; }
        private DateTime Created { get; set; }
        private DateTime Modified { get; set; }
        private int Modifier { get; set; }
        private int Creator { get; set; }
    }
}
