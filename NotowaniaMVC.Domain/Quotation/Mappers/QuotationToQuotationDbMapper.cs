using AutoMapper; 
using NotowaniaMVC.Infrastructure.Database.Entities;

namespace NotowaniaMVC.Domain.Quotations.Mappers
{ 
    public class QuotationToQuotationDbMapper  
    { 
        public XXX_R55_Quotations Map(DomainEntities.Quotation quotation)
        {
            // w tym przypadku automapper z kilku powodów
            // a) google -> n=1 problem
            // b) w momencie kiedy stworzymy konstruktor dla fabryki w encji domenowej, nhibernate wymusza stworzenie konstruktora publicznego 
            // bezparametrowego, a to burzy cały sens fabryki. Dlatego tez z resztą na chwilę obecną mamy osobne encje domenowe i db
            // chociaz w praktyce w zasadzie powinna to byc ta sama encja
            // encje osobne mamy tez z innych powodów - np bedziemy zmieniac baze podobno na mssql, bedziemy łaczyc sie z wieloma bazami, ogólnie 
            // projekt infrastrukture będzie szerokowykorzystywany tez w innych projektach stąd musi być całkiem niezależnym bytem
            Mapper.Initialize(cfg => {
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Quotations>().ForMember(dst => dst.Code, src => src.MapFrom(e=>e.Code));
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Quotations>().ForMember(dst => dst.Company.Id, src => src.MapFrom(e => e.Company));
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Quotations>().ForMember(dst => dst.Created, src => src.MapFrom(e => e.Created));
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Quotations>().ForMember(dst => dst.Creator, src => src.MapFrom(e => e.Creator));
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Quotations>().ForMember(dst => dst.Currency.Id, src => src.MapFrom(e => e.Currency)); 
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Quotations>().ForMember(dst => dst.Modified, src => src.MapFrom(e => e.Modified));
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Quotations>().ForMember(dst => dst.Modifier, src => src.MapFrom(e => e.Modifier));
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Quotations>().ForMember(dst => dst.PriceMax, src => src.MapFrom(e => e.PriceMax));
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Quotations>().ForMember(dst => dst.PriceMin, src => src.MapFrom(e => e.PriceMin));
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Quotations>().ForMember(dst => dst.QuotationType.Id, src => src.MapFrom(e => e.QuotationType));
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Quotations>().ForMember(dst => dst.Region.Id, src => src.MapFrom(e => e.Region));
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Quotations>().ForMember(dst => dst.Unit.Id, src => src.MapFrom(e => e.Unit));
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Quotations>().ForMember(dst => dst.Fuel.Id, src => src.MapFrom(e => e.Fuel));
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Quotations>().ForMember(dst => dst.Guid, src => src.MapFrom(e => e.Guid));
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Quotations>().ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id));
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Quotations>().ForMember(dst => dst.Document.Id, src => src.MapFrom(e => e.DocumentId));
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Quotations>().ForMember(dst => dst.DateOfQuotation, src => src.MapFrom(e => e.DateOfQuotation));
                cfg.CreateMap<DomainEntities.Quotation, XXX_R55_Quotations>().ForMember(dst => dst.DateTo, src => src.MapFrom(e => e.DateTo)); 
            }); 

            return Mapper.Map<DomainEntities.Quotation, XXX_R55_Quotations>(quotation);
        }
    } 
}