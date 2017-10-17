using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.Entities;

namespace NotowaniaMVC.Infrastructure.Database.Mappings
{
    public class DocumentsMap : ClassMap<XXX_R55_Documents>
    {
        //Mapowanie encji Dokumentów na tabelę bazodanową
        public DocumentsMap()
        {
            Id(c => c.Id);
            Map(c => c.Guid);
            Map(c => c.Link);
            Map(c => c.Code); 
            References(c => c.Quotation);
            Map(c => c.Created);
            Map(c => c.Modified);
            Map(c => c.Creator);
            Map(c => c.Modifier);
        }
    }
}
