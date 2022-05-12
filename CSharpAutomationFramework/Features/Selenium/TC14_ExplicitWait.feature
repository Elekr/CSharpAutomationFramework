Feature: TC14_ExplicitWait

This feature goes through how to set up a wait for an element to load on the webpage

@Selenium
Scenario: [Successfully set up an explicit wait]
    Given [I have created an explicit wait]
    When [I navigate to the webpage which is still loading]
    Then [The explicit wait will stop execution until the condition is met]