using NHibernate.Mapping.Attributes;
using System;

namespace NotowaniaMVC.Infrastructure.Database.ExistingEntities
{
    public class CardGroupsDb
    {
        [Key]
        [Id]
        public virtual int Id { get; set; }
        public virtual string GroupCode { get; set; }
        public virtual string GroupName { get; set; }
        public virtual bool Zero { get; set; }
        public virtual bool Active { get; set; }
        public virtual string CombinedCode { get; set; }
        public virtual string CombinedName { get; set; } 
        public virtual DictionaryDb DictionaryId { get; set; } 
        public virtual CardGroupsDb CardGroupId { get; set; }  
        public virtual CardGroupTypesDb CardGroupType { get; set; }  
    }
}
