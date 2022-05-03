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

@Selenium
Scenario: [Fail to send keys when navigating back to login]
	Given [We have moved to the the site]
	And [We are on the forgot password page]
	When [We click back to login]
	And [Don't wait]
	Then [Trying to immediately send keys to the username box should fail] 

@Selenium
Scenario: [Successfully enterText when navigating back to login]
	Given [We have moved to the the site]
	And [We are on the forgot password page]
	When [We click back to login]
	And [Don't wait]
	Then [Trying to immediately enterText should succeed]
	And [Username element should contain the test string]

@Selenium
Scenario: [Successfully verify visit us redirect]
	Given [We have moved to the the site]
	When [We click visit us]
	And [We wait 1 second(s)]
	And [We switch to the new tab]
	Then [We should successfully verify the redirect to https://rahulshettyacademy.com/]


@Selenium
Scenario: [Fail to verify visit us redirect]
	Given [We have moved to the the site]
	When [We click visit us]
	And [We wait 1 second(s)]
	And [We switch to the new tab]
	Then [We should fail to verify redirect to https://rahulshettyacademy.com/locatorspractice/#]

@Selenium
Scenario: [Successfully open a new tab, navigate to it and navigate back by partial title]
	Given [We have moved to the the site]
	When [We open a new tab]
	And [Navigate to the new tab]
	Then [Switch to window Rahul]


@Selenium
Scenario: [Successfully open a new tab, navigate to it and navigate back by full title]
	Given [We have moved to the the site]
	When [We open a new tab]
	And [Navigate to the new tab]
	Then [Switch to window Rahul Shetty Academy - Login page]