Feature: Click a link to navigate to another page

This feature goes through using links to navigate the browser.

@Selenium
  Scenario: [Successfully navigate to another web page after clicking a link]
    Given [I have navigated to the "TC02Page"]
    When [I click on a link]
    Then [I am navigated to another "TC02Page"]