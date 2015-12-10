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
            builder.RegisterType<SiteService>().As<ISiteService>().InstancePerLifetimeScope();
            builder.RegisterType<StatService>().As<IStatService>().InstancePerLifetimeScope();
            builder.RegisterType<PersonService>().As<IPersonService>().InstancePerLifetimeScope();
            builder.RegisterType<PageService>().As<IPageService>().InstancePerLifetimeScope();
            builder.RegisterType<KeywordService>().As<IKeywordService>().InstancePerLifetimeScope();
        }
    }
}