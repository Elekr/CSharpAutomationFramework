Feature: TC10_UsingCalendar

This feature goes through how to interact with a calendar using the browser

@Selenium
Scenario: [User correctly enters a given date into the calendar]
    Given [I have navigated to the TC10 page]
    And [I have maximized the page]
    When [I click to open the calendar]
    And [I enter the date 3 July]
    Then [03/07 is selected]
