using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotowaniaMVC.Infrastructure.Database.Entities
{
    public class XXX_R55_Deliveries
    {
        public virtual int Id { get; set; }
        public virtual Guid Guid { get; set; }
        public virtual decimal MinValue { get; set; }
        public virtual decimal MaxValue { get; set; }
    }
}
