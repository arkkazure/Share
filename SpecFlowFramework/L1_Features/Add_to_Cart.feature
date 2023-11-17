Feature: Add to Cart

In order to test Online Shopping Website Home Page
As a tester
I want to ensure functionality is working fine on the Home Page and Test Work and HELLO WORDL 

#Background: Given I have logged in as an existing user

# This Example covers following functionalities
	# Specflow Table Handling
	# Specflow simple input values from feature files


@AddtoCart @PopulerItems @existinguser
Scenario: Validating the popular items added to the shopping cart
	Given I navigate to Popular Items Page and select below colors and qty for speakers		
		| Colour | Quantity |
		| Blue   | 2        |
		| Black  | 3        |
		| Purple | 1        |
		
	When I click on Add to Cart
	Then I can see <6> products added to my shopping basket
		
	




	



