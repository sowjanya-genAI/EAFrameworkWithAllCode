using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EABDDTests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {

        [Given("I navigate to the application home page")]
        public void GivenINavigateToTheApplicationHomePage()
        {
        }

        [Given("I click the login link")]
        public void GivenIClickTheLoginLink()
        {
        }

        [When("I enter valid username and password")]
        public void WhenIEnterValidUsernameAndPassword(DataTable dataTable)
        {
            //DataTable to get data from
            var rows = dataTable.Rows;

            foreach(var row in rows)
            {
                var userName = row["username"];
                var password = row["password"];
                Console.WriteLine($"Username {userName} and password {password}");
            }
        }

        [Then("I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {
        }



    }
}
