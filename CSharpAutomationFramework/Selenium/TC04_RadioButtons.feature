Feature: TC04_RadioButtons

This feature goes through interacting with radio button with the browser

@Selenium
Scenario: [Successfully interact with Radio buttons]
    Given [I have navigated to the "TC04Page"]
    And [The webpage contains radio buttons]
    When [I select a radio button]
    Then [The correct radio button is selected]
    When [I select a different radio button]
    Then [The radio button selection is changed]