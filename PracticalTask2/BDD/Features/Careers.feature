Feature: Careers Job Search
  In order to explore job opportunities at EPAM
  As a visitor
  I want to search for jobs and verify job titles

  Scenario Outline: Validate that the latest job contains the expected keyword
    Given I am on the EPAM home page
    When I navigate to the Careers page
    And I start a job search with keyword "<Keyword>"
    And I select remote positions
    And I click search and open the latest job
    Then the job title should contain "<Keyword>"

    Examples:
      | Keyword |
      | SAP     |
      | Java    |
