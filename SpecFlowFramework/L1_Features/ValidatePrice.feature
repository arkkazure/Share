Feature: Vaidating item price

In order to test Online Shopping Website Home Page
As a tester
I want to ensure all items are added sucessfully to Cart

@Price
Scenario Outline:Validating the price and ordering the items
	Given I navigate to TabletSections	
	And   I select the <item>,<quantity>,<color> and add to cart
	When  I checkout the prodcuts	
	Then  I validate the <item>,<quantity>,<color> and <price> are added to the order summary
Examples: 
	| item                        | quantity | color  | price     |
    | HP Pro Tablet 608 G1	      | 2        | BLACK  | $958.00   |
    | HP ElitePad 1000 G2 Tablet  | 1        | GRAY   | $1,009.00 |
	