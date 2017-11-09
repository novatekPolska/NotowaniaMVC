using AutoMapper;
using NotowaniaMVC.Domain.Quotation.Interfaces;
using NotowaniaMVC.Infrastructure.Database.Entities;
using NotowaniaMVC.Infrastructure.Database.ExistingEntities;

namespace NotowaniaMVC.Domain.Quotations.Mappers
{ 
    public class QuotationToQuotationDbMapper: IQuotationToQuotationDbMapper
    { 
        public XXX_R55_Quotations Map(DomainEntities.Quotation quotation)
        {
           // AutoMapperWebConfiguration.Configure();
            // w tym przypadku automapper z kilku powodów
            // a) google -> n=1 problem
            // b) w momencie kiedy stworzymy konstruktor dla fabryki w encji domenowej, nhibernate wymusza stworzenie konstruktora publicznego 
            // bezparametrowego, a to burzy cały sens fabryki. Dlatego tez z resztą na chwilę obecną mamy osobne encje domenowe i db
            // chociaz w praktyce w zasadzie powinna to byc ta sama encja
            // encje osobne mamy tez z innych powodów - np bedziemy zmieniac baze podobno na mssql, bedziemy łaczyc sie z wieloma bazami, ogólnie 
            // projekt infrastrukture będzie szerokowykorzystywany tez w innych projektach stąd musi być całkiem niezależnym bytem
            Mapper.Initialize(cfg => {
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_FuelTypes>().ForMember(dst => dst.Id, src => src.MapFrom(e => e.Fuel));
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Companies>().ForMember(dst => dst.Id, src => src.MapFrom(e => e.Company));
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_QuotationTypes>().ForMember(dst => dst.Id, src => src.MapFrom(e => e.QuotationType));
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Regions>().ForMember(dst => dst.Id, src => src.MapFrom(e => e.Region));
                cfg.CreateMap<DomainEntities.Quotation, UnitsDb>().ForMember(dst => dst.Id, src => src.MapFrom(e => e.Unit));
                cfg.CreateMap<DomainEntities.Quotation, CurrencyDb>().ForMember(dst => dst.Id, src => src.MapFrom(e => e.Currency));
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Documents>().ForMember(dst => dst.Id, src => src.MapFrom(e => e.DocumentId));

                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Quotations>()
                .ForMember(dst => dst.Code, src => src.MapFrom(e => e.Code))
                .ForMember(dst => dst.Created, src => src.MapFrom(e => e.Created))
                .ForMember(dst => dst.Creator, src => src.MapFrom(e => e.Creator))
                .ForMember(dst => dst.Modified, src => src.MapFrom(e => e.Modified))
                .ForMember(dst => dst.Modifier, src => src.MapFrom(e => e.Modifier))
                .ForMember(dst => dst.PriceMax, src => src.MapFrom(e => e.PriceMax))
                .ForMember(dst => dst.PriceMin, src => src.MapFrom(e => e.PriceMin))
                .ForMember(dst => dst.DateOfQuotation, src => src.MapFrom(e => e.DateOfQuotation))
                .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
                .ForMember(dst => dst.Guid, src => src.MapFrom(e => e.Guid))
                .ForMember(dst => dst.DateTo, src => src.MapFrom(e => e.DateTo))
                .ForMember(dst => dst.Fuel, src => src.MapFrom(e => e.Fuel == null ? null : Mapper.Map<DomainEntities.Quotation, XXX_R55_FuelTypes>(e)))
                .ForMember(dst => dst.Company, src => src.MapFrom(e => e.Company == null ? null : Mapper.Map<DomainEntities.Quotation, XXX_R55_Companies>(e)))
                .ForMember(dst => dst.QuotationType, src => src.MapFrom(e => e.QuotationType == null ? null :  Mapper.Map<DomainEntities.Quotation, XXX_R55_QuotationTypes>(e)))
                .ForMember(dst => dst.Region, src => src.MapFrom(e => e.Region == null ? null : Mapper.Map<DomainEntities.Quotation, XXX_R55_Regions>(e)))
                .ForMember(dst => dst.Unit, src => src.MapFrom(e => e.Unit == null ? null : Mapper.Map<DomainEntities.Quotation, UnitsDb>(e)))
                .ForMember(dst => dst.Currency, src => src.MapFrom(e => e.Currency == null ? null : Mapper.Map<DomainEntities.Quotation, CurrencyDb>(e)))
                .ForMember(dst => dst.Document, src => src.MapFrom(e => e.DocumentId == null ? null : Mapper.Map<DomainEntities.Quotation, XXX_R55_Documents>(e))); 
            }); 

            return Mapper.Map<DomainEntities.Quotation, XXX_R55_Quotations>(quotation);
        }
    } 
}