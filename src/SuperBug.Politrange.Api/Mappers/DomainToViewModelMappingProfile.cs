using AutoMapper;
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
		    Mapper.CreateMap<PersonPageRank, RangeStatViewModel>();
		}
	}
}