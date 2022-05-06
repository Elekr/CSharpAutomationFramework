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

Scenario: [The user select an option from the dynamic dropdown]
    Given [I have navigated to the TC06 page]
    And [The webpage contains the from input]
    And [We have maximized the window]
    When [I click onto the fromDropdown]
    And [I enter the query string de]
    And [I click the option Delhi]
    Then [The input now contains Delhi (DEL)]
