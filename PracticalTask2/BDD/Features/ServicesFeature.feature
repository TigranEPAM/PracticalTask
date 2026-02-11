Feature: Services Navigation
  Validate navigation to Services section and related expertise

  Scenario Outline: Navigate to service category and verify page
    Given I am on the EPAM home page
    When I navigate to the Services menu and select "<Category>"
    Then the page title should contain "<Category>"
    And the 'Our Related Expertise' section should be displayed

    Examples:
      | Category          |
      | Generative AI     |
      | Responsible AI    |
