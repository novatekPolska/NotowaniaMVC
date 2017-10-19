﻿using System; 

namespace NotowaniaMVC.Domain.DomainEntities
{
    public class Fuel
    {
        private int Id { get; set; }
        private Guid Guid { get; set; }
        private string Code { get; set; }
        private string Name { get; set; }
        private decimal Density { get; set; } //gęstoć paliwa 
        private DateTime Created { get; set; }
        private DateTime Modified { get; set; }
        private int Modifier { get; set; }
        private int Creator { get; set; }
    }
}
