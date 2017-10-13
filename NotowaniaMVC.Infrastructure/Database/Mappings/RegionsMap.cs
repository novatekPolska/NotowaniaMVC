﻿using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.Entities;

namespace NotowaniaMVC.Infrastructure.Database.Mappings
{
    public class RegionsMap : ClassMap<XXX_R55_Regions>
    {
        //Mapowanie encji Regionów sprzedaży na tabelę bazodanową
        public RegionsMap()
        {
            Id(c => c.Id);
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