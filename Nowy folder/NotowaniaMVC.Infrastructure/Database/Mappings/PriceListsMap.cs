using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.Entities;

namespace NotowaniaMVC.Infrastructure.Database.Mappings
{
    public class PriceListsMap : ClassMap<XXX_R55_PriceLists>
    {
        //Mapowanie encji Cenników na tabelę bazodanową
        public PriceListsMap()
        {
            Id(c => c.Id);
            Map(c => c.Guid); 
            Map(c => c.Code);
            Map(c => c.PriceMin);
            Map(c => c.PriceMax);
            Map(c => c.Unit); 
            Map(c => c.Currency);
            Map(c => c.DateTo);
            Map(c => c.DateOfQuotation); 
            Map(c => c.Created);
            Map(c => c.Modified);
            Map(c => c.Creator);
            Map(c => c.Modifier);
        }
    }
}
