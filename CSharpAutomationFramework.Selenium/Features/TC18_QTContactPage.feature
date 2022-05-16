Feature: TC18_QTContactPage

User launches Qualitest site and explores

Scenario: [Launch the Qualitest Official Site]
    When [I load the Qualitest site homepage]
    Then [The current page title is The World’s Leading AI-Led Quality Engineering Company | Qualitest]
    And [The current url is https://qualitestgroup.com/]

Scenario: [Get to the Contact Us page by clicking the button]
    Given [I am on the Qualitest site homepage]
    And [I maximize the page]
    When  [I click the Contact us button]
    Then  [The current page title is Contact Us – Independent Software Testing Company | Quality Assurance Services | Qualitest]
    And   [The page contains the contact form]

Scenario: [The user fills up Contact Us form]
    Given [the user is on contact us page]
    When  [the user enters first name]
    And   [the user enters last name]
    And   [the user enters company name]
    And   [the user selects what he wants to talk about]
    And   [the user enters email]
    And   [the user enters phone number]
    And   [the user enters location]
    And   [the user fills how can we help section]
    And   [the user clicks on Submit button]
    Then  [the user receives a Thank you message]