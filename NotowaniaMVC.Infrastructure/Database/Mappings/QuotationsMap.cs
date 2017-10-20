using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.Entities;

namespace NotowaniaMVC.Infrastructure.Database.Mappings
{
    public class QuotationsMap : ClassMap<XXX_R55_Quotations>
    {
        //Mapowanie encji Notowań na tabelę bazodanową
        public QuotationsMap()
        {
            Id(c => c.Id).Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_QUOT")); 
            Map(c => c.Guid); 
            References(c => c.Fuel);
            Map(c => c.Code); 
            References(c => c.Region); 
            References(c => c.PriceList); 
            References(c => c.Company);
            Map(c => c.Created);
            Map(c => c.Modified);
            Map(c => c.Creator);
            Map(c => c.Modifier);
        }
    }
}
