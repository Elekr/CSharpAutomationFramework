Feature: TC18_QTContactPage

User launches Qualitest site and explores

Scenario: [Launch the Qualitest Official Site]
    When [I load the Qualitest site homepage]
    Then [The current page title is The World’s Leading AI-Led Quality Engineering Company | Qualitest]
    And [The current url is https://qualitestgroup.com/]

Scenario: [Get to the Contact Us page by clicking the button]
    Given [I am on the Qualitest site homepage]
    And [I maximize the page]
    When  [I click the Contact Us button]
    Then  [The current page title is Contact Us – Independent Software Testing Company | Quality Assurance Services | Qualitest]
    And   [The page contains the contact form]

Scenario: [Filling out the Contact Us form]
    Given [I have navigated to the Contact Us page]
    When  [I enter the first name Reginald]
    And   [I enter the surname Arterbury]
    And   [I enter the company name Jack Produtions]
    And   [I select that I want to talk about Media]
    And   [I enter the email fakeemail@fakedomain.com]
    And   [I enter the phone number 01253 123456]
    And   [I select the location North America]
    And   [I enter Let me test your site into the how can Qualitest help field]
    And   [I click the Submit button]
    Then  [I receive a Thank you message]