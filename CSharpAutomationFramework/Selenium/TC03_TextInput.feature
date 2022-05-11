Feature: TC03_TextFieldInput

This feature goes through entering text into a text field

@Selenium
Scenario: [Adding text to a text field]
	Given [I have navigated to the "TC03Page"]
    And [The webpage contains a text input]
    When [I send text to the field]
    Then [The text is successfully entered into the field]
    When [I send more text to the field]
    Then [The extra text is added to the field]
