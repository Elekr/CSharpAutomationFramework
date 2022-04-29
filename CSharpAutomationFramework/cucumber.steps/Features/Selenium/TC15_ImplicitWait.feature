Feature: TC15_ImplicitWait

This feature goes through how to set up a wait for an element to load on the webpage

@Selenium
Scenario: [Successfully set up an implicit wait on a web driver]
    Given [I have supplied the correct setup to add an implicit wait]
    When [I navigate to the "TC15Page"]
    Then [The driver will implicitly wait before the test fails]

