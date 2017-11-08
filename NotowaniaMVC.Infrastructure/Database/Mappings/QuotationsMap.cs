using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.Entities;

namespace NotowaniaMVC.Infrastructure.Database.Mappings
{
    public class QuotationsMap : ClassMap<XXX_R55_Quotations>
    {
        //Mapowanie encji Notowań na tabelę bazodanową
        public QuotationsMap()
        {
            Table("XXX_R55_QUOTATIONS");
            Id(c => c.Id, "ID").Not.Nullable().GeneratedBy.Native(builder => builder.AddParam("sequence", "SEQ_QUOT"));
            Map(c => c.Guid, "GUID");
            References(c => c.Fuel, "FUEL");
            Map(c => c.Code, "CODE");
            References(c => c.Region, "REGION");
            Map(c => c.PriceMin, "PRICE_MIN");
            Map(c => c.PriceMax, "PRICE_MAX");
            Map(c => c.DateTo, "DATE_TO");
            Map(c => c.DateOfQuotation, "DATE_OF_QUOTATION");
            References(c => c.Company, "COMPANY");
            References(c => c.Unit, "UNIT");
            References(c => c.Currency, "CURRENCY");
            Map(c => c.Created, "CREATED");
            Map(c => c.Modified, "MODIFIED");
            Map(c => c.Creator, "CREATOR"); 
            References(c => c.Document, "ID_DOCUMENT");
            Map(c => c.Modifier, "MODIFIER");
        }
    }
}
