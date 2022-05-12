Feature: TC16_Actions

This feature goes through how to build actions that interact with the browser

@Selenium
Scenario: [Successfully create and perform a simple hover action]
    Given [I have navigated to the TC16 page]
    And [The link with text Top is not visible]
    When [I hover over the mouse hover button]
    Then [The link with text Top is now visible]

@Selenium
Scenario: [User is able to create and perform composite actions]
    Given [I have navigated to the TC16 page]
    And [The link with text Top is not visible]
    And [The first checkbox is not checked]
    When [I check the first checkbox hover over the mouse hover button]
    Then [The link with text Top is now visible]
    And [The first checkbox is checked]