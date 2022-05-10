Feature: TC11_WebTables

This feature goes through how to interact with web tables using the browser

@Selenium
Scenario: [Successfully count the rows of a table]
    Given [I have navigated to the TC11 page]
    When [I count the number of rows in the left table]
    Then [I should get a count of 11]

@Selenium
Scenario: [Successfully count the columns of a table]
    Given [I have navigated to the TC11 page]
    When [I count the number of columns in the left table]
    Then [I should get a count of 3]

@Selenium
Scenario: [Successfully total a column]
    Given [I have navigated to the TC11 page]
    When [I calculate the total of the Price column in the left table]
    Then [I should get a total of 235]

