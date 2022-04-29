Feature: TC05_Checkboxes

This feature goes through interacting with checkboxes with the browser

@Selenium
Scenario: [Successfully interact with a checkbox]
    Given [I have navigated to the "TC05Page"]
    And [The webpage contains checkboxes]
    When [I select a checkbox]
    Then [The checkbox is checked]