Feature: TC02_ClickNavigation

This feature goes through using links to navigate the browser.

@Selenium
  Scenario: [Successfully navigate to another web page after clicking a link]
    Given [I have navigated to the TC02 page]
    When [I click link]
    Then [The driver Url should have changed]