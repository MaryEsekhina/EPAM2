Feature: UnitTest1Feature
As a user
I want to open NwApp
So I can add product

@mytag
Scenario: Add product
	Given I open "http://localhost:5000" url
	When I enter the login "user"
	And I enter the password "user"
	And I click on submit button
	And I click on "All Products"
	And I click on Create button
	And I input "Chiken legs" in ProductName
	And I input "Meat/Poultry" in Category
	And I input ""Grandma Kelly's Homestead" in Supplier
	And I input "100" in Unitprice
	And I click on send button
	Then there is "Chiken legs" in the list