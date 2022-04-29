Feature: TC01_DriverNavigation

This feature goes through using the navigation method of Selenium

@Selenium
Scenario: Moving driver to a website
	Given I have a browser driver
	When I use the Navigate method
	Then The correct page will be displayed