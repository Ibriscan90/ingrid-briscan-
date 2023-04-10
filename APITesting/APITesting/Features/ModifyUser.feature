Feature: ModifyUser
	As a customer care specialist
	I want to modify an existing user profile
	In order to update the user information

@SmokeTest
Scenario Outline: Modify user
	Given I populate the API call to modify an existing user
	When I make the API call to modify the user
	Then the PUT call is successful
	And the user profile is updated
