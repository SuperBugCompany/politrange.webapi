using AutoMapper;
using SuperBug.Politrange.Api.Models.ViewModels;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Api.Mappers
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<SiteViewModel, Site>();
            Mapper.CreateMap<PersonViewModel, Person>();
            Mapper.CreateMap<KeywordViewModel, Keyword>();

        }
    }
}