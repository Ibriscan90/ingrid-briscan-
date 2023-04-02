Feature: RegisterUser
	In order to register new users in the system
	As a customer care specialist
	I want to register a new user profile

@SmokeTest
Scenario Outline: Register a new user succesfully
	Given I populate the API call for registration
	When I make the API call to register a new user
	Then the registration call is successful
	Then the user is succesfully registered


@SmokeTest
Scenario Outline: Unsuccessful user registration with non existing user
	Given I populate the API call for registration with a non existing user
	When I make the API call to register a new user account
	Then the  registration call is not successful
	And the user is not registered

@SmokeTest
Scenario Outline: Unsuccessful user registration without password
	Given I populate the API call for registration without a password
	When I call the API to register a new user account
	Then the  registration call is unsuccessful
	And the user cannot be registered