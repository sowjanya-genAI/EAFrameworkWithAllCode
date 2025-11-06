Feature: CreateProduct

Feature to create a new product with different perfumations and combinations

@smoke
Scenario: Create a product with all details
	Given I navigate to product page
    And I click create link
    And I create new product with following details
        | Name         | Description                | Price | ProductType |
        | Power Supply | Main Computer power Supply | 5000  | PERIPHARALS |
    Then I verify in DB if the product is created with name "Power Supply"
