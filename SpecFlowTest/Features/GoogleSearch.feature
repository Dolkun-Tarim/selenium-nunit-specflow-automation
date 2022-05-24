Feature: Google Search
Simple Google Search Automation
@mytag
Scenario: search a string in google
	Given a keyword string to search
	When the a user search the string on google
	Then google should return search result