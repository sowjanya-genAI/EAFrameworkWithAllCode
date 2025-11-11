using EABDDTests.Pages;
using EAFramework.Utilities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EABDDTests.StepDefinitions
{
    [Binding]
    public class DeleteSteps
    {
        private readonly IBasePage _basePage;
        private readonly IProductDbContext _productDbContext;

        public DeleteSteps(IBasePage basePage, IProductDbContext productDbContext)
        {
            _basePage = basePage;
            _productDbContext = productDbContext;
        }

        [When("I delete the product with name {string}")]
        public async Task  WhenIDeleteTheProductWithName(string myLaptop)
        {
           await _basePage.HomePage.ClickProductListAsync();
            await _basePage.ProductListPage.DeleteProductAsyncWithName(myLaptop);
        }

        [Then("the product with name {string} should not exist in db")]
        public void ThenTheProductWithNameShouldNotExistInDb(string myLaptop)
        {
            _productDbContext.Products.Any(x => x.Name == myLaptop).Should().BeFalse();
        }

    }
}
