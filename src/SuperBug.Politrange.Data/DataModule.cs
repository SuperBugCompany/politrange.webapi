using Autofac;
using SuperBug.Politrange.Data.Contexts;
using SuperBug.Politrange.Data.Repositories;

namespace SuperBug.Politrange.Data
{
    public class DataModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PolitrangeContext>().InstancePerRequest();
            builder.RegisterType<KeywordRepository>().As<IKeywordRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PersonRepository>().As<IPersonRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SiteRepository>().As<ISiteRepository>().InstancePerLifetimeScope();
            builder.RegisterType<StatRepository>().As<IStatRepository>().InstancePerLifetimeScope();
        }
    }
}