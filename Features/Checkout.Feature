@checkout
Feature: Checkout flow

  Scenario: Login and add item to cart
    Given I launch the browser
    And I navigate to the TerraCor Hub page
    When I click the login page
    And I enter the username and password
    And I click the login button
    Then I should be logged in and see the correct page title
    When I search for product "BS001"
    And I add 2 quantities to the cart
    Then I verify cart shows the product with correct total price
    When I empty the cart
    And I close the cart popup
    Then the cart should be empty
