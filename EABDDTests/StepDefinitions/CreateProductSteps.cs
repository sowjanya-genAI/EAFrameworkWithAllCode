using EABDDTests.Model;
using EABDDTests.Pages;
using EAFramework.Utilities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [Given("I navigate to product page")]
        public async Task GivenINavigateToProductPage()
        {
            await _basePage.HomePage.ClickProductListAsync();
        }

        [Given("I click create link")]
        public async Task GivenIClickCreateLink()
        {
            await _basePage.ProductListPage.CreateProductAsync();
        }

        [Given("I create new product with following details")]
        public async Task GivenICreateNewProductWithFollowingDetails(DataTable dataTable)
        {
            var data = dataTable.CreateInstance<ProductDetails>();

            await _basePage.CreateProductPage.CreateProductAsync(data);
        }


        [Then("I verify in DB if the product is created with name {string}")]
        public void ThenIVerifyInDBIfTheProductIsCreatedWithName(string productName)
        {
            _productDbContext.Products.Any(x => x.Name == productName).Should().BeTrue();
        }


    }
}
