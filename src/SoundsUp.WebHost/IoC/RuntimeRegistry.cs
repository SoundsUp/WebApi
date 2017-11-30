using StructureMap;

namespace SoundsUp.WebHost.IoC
{
    public class RuntimeRegistry : Registry
    {
        public RuntimeRegistry()
        {
            // Choose configuration options for the assembly
            Scan(assembly =>
            {
                // 
                assembly.AssembliesAndExecutablesFromApplicationBaseDirectory();

                // Examples: IName for interface 
                assembly.WithDefaultConventions();
            });

            //For<ILogger<CustomerManager>>().Singleton().Use<Logger<CustomerManager>>();

            //For<ILogger>().Use<Logger<CustomerManager>>();
        }
    }
}