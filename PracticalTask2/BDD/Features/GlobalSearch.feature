Feature: Global Search
  In order to find relevant content on EPAM
  As a visitor
  I want to search globally and validate that results contain the keyword

Scenario Outline: Validate global search
	Given I am on the EPAM home page
	When I search for "<Keyword>"
	Then all search results links should contain "<Keyword>"

Examples:
	| Keyword |
	| open    |
	| Cloud   |
	| Support |
