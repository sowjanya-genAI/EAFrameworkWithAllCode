using EABDDTests.Pages.Interfaces;
using EABDDTests.Pages;
using Microsoft.Playwright;

namespace EABDDTests.Pages;

public interface IBasePage
{
    IHomePage HomePage { get; }
    IProductListPage ProductListPage { get; }
    ICreateProductPage CreateProductPage { get; }
    IDeletePage DeletePage { get; }
}

public class BasePage : IBasePage
{
    private Lazy<IHomePage> _homePage;
    private Lazy<IProductListPage> _productListPage;
    private Lazy<ICreateProductPage> _createProductPage { get; }
    private Lazy<IDeletePage> _deletePage { get; }

    public BasePage(IPage page)
    {
        _homePage = new Lazy<IHomePage>(GetHomePage(page));
        _productListPage = new Lazy<IProductListPage>(() => new ProductListPage(page));
        _createProductPage = new Lazy<ICreateProductPage>(() => new CreateProductPage(page));
        _deletePage = new Lazy<IDeletePage>(() => new DeletePage(page));
    }

    public HomePage GetHomePage(IPage page)
    {
        return new HomePage(page);
    }

    public IHomePage HomePage => _homePage.Value;
    public IProductListPage ProductListPage => _productListPage.Value;
    public ICreateProductPage CreateProductPage => _createProductPage.Value;
    public IDeletePage DeletePage => _deletePage.Value;
}