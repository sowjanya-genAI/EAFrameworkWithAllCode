using EABDDTests.Pages;
using EAFramework.Config;
using EAFramework.Driver;
using EAFramework.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;
using Reqnroll.Microsoft.Extensions.DependencyInjection;

namespace EABDDTests
{
    public class ReqnRollDIRegistry
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton(ReadConfig.ReadJsonFile());
            services.AddSingleton<IPlaywrightDriver, PlaywrightDriver>();
            //Initialize the Playwright Driver and return the IPage for you.
            services.AddSingleton<IPage>(p =>
            {
                var driver = p.GetRequiredService<IPlaywrightDriver>();
                return driver.InitializePlaywright().Result;
            });
            services.AddScoped<IProductDbContext, ProductDbContext>();
            services.AddTransient<IBasePage, BasePage>();

            return services;
        }
    }
}
