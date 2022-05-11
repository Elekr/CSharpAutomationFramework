Feature: TC08_SwitchingWindows

This feature goes through how to switch windows with the browser

@Selenium
Scenario: [Switch to newly opened window]
    Given [I have navigated to the TC08 page]
    And [I have opened the new window with the new window link]
    And [I am still on the page with the new window link]
    When [I navigate to the latest window]
    Then [I am now on a window that does not contain the new window link]
    And [I am now on a window that contains the heading New Window]


@Selenium
Scenario: [Switch back to the first window]
    Given [I am on a child window]
    When [I navigate to window 0]
    Then [I am now on a window that contains the heading Opening a new window]