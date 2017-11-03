using AutoMapper;
using NotowaniaMVC.Application.Quotations.ViewModels;
using NotowaniaMVC.Domain.DomainEntities; 

namespace NotowaniaMVC.Application.Quotations.Mappings
{
    public class QuotationMapper
    { 
        public Quotation MapNewQuotationViewModelToQuotationDomainModel(NewQuotationViewModel quotationViewModel)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Quotation, NewQuotationViewModel>()
                .ForMember(dst => dst.Id, src => src.MapFrom<int>(e => quotationViewModel.Id))
                .ForMember(dst => dst.Currency, src => src.MapFrom(e => e.Currency))
                .ForMember(dst => dst.FuelType, src => src.MapFrom(e => e.Fuel))
                .ForMember(dst => dst.QuotationType, src => src.MapFrom(e => e.QuotationType))
                .ForMember(dst => dst.QuotationDate, src => src.MapFrom(e => e.DateOfQuotation))
                .ForMember(dst => dst.PriceNettoMax, src => src.MapFrom(e => e.PriceMax))
                .ForMember(dst => dst.Unit, src => src.MapFrom(e => e.Unit))
                .ForMember(dst => dst.PriceNettoMin, src => src.MapFrom(e => e.PriceMin));
            });
            
            IMapper mapper = config.CreateMapper(); 
            var dest = mapper.Map<NewQuotationViewModel, Quotation>(quotationViewModel);
             
            return Mapper.Map<Quotation>(quotationViewModel);
        }
    }
}
