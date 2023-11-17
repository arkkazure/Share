@existinguser @PalceanOrder
Feature: Placing a new order 

In order to test Online Shopping Website Home Page
As a tester
I want to ensure functionality is working fine on the Home Page


Background: 
	Given I navigate to Special Offers Page
	And I add the special offer product to the cart and checkout
	And I login as ExistingUser


	  @mansoor
Scenario:Place an Order using Mastercard
	When I choose the payment menthod as Mastercard
	And I Place an order
	Then I see the order is successfully placed

	  @zeeshan
Scenario:Place an Order using Safepay
	When I choose the payment menthod as Safepay	
	Then I see the order is successfully placed
