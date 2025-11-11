using EABDDTests.Model;
using Microsoft.Playwright;

namespace EABDDTests.Pages;

public interface IProductListPage
{
    ILocator btnDelete(ILocator parentRow);
    ILocator btnEdit(ILocator parentRow);
    ILocator btnDetails(ILocator parentRow);
    Task ValidateTitleAsync();
    Task CreateProductAsync();
    ILocator GetProductRow(string name, string description, string price, ProductType productType);
    Task<bool> IsProductExistAsync(ProductDetails productDetails);
    // Task<EditPage> EditProductAsync(ProductDetails productDetails);
    // Task<bool> isModifiedProductExistAsync(ProductDetails productDetails);
    Task DeleteProductAsync(ProductDetails productDetails);
    // Task ValidateProductNotExistAsync(ProductDetails productDetails);
    Task DeleteModifiedProductAsync(ProductDetails productDetails);
    Task DeleteProductAsyncWithName(string name);
    // Task ValidateModifiedProductNotExistAsync(ProductDetails productDetails);
    // Task<DetailsPage> DetailsProductAsync(ProductDetails productDetails);
}

public class ProductListPage(IPage page) : IProductListPage
{

    ILocator pageTitleTxt => page.GetByRole(AriaRole.Heading, new() { Name = "List" });
    ILocator btnCreate => page.GetByRole(AriaRole.Link, new() { Name = "Create" });
    public ILocator btnDelete(ILocator parentRow) => parentRow.GetByRole(AriaRole.Link, new() { Name = "Delete" });
    public ILocator btnEdit(ILocator parentRow) => parentRow.GetByRole(AriaRole.Link, new() { Name = "Edit" });
    public ILocator btnDetails(ILocator parentRow) => parentRow.GetByRole(AriaRole.Link, new() { Name = "Details" });

    public async Task ValidateTitleAsync() => await Assertions.Expect(pageTitleTxt).ToBeVisibleAsync();

    public async Task CreateProductAsync() => await btnCreate.ClickAsync();

    public ILocator GetProductRow(string name, string description = null, string price = null, ProductType productType = ProductType.EXTERNAL)
    {
        return page.GetByRole(AriaRole.Row, new() { Name = name })
            .Filter(new() { HasText = description })
            .Filter(new() { HasText = price })
            .Filter(new() { HasText = productType.ToString() });
    }

    public async Task<bool> IsProductExistAsync(ProductDetails productDetails)
    {
        var productRow = GetProductRow(productDetails.Name, productDetails.Description, productDetails.Price.ToString(), productDetails.ProductType);

        return await productRow.IsVisibleAsync();
    }

    // public async Task<EditPage> EditProductAsync(ProductDetails productDetails)
    // {
    //     var productRow = GetProductRow(productDetails.Name, productDetails.Description, productDetails.Price.ToString(), productDetails.ProductType);
    //
    //     await btnEdit(productRow).ClickAsync();
    //     return new EditPage(_page);
    // }

    public async Task<bool> isModifiedProductExistAsync(ProductDetails productDetails)
    {
        var productRow = GetProductRow(productDetails.Name, productDetails.Description, productDetails.NewPrice, productDetails.ProductType);
        return await productRow.IsVisibleAsync();
    }

    public async Task DeleteProductAsync(ProductDetails productDetails)
    {
        var productRow = GetProductRow(productDetails.Name, productDetails.Description, productDetails.Price.ToString(), ProductType.CPU);

        await btnDelete(productRow).ClickAsync();
    }
    public async Task DeleteProductAsyncWithName(string name)
    {
        var productRow = GetProductRow(name);

        await btnDelete(productRow).ClickAsync();
    }

    public async Task ValidateProductNotExistAsync(ProductDetails productDetails)
    {
        var productRow = GetProductRow(productDetails.Name, productDetails.Description, productDetails.Price.ToString(), productDetails.ProductType);
        await Assertions.Expect(productRow).Not.ToBeVisibleAsync();
    }

    public async Task DeleteModifiedProductAsync(ProductDetails productDetails)
    {
        var productRow = GetProductRow(productDetails.Name, productDetails.Description, productDetails.NewPrice, productDetails.ProductType);

        await btnDelete(productRow).ClickAsync();
    }

    public async Task ValidateModifiedProductNotExistAsync(ProductDetails productDetails)
    {
        var productRow = GetProductRow(productDetails.Name, productDetails.Description, productDetails.NewPrice, productDetails.ProductType);
        await Assertions.Expect(productRow).Not.ToBeVisibleAsync();
    }

    // public async Task<DetailsPage> DetailsProductAsync(ProductDetails productDetails)
    // {
    //     var productRow = GetProductRow(productDetails.Name, productDetails.Description, productDetails.Price.ToString(), productDetails.ProductType);
    //
    //     await btnDetails(productRow).ClickAsync();
    //     return new DetailsPage(_page);
    // }


}
