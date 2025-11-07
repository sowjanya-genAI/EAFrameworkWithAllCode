using EAFramework.Config;
using Microsoft.Playwright;
using System.Reflection;

namespace EAFramework.Driver
{
    public interface IPlaywrightDriver
    {
        Task<IPage> InitializePlaywright();
        Task<string> TaskScreenshotAsPathAsync(string fileName);
    }

    public class PlaywrightDriver :  IDisposable, IPlaywrightDriver
    {
        private IPage _page;
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _context;
        private readonly TestSettings _testSettings;

        public PlaywrightDriver(TestSettings testSettings)
        {
            _testSettings = testSettings;
        }

        public async Task<IPage> InitializePlaywright()
        {
            //Playwright 
            _playwright = await Playwright.CreateAsync();

            //Browser Launch Settings
            var browserSettings = new BrowserTypeLaunchOptions
            {
                Headless = false,
                //SlowMo = 1000
            };

            //Browser
            _browser = await _playwright.Chromium.LaunchAsync(browserSettings);

            //Page
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();

            //URL
            await _page.GotoAsync(_testSettings.AppBaseUrl);

            return _page;
        }


        public async Task<string> TaskScreenshotAsPathAsync(string fileName) 
        {
            var path = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}//{fileName}.png";

            await _page.ScreenshotAsync(new PageScreenshotOptions { Path = path });

            return path;
        }
       

        //public async Task<IBrowser> GetBrowser()
        //{
        //    _testSettings.BrowserType switch
        //    {
        //        "chrome" => await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }),
        //        "firefox" => await _playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }),
        //        "safari" => await _playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }),
        //    }
        //}


        public void Dispose()
        { 
            //await _page.CloseAsync();
            //await _context.CloseAsync();
            //await _browser.CloseAsync();
            _playwright.Dispose();
        }
    }
}
