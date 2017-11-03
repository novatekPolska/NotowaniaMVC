using NHibernate.Mapping.Attributes; 

namespace NotowaniaMVC.Infrastructure.Database.ExistingEntities
{
    public class AnaliticsDb
    {
        [Key]
        [Id]
        public virtual int Id { get; set; }
        public virtual ForTableDb TableId { get; set; }
        public virtual CardGroupTypesDb CardGroupTypeId { get; set; }
        public virtual CardGroupTypesDb2 CardGroupTypeId2 { get; set; }
        public virtual string Name { get; set; }
        public virtual DictionaryTypeDb DictionaryTypeId { get; set; }
        public virtual DictionaryDb DictionaryId { get; set; }
        public virtual bool Active { get; set; }
        public virtual int Type { get; set; }
        public virtual bool Exceptions { get; set; }
        public virtual int CharCount { get; set; }
        public virtual int PonipCount { get; set; }
        public virtual int ActionWhenPositionDoesNotExist { get; set; }

        public virtual int SPOSTWANALITYKI { get; set; } //todo przetlumaczyc
        public virtual bool PRZYDRUKROZBIC { get; set; } //todo przetlumaczyc
        public virtual bool ROZRACHUNKOWA { get; set; } //todo przetlumaczyc
        public virtual bool DistributorForWage { get; set; }  
        public virtual bool DOLACZ_ROZRACH_NAGLPK { get; set; } //todo przetłumaczyc
    }
}
