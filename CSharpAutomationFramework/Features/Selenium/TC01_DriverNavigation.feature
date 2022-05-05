Feature: TC01_DriverNavigation

This feature goes through using the navigation method of Selenium

@Selenium
Scenario: [Moving driver to a website]
	Given [I have a browser driver]
	And [This page object has the url https://google.co.uk/]
	And [The page object has the title Google]
	When [I use the NavigateHome method]
	Then [The webpage open in the driver will have the same title as the page object]