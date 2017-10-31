using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.ExistingEntities; 

namespace NotowaniaMVC.Infrastructure.Database.ExistingEntitiesMappings
{
    public class ForTableMap : ClassMap<ForTableDb>
    {
        public ForTableMap()
        { 
            Table("DLATABELI");
            Id(c => c.Id, "ID_DLATABELI").Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_GKT")); ;
            Map(c => c.Name, "NAZWA").Not.Nullable().Length(50);
            Map(c => c.Type, "RODZAJ").Not.Nullable(); 
        }
    }
}
