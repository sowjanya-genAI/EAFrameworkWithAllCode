using EABDDTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EABDDTests.StepDefinitions
{

    [Binding]
    public class CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public CommonSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When("I print the dynamic user details")]
        public void WhenIPrintTheDynamicUserDetails()
        {

            var rows = _scenarioContext.Get<IEnumerable<CreateUserModel>>("Chandana");
            var totalRows = _scenarioContext.Get<int>("TotalRows");
            var result = _scenarioContext.Get<string>("Result");

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
