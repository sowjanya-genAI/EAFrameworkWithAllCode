Feature: Login
    This feature is to test the login operation of the application

Background: 
    Given I navigate to the application home page

@smoke
Scenario: Perform login with valid credentials
	Given I click the login link
	When I enter valid username and password
        | username | password |
        | admin    | password |
    Then I should be logged in successfully


@smoke
Scenario: Create a new user account
	Given I click the login link
	When I enter valid username and password
        | username | password |
        | admin    | password |
    And I click the Employee List link
    When I click Create new button to create an user
    And I enter the user details
        | Name     | Duration Worked | Salary | Role   | Email          |
        | John Doe | 8               | 60000  | Senior | John@gmail.com |


@smoke
Scenario: Create multiple users account
	Given I click the login link
	When I enter valid username and password
        | username | password |
        | admin    | password |
    And I click the Employee List link
    When I click Create new button to create an user
    And I enter the users details
        | Name     | Duration Worked | Salary  | Role   | Email            |
        | John Doe | 8               | 60000   | Senior | John@gmail.com   |
        | Snehal   | 8               | 6000000 | Senior | Snehal@gmail.com |
    And I print the dynamic user details


@smoke
Scenario: Create dynamic multiple users account
	Given I click the login link
	When I enter valid username and password
        | username | password |
        | admin    | password |
    And I click the Employee List link
    When I click Create new button to create an user
    And I enter dynamic users details
        | Name     | Duration Worked | Salary  | Role   | Email            |
        | John Doe | 8               | 60000   | Senior | John@gmail.com   |
        | Snehal   | 8               | 6000000 | Senior | Snehal@gmail.com |


