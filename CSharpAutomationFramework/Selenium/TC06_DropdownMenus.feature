Feature: TC06_DropdownMenus

This feature goes through interacting with dropdown menus

@Selenium
Scenario: [The user select an option from the dropdown]
    Given [I have navigated to the "TC06Page"]
    And [The webpage contains a static dropdown]
    When [I select an element from the dropdown]
    Then [The option is selected and displayed]

Scenario: [The user select an option from the dynamic dropdown]
    Given [I have navigated to the "TC06Page"]
    And [There is an input for the query]
    When [I enter the query string]
    Then [The list is updated with elements that match the query]
    When [I select an option]
    Then [The option is displayed]
