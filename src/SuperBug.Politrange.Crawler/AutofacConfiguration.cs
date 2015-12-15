using Autofac;
using Autofac.Extras.NLog;
using SuperBug.Politrange.Data.Contexts;
using SuperBug.Politrange.Data.Repositories;
using SuperBug.Politrange.Services.Sites;

namespace SuperBug.Politrange.Crawler
{
    public class AutofacConfiguration
    {
        public static IContainer BuildAutofacContainer()
        {
            var builder = new ContainerBuilder();
            
            RegisterComponents(builder);

            IContainer container = builder.Build();

            return container;
        }

        private static void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterModule<NLogModule>();

            builder.RegisterType<PolitrangeContext>().OwnedByLifetimeScope();
            builder.RegisterType<SiteRepository>().As<ISiteRepository>();
            builder.RegisterType<CrawlerManage>().InstancePerLifetimeScope();
        }
    }
}