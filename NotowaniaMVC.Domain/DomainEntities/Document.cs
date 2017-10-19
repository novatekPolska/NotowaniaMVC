using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotowaniaMVC.Domain.DomainEntities
{
    public class Document
    {
        private int Id { get; set; }
        private Guid Guid { get; set; }
        private string Code { get; set; }
        private string Link { get; set; }
        private int Quotation { get; set; }
        private DateTime Created { get; set; }
        private DateTime Modified { get; set; }
        private int Modifier { get; set; }
        private int Creator { get; set; }
    }
}
