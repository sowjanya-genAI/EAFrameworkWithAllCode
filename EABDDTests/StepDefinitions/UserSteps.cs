using EABDDTests.Models;
using ExecuteAutomation.Reqnroll.Dynamics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EABDDTests.StepDefinitions
{

    [Binding]
    public class UserSteps
    {

        private IEnumerable<CreateUserModel> _createUserDetails;
        private readonly ScenarioContext _scenarioContext;

        public UserSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [When("I click the Employee List link")]
        public void WhenIClickTheEmployeeListLink()
        {
        }

        [When("I click Create new button to create an user")]
        public void WhenIClickCreateNewButtonToCreateAnUser()
        {
        }

        [When("I enter the user details")]
        public void WhenIEnterTheUserDetails(DataTable dataTable)
        {
            //DataTable to get data from
            var row = dataTable.CreateInstance<CreateUserModel>();

            Console.WriteLine($"Name: {row.Name}");
            Console.WriteLine($"Duration Worked: {row.DurationWorked}");
            Console.WriteLine($"Salary: {row.Salary}");
            Console.WriteLine($"Role: {row.Role}");
            Console.WriteLine($"Email: {row.Email}");
        }

        [When("I enter the users details")]
        public void WhenIEnterTheUsersDetails(DataTable dataTable)
        {
            //DataTable to get data from
            var rows = dataTable.CreateSet<CreateUserModel>();

            foreach (var row in rows)
            {
                Console.WriteLine($"Name: {row.Name}");
                Console.WriteLine($"Duration Worked: {row.DurationWorked}");
                Console.WriteLine($"Salary: {row.Salary}");
                Console.WriteLine($"Role: {row.Role}");
                Console.WriteLine($"Email: {row.Email}");

                Console.WriteLine("-----");
            }

            _scenarioContext.Set<IEnumerable<CreateUserModel>>(rows, "Chandana");
            _scenarioContext.Set<string>("passed", "Result");
            _scenarioContext.Set<int>(2, "TotalRows");
        }

        [When("I enter dynamic users details")]
        public void WhenIEnterDynamicUsersDetails(DataTable dataTable)
        {
            //DataTable to get data dyanmically from Dynamic type
            dynamic rows = dataTable.CreateDynamicSet();

            foreach (var row in rows)
            {
                Console.WriteLine($"Name: {row.Name}");
                Console.WriteLine($"Duration Worked: {row.DurationWorked}");
                Console.WriteLine($"Salary: {row.Salary}");
                Console.WriteLine($"Role: {row.Role}");
                Console.WriteLine($"Email: {row.Email}");

                Console.WriteLine("-----");
            }
        }





    }
}
