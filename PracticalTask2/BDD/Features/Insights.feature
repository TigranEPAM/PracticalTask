Feature: Insights E-Books
  In order to read EPAM insights articles
  As a visitor
  I want to validate that the selected article opens correctly

  Scenario Outline: Validate Insights article title
    Given I am on the EPAM home page
    When I navigate to the Insights page
    And I click the "Read More" link on the third tab
    Then the e-book page should be loaded
    And the title should be "<ExpectedTitle>"

    Examples:
      | ExpectedTitle                                      |
      | Evolving into Agentic AI: Turning Theory into Action |
