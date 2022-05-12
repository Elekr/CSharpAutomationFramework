Feature: TC05_Checkboxes

This feature goes through interacting with checkboxes with the browser

@Selenium
Scenario: [Successfully interact with a checkbox]
    Given [I have navigated to the TC05 page]
    And [The webpage contains a checkbox]
    And [The checkbox is not checked]
    When [I click the checkbox]
    Then [The checkbox is checked]
    When [I click the checkbox]
    Then [The checkobox is unchecked]
