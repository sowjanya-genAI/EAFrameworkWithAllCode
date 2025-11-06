using EAFramework.Config;
using Microsoft.Playwright;

namespace EAFramework.Driver
{
    public class PlaywrightApiDriver :  IDisposable
    {
        private IPlaywright _playwright;
        private readonly TestSettings _testSettings;

        public PlaywrightApiDriver(TestSettings testSettings)
        {
            _testSettings = testSettings;
        }

        public async Task<IAPIRequestContext> InitializePlaywright(Dictionary<string, string> headers)
        {
            //Playwright 
            _playwright = await Playwright.CreateAsync();

            var apiRequestContext = new APIRequestNewContextOptions
            {
                BaseURL = _testSettings.AppAPIBaseUrl,
                ExtraHTTPHeaders = headers,
                IgnoreHTTPSErrors = true
            };

            return await _playwright.APIRequest.NewContextAsync(apiRequestContext);
        }


        public void Dispose()
        { 
            //await _page.CloseAsync();
            //await _context.CloseAsync();
            //await _browser.CloseAsync();
            _playwright.Dispose();
        }
    }
}
