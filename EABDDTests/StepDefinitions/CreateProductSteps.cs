using EABDDTests.Model;
using EABDDTests.Pages;
using EAFramework.Utilities;
using FluentAssertions;
using ProductAPI.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EABDDTests.StepDefinitions
{
    [Binding]
    public class CreateProductSteps
    {
        private readonly IBasePage _basePage;
        private readonly IProductDbContext _productDbContext;

        public CreateProductSteps(IBasePage basePage, IProductDbContext productDbContext)
        {
            _basePage = basePage;
            _productDbContext = productDbContext;
        }

        [Given("I navigate to the product page")]
        public async Task GivenINavigateToTheProductPage()
        {
            await _basePage.HomePage.ClickProductListAsync();
        }

        [Given("I click create link to create a new product")]
        public async Task GivenIClickCreateLinkToCreateANewProduct()
        {
            await _basePage.ProductListPage.CreateProductAsync();
        }

        [When("I enter the product details")]
        public async Task WhenIEnterTheProductDetails(DataTable dataTable)
        {
            var data = dataTable.CreateInstance<ProductDetails>();

            await _basePage.CreateProductPage.CreateProductAsync(data);
        }

        [Then("the product should be created successfully in db with name {string}")]
        public void ThenTheProductShouldBeCreatedSuccessfully(string name)
        {
            _productDbContext.Products.Any(x => x.Name == name).Should().BeTrue();
        }

    }
}
