using System.Collections.Generic;
using AutoMapper;
using BGScreener.DbModels;
using BGScreener.Model;

namespace BGScreener.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Currency, CurrencyDTO>()
                .ForMember(dest => dest.IsoCode, opt => opt.MapFrom(src => src.IsoCode));

            CreateMap<Country, CountryDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForPath(dest => dest.Currency.IsoCode, opt => opt.MapFrom(src => src.Currency));

            CreateMap<Store, StoreDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForPath(dest => dest.Country.Name, opt => opt.MapFrom(src => src.Country));

            CreateMap<Boardgame, BoardgameDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<CountryDTO, Country>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency.IsoCode));

            CreateMap<CurrencyDTO, Currency>();
        }
    }
}
