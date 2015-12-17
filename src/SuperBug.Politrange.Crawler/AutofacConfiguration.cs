using Autofac;
using Autofac.Extras.NLog;
using SuperBug.Politrange.Crawler.Downloaders;
using SuperBug.Politrange.Data.Contexts;
using SuperBug.Politrange.Data.Repositories;

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

            builder.RegisterType<PolitrangeContext>().OwnedByLifetimeScope().SingleInstance();

            builder.RegisterType<SiteRepository>().As<ISiteRepository>();
            builder.RegisterType<PageRepository>().As<IPageRepository>();
            builder.RegisterType<PersonRepository>().As<IPersonRepository>();
            builder.RegisterType<PersonPageRankRepository>().As<IPersonPageRankRepository>();

            builder.RegisterType<CrawlerManage>().InstancePerLifetimeScope();

            builder.RegisterType<CrawlerProcessing>().InstancePerLifetimeScope();

            builder.RegisterType<StorageService>().As<IStorageService>();

            builder.RegisterType<Downloader>().As<IDownloader>();
            builder.RegisterType<DownloadService>().As<IDownloadService>();

            builder.RegisterType<UrlService>().As<IUrlService>();

            builder.RegisterType<CrawlerPersonRankService>().As<ICrawlerPersonRankService>();
        }
    }
}