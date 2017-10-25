using FluentNHibernate.Mapping;
using NotowaniaMVC.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotowaniaMVC.Infrastructure.Database.Mappings
{
    class FuelTypesMap : ClassMap<XXX_R55_FuelTypes>
    {
        //Mapowanie encji rodzajów paliw na tabelę bazodanową
        public FuelTypesMap()
        {
            Id(c => c.Id);
            Map(c => c.Guid);
            Map(c => c.Name);
            Map(c => c.Code); 
            Map(c => c.Created);
            Map(c => c.Modified);
            Map(c => c.Creator);
            Map(c => c.Modifier);
        }
    }
}
