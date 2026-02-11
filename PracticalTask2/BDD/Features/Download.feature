Feature: Validate Download
  In order to ensure resources are downloadable
  As a visitor
  I want to download EPAM PDFs from the About page

  Scenario Outline: Validate file download
    Given I am on the EPAM home page
    When I navigate to the About page
    And I click on the EPAM at a Glance banner download button
    Then the file "<FileName>" should be downloaded successfully

    Examples:
      | FileName                            |
      | EPAM_Corporate_Overview_Sept_25.pdf |
