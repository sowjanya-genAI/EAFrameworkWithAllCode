using Microsoft.Playwright;

namespace EABDDTests.Pages;

public interface IDeletePage
{
    Task DeleteAsync();
    Task ValidateTitleAsync();
}

public class DeletePage(IPage page) : IDeletePage
{
    ILocator pageTitleTxt => page.Locator("h1", new() { HasText = "Delete" });
    ILocator btnDelete => page.GetByRole(AriaRole.Button, new() { Name = "Delete" });

    public async Task ValidateTitleAsync()
    {
        await Assertions.Expect(pageTitleTxt).ToBeVisibleAsync();
    }

    public async Task DeleteAsync()
    {
        await btnDelete.ClickAsync();
    }
}