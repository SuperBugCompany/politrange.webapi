using Autofac;
using Autofac.Core;
using SuperBug.Politrange.Services.Keywords;
using SuperBug.Politrange.Services.Pages;
using SuperBug.Politrange.Services.Persons;
using SuperBug.Politrange.Services.Sites;
using SuperBug.Politrange.Services.States;

namespace SuperBug.Politrange.Services
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SiteService>().As<ISiteService>();
            builder.RegisterType<StatService>().As<IStatService>();
            builder.RegisterType<PersonService>().As<IPersonService>();
            builder.RegisterType<PageService>().As<IPageService>();
            builder.RegisterType<KeyedService>().As<IKeywordService>();
        }
    }
}