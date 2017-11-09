using AutoMapper;
using NotowaniaMVC.Domain.Documents.Interfaces;
using NotowaniaMVC.Infrastructure.Database.Entities;

namespace NotowaniaMVC.Domain.Documents.Mappers
{
    public class DocumentToDocumentDbMapper : IDocumentToDocumentDbMapper
    {
        public XXX_R55_Documents Map(DomainEntities.Document document)
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<DomainEntities.Document, XXX_R55_Documents>().ForMember(dst => dst.Code, src => src.MapFrom(e => e.Code))
                .ForMember(dst => dst.Created, src => src.MapFrom(e => e.Created))
                .ForMember(dst => dst.Creator, src => src.MapFrom(e => e.Creator)) 
                .ForMember(dst => dst.Modified, src => src.MapFrom(e => e.Modified))
                .ForMember(dst => dst.Modifier, src => src.MapFrom(e => e.Modifier))
                .ForMember(dst => dst.Guid, src => src.MapFrom(e => e.Guid))
                .ForMember(dst => dst.Id, src => src.MapFrom(e => e.Id))
                .ForMember(dst => dst.Link, src => src.MapFrom(e => e.Link))
                .ForMember(dst => dst.Name, src => src.MapFrom(e => e.Name)); 
            });

            return Mapper.Map<DomainEntities.Document, XXX_R55_Documents>(document);
        }
    }
}
