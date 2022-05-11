Feature: TC07_AlertWindows

This feature goes through interacting with Alert windows

@Selenium
Scenario: [The user closes the alert window]
    Given [I have navigated to the TC07 page]
    And [I have clicked on a link that opens an alert window]
    When [I select OK on the alert window]
    Then [The window is closed]

@Selenium
Scenario: [The user accepts the confirm window]
    Given [I have navigated to the TC07 page]
    And [I have clicked on a link that opens a confirm window]
    When [I select yes on the confirm window]
    Then [The window is closed]

@Selenium
Scenario: [The user declines the confirm window]
    Given [I have navigated to the TC07 page]
    And [I have clicked on a link that opens a confirm window]
    When [I select no on the confirm window]
    Then [The window is closed]