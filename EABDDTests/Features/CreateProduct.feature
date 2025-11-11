Feature: CreateProduct

feature to create a new product 

@tag1
Scenario: Create a new product with all details
	Given I navigate to the product page
	And I click create link to create a new product
	When I enter the product details
	| Name | Description       | Price | Product Type |
	| MyLaptop       | High-end Laptop   | 1500  | EXTERNAL       |
	Then the product should be created successfully in db with name "MyLaptop"

