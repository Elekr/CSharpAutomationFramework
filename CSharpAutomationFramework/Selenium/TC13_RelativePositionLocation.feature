Feature: TC13_RelativePositionLocation

This feature goes through how to select an element based on its position

@Selenium
Scenario: [User successfully selects an elements based on its relative position]
    Given [I have navigated to the "TC13Page"]
    When [I locate an element on the page]
    And [I select another element based on its relative position]
    Then [I am able to interact with that element]