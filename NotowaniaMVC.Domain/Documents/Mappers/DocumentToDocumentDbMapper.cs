using AutoMapper;
using NotowaniaMVC.Infrastructure.Database.Entities;

namespace NotowaniaMVC.Domain.Documents.Mappers
{
    public class DocumentToDocumentDbMapper
    {
        public XXX_R55_Documents Map(DomainEntities.Document document)
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<DomainEntities.Document, XXX_R55_Documents>().ForMember(dst => dst.Code, src => src.MapFrom(e => e.Code)); 
                cfg.CreateMap<DomainEntities.Document, XXX_R55_Documents>().ForMember(dst => dst.Created, src => src.MapFrom(e => e.Created));
                cfg.CreateMap<DomainEntities.Document, XXX_R55_Documents>().ForMember(dst => dst.Creator, src => src.MapFrom(e => e.Creator));  
                cfg.CreateMap<DomainEntities.Document, XXX_R55_Documents>().ForMember(dst => dst.Modified, src => src.MapFrom(e => e.Modified));
                cfg.CreateMap<DomainEntities.Document, XXX_R55_Documents>().ForMember(dst => dst.Modifier, src => src.MapFrom(e => e.Modifier));
                cfg.CreateMap<DomainEntities.Document, XXX_R55_Documents>().ForMember(dst => dst.Guid, src => src.MapFrom(e => e.Guid));
                cfg.CreateMap<DomainEntities.Document, XXX_R55_Documents>().ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id));
                cfg.CreateMap<DomainEntities.Document, XXX_R55_Documents>().ForMember(dst => dst.Link, src => src.MapFrom(e => e.Link));
                cfg.CreateMap<DomainEntities.Document, XXX_R55_Documents>().ForMember(dst => dst.Name, src => src.MapFrom(e => e.Name)); 
            });

            return Mapper.Map<DomainEntities.Document, XXX_R55_Documents>(document);
        }
    }
}
