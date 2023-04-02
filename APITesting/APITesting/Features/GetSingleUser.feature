Feature: GetSingleUser
	As a customer care specialist
	I want to retrieve a user from the system
	In order to view their details

@SmokeTest
Scenario Outline: Retrieve a single user by id
	Given I perform the API call to get a user
	Then the API call is successful
	And the user details are retrieved

@SmokeTest
Scenario Outline: Unsuccesful GET request for single user
	Given I perform the API call to retrieve a user
	Then the API call is unsuccessful
	And the user details are not found
