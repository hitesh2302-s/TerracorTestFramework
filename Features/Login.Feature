Feature: Login to TerraCor Demo

  Scenario: Successful login with valid credentials
    Given I launch the browser
    And I navigate to the TerraCor Hub page
    When I click the login page
    And I enter the username and password
    And I click the login button
    Then I should be logged in and see the correct page title
