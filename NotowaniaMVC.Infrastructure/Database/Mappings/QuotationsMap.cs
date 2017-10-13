using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.Entities;

namespace NotowaniaMVC.Infrastructure.Database.Mappings
{
    public class QuotationsMap : ClassMap<XXX_R55_Quotations>
    {
        //Mapowanie encji Notowań na tabelę bazodanową
        public QuotationsMap()
        {
            Id(c => c.Id);
            Map(c => c.Guid);
            Map(c => c.Fuel);
            Map(c => c.Code);
            Map(c => c.Region);
            Map(c => c.PriceList);
            Map(c => c.Company);
            Map(c => c.Created);
            Map(c => c.Modified);
            Map(c => c.Creator);
            Map(c => c.Modifier);
        }
    }
}
