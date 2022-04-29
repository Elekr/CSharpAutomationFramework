Feature: TC08_SwitchingWindows

This feature goes through how to switch windows with the browser

@Selenium
Scenario: [User successfully opens, switches between and closes multiple windows]
    Given [I have navigated to the "TC08Page"]
    When [I click on a link to open a new window]
    Then [I am able to navigate to the new window]
    And [I am able to access elements within the new window]
    And [I am able to close the child window]
    And [I am able to navigate back to the original window]

