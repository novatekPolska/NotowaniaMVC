using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.Entities;

namespace NotowaniaMVC.Infrastructure.Database.Mappings
{
    public class DocumentsMap : ClassMap<XXX_R55_Documents>
    {
        //Mapowanie encji Dokumentów na tabelę bazodanową
        public DocumentsMap()
        {
            Table("XXX_R55_DOCUMENTS");
            Id(c => c.Id, "ID").Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_DOC")); ;
            Map(c => c.Guid, "GUID");
            Map(c => c.Link, "LINK");
            Map(c => c.Code, "CODE"); 
            Map(c => c.Created, "CREATED");
            Map(c => c.Modified, "MODIFIED");
            Map(c => c.Creator, "CREATOR");
            Map(c => c.Modifier, "MODIFIER");
            Map(c => c.Name, "NAME");
        }
    }
}
