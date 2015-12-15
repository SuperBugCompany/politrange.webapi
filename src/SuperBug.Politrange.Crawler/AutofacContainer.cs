using Autofac;

namespace SuperBug.Politrange.Crawler
{
    public class AutofacContainer
    {
        private static IContainer container;

        public static IContainer Get()
        {
            return container ?? (container = AutofacConfiguration.BuildAutofacContainer());
        }
    }
}