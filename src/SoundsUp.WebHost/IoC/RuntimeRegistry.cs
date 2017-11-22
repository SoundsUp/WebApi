using StructureMap;

namespace SoundsUp.WebHost.IoC
{
    public class RuntimeRegistry : Registry
    {
        public RuntimeRegistry()
        {
            Scan(x =>
            {
                x.AssembliesAndExecutablesFromApplicationBaseDirectory();
                x.WithDefaultConventions();
            });

            //For<ILogger<CustomerManager>>().Singleton().Use<Logger<CustomerManager>>();

            //For<ILogger>().Use<Logger<CustomerManager>>();
        }
    }
}