Feature: Registration

In order to test Online Shopping Website Home Page
As a tester
I want to ensure functionality is working fine on the Home Page

#Background: Given I have logged in as an existing user

@Registration @createuser
Scenario: Create a new user
	Given I  navigated to create user page
	When I submit the user details to create user	
	And I agree the terms
	Then I should see the user is created successfully
#
#		@Registration
#Scenario: Edit an existing account
#	Given I logged in as <john>
#	When I click on user		
#	And I select myaccount	
#	Then I edit my payment details 
#	And I save the details 
#	Then I am able to see the newly added payment details