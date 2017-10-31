using NHibernate.Mapping.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotowaniaMVC.Infrastructure.Database.ExistingEntities
{
    public class ForTableDb
    {
        [Key]
        [Id]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Type { get; set; }
    }
}
