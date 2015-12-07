using Autofac;
using SuperBug.Politrange.Data.Fakes.Repositories;
using SuperBug.Politrange.Data.Repositories;

namespace SuperBug.Politrange.Data.Fakes
{
    public class DataFakeModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StatRepositoryFake>().As<IStatRepository>().SingleInstance();
            builder.RegisterType<SiteRepositoryFake>().As<ISiteRepository>().SingleInstance();
            builder.RegisterType<PageRepositoryFake>().As<IPageRepository>().SingleInstance();
            builder.RegisterType<PersonRepositoryFake>().As<IPersonRepository>().SingleInstance();
            builder.RegisterType<KeywordRepositoryFake>().As<IKeywordRepository>().SingleInstance();
        }
    }
}