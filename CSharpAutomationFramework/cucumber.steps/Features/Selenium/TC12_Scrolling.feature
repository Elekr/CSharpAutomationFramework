Feature: TC12_Scrolling

This feature goes through how to scroll using the browser

@Selenium
Scenario: [Successfully scroll the page and and scroll down an internal table]
    Given [I have navigated to the "TC12Page"]
    When [I scroll the page down a specific amount]
    Then [The offset of the window has changed by the specific amount]