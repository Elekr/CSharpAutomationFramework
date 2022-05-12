Feature: TC15_ImplicitWait

This feature goes through how to set up a wait for an element to load on the webpage

Scenario: [Fail without wait]
	Given [I navigate to the TC15 page]
	When [I click the submit button]
	And [I try to get the incorrect credentials message]
	Then [I should get a locating error]

Scenario: [Succeed with implicit wait]
	Given [I navigate to the TC15 page]
	And [I have set an implicit wait]
	When [I click the submit button]
	And [I try to get the incorrect credentials message]
	Then [I should not get a locating error]

