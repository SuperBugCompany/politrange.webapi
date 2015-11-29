using Autofac;
using SuperBug.Politrange.Data.Fakes.Repositories;
using SuperBug.Politrange.Data.Repositories;

namespace SuperBug.Politrange.Data.Fakes
{
    public class DataFakeModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SiteRepositoryFake>().As<ISiteRepository>().SingleInstance();
        }
    }
}