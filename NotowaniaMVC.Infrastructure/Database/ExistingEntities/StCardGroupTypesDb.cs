﻿using NHibernate.Mapping.Attributes; 

namespace NotowaniaMVC.Infrastructure.Database.ExistingEntities
{
    public class StCardGroupTypesDb
    {
        [Key]
        [Id]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual bool Required { get; set; }
    }
}
