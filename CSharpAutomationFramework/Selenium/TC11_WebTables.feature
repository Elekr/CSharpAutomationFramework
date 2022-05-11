Feature: TC11_WebTables

This feature goes through how to interact with web tables using the browser

@Selenium
Scenario: [Successfully get data from a web table]
    Given [I have navigated to the "TC11Page"]
    When [I locate all the columns in the table]
    Then [I am able to get the number of columns]
    When [I locate all the rows in the table]
    Then [I am able to get the number of rows]
    When [I locate a specific row in the table]
    Then [I am able to get all the data for that row]
