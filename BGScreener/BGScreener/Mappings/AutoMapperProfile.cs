using AutoMapper;
using BGScreener.DbModels;
using BGScreener.Model;

namespace BGScreener.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StoreDTO, Store>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.CountryName));
            CreateMap<CountryDTO, Country>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CountryName))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency.IsoCode));
            CreateMap<CurrencyDTO, Currency>();

            //CreateMap<Country, DbcCountry>()
            //    .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
