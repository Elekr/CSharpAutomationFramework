Feature: TC16_Actions

This feature goes through how to build actions that interact with the browser

@Selenium
Scenario: [Successfully create and perform a simple actions]
    Given [I have navigated to the "TC16Page"]
    When [I build and perform the action]
    Then [The effect is seen on the web page]

@Selenium
Scenario: [User is able to create and perform composite actions]
    Given [I have navigated to the "TC16Page"]
    When [I build and perform the composite action]
    Then [The full action is performed]
