Feature: Login

A short summary of the feature

@existinguser1 @login
Scenario Outline: Login of Existing user
	Given I navigate to Login page
	When I submit <username> and <passsword>
	Then <username> is logged in successfully
	
Examples:
	| username | passsword |
	| zee1990  | Password1 |
	| wrongid  | wrongpass |
	


