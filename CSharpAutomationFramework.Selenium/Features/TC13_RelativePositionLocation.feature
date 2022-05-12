Feature: TC13_RelativePositionLocation

This feature goes through how to select an element based on its position

@Selenium
Scenario: [User successfully selects the first column heading of the left table]
    Given [I have navigated to the TC13 page]
    When [I choose the left table to search]
    And [I get the first column heading]
    Then [The heading is Instructor]

@Selenium
Scenario: [User successfully selects the first column heading of the right table]
    Given [I have navigated to the TC13 page]
    When [I choose the right table to search]
    And [I get the first column heading]
    Then [The heading is Name]