Feature: TC12_Scrolling

This feature goes through how to scroll using the browser

@Selenium
Scenario: [Successfully scroll the page and and scroll down an internal table]
    Given [I have navigated to the TC12 page]
    And [The current y offset of the window is 0]
    When [I scroll the page down by 100]
    Then [The y offset of the window is now 100]