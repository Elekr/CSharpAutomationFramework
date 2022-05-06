Feature: TC06_DropdownMenus

This feature goes through interacting with dropdown menus

@Selenium
Scenario: [The user select an option from the dropdown]
    Given [I have navigated to the TC06 page]
    And [The webpage contains the currency static dropdown]
    And [The dropdown contains the option INR]
    And [The dropdown contains the option USD]
    And [The dropdown currently has INR selected]
    When [I select USD]
    Then [The dropdown now has USD selected]

#Scenario: [The user select an option from the dynamic dropdown]
#    Given [I have navigated to the "TC06Page"]
#    And [There is an input for the query]
#    When [I enter the query string]
#    Then [The list is updated with elements that match the query]
#    When [I select an option]
#    Then [The option is displayed]
