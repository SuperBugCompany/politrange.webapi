using AutoMapper;
using SuperBug.Politrange.Api.Models.Models;
using SuperBug.Politrange.Api.Models.ViewModels;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Api.Mappers
{
    public class DomainToViewModelMappingProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<PersonPageRank, CommonStatViewModel>();
            Mapper.CreateMap<Site, SiteViewModel>();
            Mapper.CreateMap<Person, PersonViewModel>();
            Mapper.CreateMap<Keyword, KeywordViewModel>();
            Mapper.CreateMap<Page, PageViewModel>();
            Mapper.CreateMap<RangeDatePersonRank, RangeDateStatViewModel>()
                  .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.FoundDate))
                  .ForMember(dest => dest.Persons, opt => opt.MapFrom(src => src.PersonPageRanks));
            Mapper.CreateMap<PersonPageRank, PersonRankViewModel>()
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Person.Name));
        }
    }
}