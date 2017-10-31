using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.Entities; 

namespace NotowaniaMVC.Infrastructure.Database.Mappings
{
    public class QuotationTypesMap : ClassMap<XXX_R55_QuotationTypes>
    {
        //Mapowanie encji Typów notowań na tabelę bazodanową
        public QuotationTypesMap()
        {
            Table("XXX_R55_QUOTATION_TYPES");
            Id(c => c.Id, "ID").Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_QUOTT"));
            Map(c => c.Guid, "GUID"); 
            Map(c => c.Code, "CODE");
            Map(c => c.Name, "NAME");
            Map(c => c.Created, "CREATED");
            Map(c => c.Modified, "MODIFIED");
            Map(c => c.Creator, "CREATOR");
            Map(c => c.Modifier, "MODIFIER");
        }
    }
}
