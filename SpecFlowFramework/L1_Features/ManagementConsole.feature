Feature: Management

In order to test Online Shopping Website Home Page
As a tester
I want to ensure functionality is working fine on the Home Page -Zeeshan Changes

#Background: Given I have logged in as an existing user1

@ManagementConsole
Scenario: Validation of deafult version release notes
	Given  I navigate to Version page		
	Then I see the below latest release notes in AOS page 
	"""
- The account service REST API includes adding master credit to an account, and create an AOB user
"""



#	@ManagementConsole
#Scenario: Validation of previous version release notes
#	Given  I navigate to Version page		
#	When I select the Previous AOS Version from the list
#	Then I see the below in AOS page 
#	"""
#	In this release, we add REST API support to the account service. This allows users to perform basic actions in AOS using REST.
#As a result, it is now easier to demo API tests and to demo the integration between AOS and other Micro Focus tools.
#"""
	