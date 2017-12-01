using Humanizer;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace SoundsUp.Data
{
    public class MyDesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection services)
        {
            services.AddSingleton<IPluralizer, Pluralizer>();
        }
    }

    public class Pluralizer : IPluralizer
    {
        public string Pluralize(string name)
        {
            return name.Pluralize();
        }

        public string Singularize(string name)
        {
            return name.Singularize();
        }
    }
}