Feature: TC04_RadioButtons

This feature goes through interacting with radio button with the browser

@Selenium
Scenario: [Successfully interact with Radio buttons]
    Given [I have navigated to AutomationPracticePage]
    And [The webpage contains more than 1 radio button]
    And [Radio button 0 is not selected]
    When [I click radio button 0]
    Then [Radio button 0 is now selected]
    When [I click radio button 2]
    Then [Radio button 2 is now selected]
    And [Radio button 0 is no longer selected]