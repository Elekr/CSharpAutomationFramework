Feature: TC14_ExplicitWait

This feature goes through how to set up a wait for an element to load on the webpage

@Selenium
Scenario: [Fail without wait]
	Given [I navigate to the TC14 page]
	When [I click the forgot password buttton]
	And [I don't wait]
	And [I try to click the back to login button]
	Then [I should get an error]

@Selenium
Scenario: [Succeed with waitUntilElementEnabled]
	Given [I navigate to the TC14 page]
	When [I click the forgot password buttton]
	And [I wait until the element is enabled]
	And [I try to click the back to login button]
	Then [I should not get an error]

@Selenium
Scenario: [Succeed when using ClickElement]
	Given [I navigate to the TC14 page]
	When [I click the forgot password buttton]
	And [I don't wait]
	And [I try to click the back to login button with ClickElement]
	Then [I should not get an error]
