Feature: ReusablesTest

Test the new reusable layout and that its methods are working correctly

@Selenium
Scenario: [Fail without wait]
	Given [We have moved to the the site]
	When [We click the forgot password buttton]
	And [Don't wait]
	Then [Clicking the go back button should fail]

@Selenium
Scenario: [Succeed with waitUntilElementEnabled]
	Given [We have moved to the the site]
	When [We click the forgot password buttton]
	And [Wait for element enabled]
	Then [Clicking the go back button should succeed]

@Selenium
Scenario: [Succeed wihout wait with clickElement]
	Given [We have moved to the the site]
	When [We click the forgot password buttton]
	And [Don't wait]
	Then [Clicking with clickElement should succeed]
