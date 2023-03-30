Feature: CreateUser
	In order to create new users
	As a customer care specialist
	I want to create a new user profile

@SmokeTest
Scenario Outline: Create new user
	Given I populate the API call
	When I make the API call to create a new user
	Then the call is successful
	And the user profile is created
