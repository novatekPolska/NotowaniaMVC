using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.Entities;

namespace NotowaniaMVC.Infrastructure.Database.Mappings
{
    public class PriceListsMap : ClassMap<XXX_R55_PriceLists>
    {
        //Mapowanie encji Cenników na tabelę bazodanową
        public PriceListsMap()
        {
            Table("XXX_R55_PRICE_LISTS");
            Id(c => c.Id, "ID").Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_PRL")); ;
            Map(c => c.Guid, "GUID");
            Map(c => c.Code, "CODE");
            Map(c => c.PriceMin, "PRICE_MIN");
            Map(c => c.PriceMax, "PRICE_MAX");
            References(c => c.Unit, "UNIT");
            References(c => c.Currency, "CURRENCY");
            Map(c => c.DateTo, "DATE_TO");
            Map(c => c.DateOfQuotation, "DATE_OF_QUOTATION");
            Map(c => c.Created, "CREATED");
            Map(c => c.Modified, "MODIFIED");
            Map(c => c.Creator, "CREATOR");
            Map(c => c.Modifier, "MODIFIER");
        }
    }
}
