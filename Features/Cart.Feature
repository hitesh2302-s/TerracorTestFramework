Feature: Add to Cart
  Verify product can be searched and added to cart with correct pricing

  Scenario: Add BS001 with quantity 2 and verify cart price
    Given I search for product "BS001" with quantity 2 and verify price 4.43
