Feature: TC03_TextFieldInput

This feature goes through entering text into a text field

@Selenium
Scenario: [Adding text to a text field]
	Given [I have navigated to the TC03 page]
    And [The webpage contains a text input]
    And [The text input is empty]
    When [I type blah]
    Then [The text input should contain blah]
    When [I type blah]
    Then [The text input should contain blahblah]
