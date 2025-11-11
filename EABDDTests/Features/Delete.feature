Feature: Delete

feature to delete an existing product

@tag1
Scenario: delete an existing product
	Given I navigate to the product page
	And I click create link to create a new product
	When I enter the product details
	| Name | Description       | Price | Product Type |
	| MyLaptop       | High-end Laptop   | 1500  | EXTERNAL       |
	Then the product should be created successfully in db with name "MyLaptop"
	When I delete the product with name "MyLaptop"
	Then the product with name "MyLaptop" should not exist in db
