Feature: DeleteUser
	As a customer care specialist
	I want to delete a user
	In order to remove it from the system

@SmokeTest
Scenario Outline: Delete user
	Given I make the API call to delete a new user
	Then the DELETE call is successful
	And the user profile is deleted
