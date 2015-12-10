using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace SuperBug.Politrange.Services
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("SuperBug.Politrange.Services"))
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}