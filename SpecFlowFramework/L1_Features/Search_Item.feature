Feature: Search Item

In order to test Online Shopping Website Home Page
As a tester
I want to ensure functionality is working fine on the Home Page

#Background: Given I have logged in as an existing user

@Search
Scenario Outline: Portal should search for the given keyword and should navigate to search results page
	Given I navigate to homepage
	When I search for the <Keyword>
	Then I should get the search <Result> 
Examples:
	| Keyword | Result               |
	| Laptops | Results displayed    |
	| Junk    | No Results displayed |
	| Tablets | No Results displayed |
	| Carrot  | Results displayed    |
	



#@Search
#Scenario: The Chepeast Laptop
#	Given I search for laptops
#	When I select the cheapest laptop
#	Then I see the cheapest price is $179.99