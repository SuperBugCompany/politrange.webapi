using System.Reflection;
using Autofac;
using Autofac.Extras.NLog;
using SuperBug.Politrange.Data.Contexts;
using Module = Autofac.Module;

namespace SuperBug.Politrange.Data
{
    public class DataModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<NLogModule>();

            builder.RegisterAssemblyTypes(Assembly.Load("SuperBug.Politrange.Data"))
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}