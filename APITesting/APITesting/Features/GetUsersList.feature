Feature: GetUsersList
	As a customer care specialist
	I want to retrieve a list of users from the system
	In order to view their details

@SmokeTest
Scenario Outline: Retrieve a list of users
	Given I want to retrieve a list of users from the system by passing query parameters in my URL
	When I perform a GET request
	Then the GET API call is successfully performed
	And the user details are retrieved correctly based on the query parameters

