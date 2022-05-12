Feature: TC17_HandlingTabs

This feature goes through how to navigate tabs using the browser

@Selenium
Scenario: [Grab text from a new tab]
	Given [I have navigated to the TC17 page]
	And [The username textbox is empty]
	When [I open a new tab]
	And [I navigate to tab 1]
	And [I navigate the new tab to the Rahul Shetty Academy login page]
	And [I grab the tagline]
	And [I navigate to tab 0]
	And [I enter the tagline into the textbox]
	Then [The username textbox should contain the text An Academy to Learn Earn & Shine in your QA Career]
