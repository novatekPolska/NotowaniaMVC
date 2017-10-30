using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.Entities; 

namespace NotowaniaMVC.Infrastructure.Database.Mappings
{
    public class QuotationTypesMap : ClassMap<XXX_R55_QuotationTypes>
    {
        //Mapowanie encji Typów notowań na tabelę bazodanową
        public QuotationTypesMap()
        {
            Id(c => c.Id).Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_QUOT"));
            Map(c => c.Guid); 
            Map(c => c.Code);
            Map(c => c.Name);
            Map(c => c.Created);
            Map(c => c.Modified);
            Map(c => c.Creator);
            Map(c => c.Modifier);
        }
    }
}
