using NHibernate.Mapping.Attributes; 

namespace NotowaniaMVC.Infrastructure.Database.ExistingEntities
{
    public class DictionaryTypeDb
    {
        [Key]
        [Id]
        public virtual int Id { get; set; }
        public virtual ForTableDb TableId { get; set; }  
        public virtual CardGroupTypesDb CardGroupTypeId { get; set; }  
        public virtual CardGroupTypesDb2 CardGroupTypeId2 { get; set; }  
        public virtual string Name { get; set; }
        public virtual StCardGroupTypesDb StGroupTypeId { get; set; } 
        public virtual int DictionaryType { get; set; }
        public virtual int LawType { get; set; }
        public virtual int IsSubjectToSettlement { get; set; }
    }
}
