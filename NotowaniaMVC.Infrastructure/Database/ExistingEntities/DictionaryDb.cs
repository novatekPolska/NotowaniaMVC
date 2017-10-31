using NHibernate.Mapping.Attributes; 

namespace NotowaniaMVC.Infrastructure.Database.ExistingEntities
{
    public class DictionaryDb
    {
        [Key]
        [Id]
        public virtual int Id { get; set; }
        public virtual DictionaryDb DictionaryId { get; set; }
        public virtual ForTableDb TableId { get; set; }  
        public virtual CardGroupTypesDb GroupCardTypeId { get; set; }  
        public virtual AnaliticsDb AnaliticsId { get; set; } 
        public virtual string Name { get; set; }
        public virtual int BookkeepNumber { get; set; }  
        public virtual string Nip { get; set; }
        public virtual string Ponip { get; set; }
        public virtual string Pesel { get; set; }
        public virtual string Code { get; set; }
        public virtual int ConstantCode { get; set; }
        public virtual string CombinedCode { get; set; }
        public virtual string CombinedName { get; set; }
        public virtual CardGroupTypesDb2 GroupCardTypeId2 { get; set; }  
        public virtual DictionaryTypeDb DictionaryTypeId { get; set; }  
        public virtual string SimpleCombinedCode { get; set; }  
    }
}
