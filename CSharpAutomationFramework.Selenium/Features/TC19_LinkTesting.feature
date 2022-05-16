Feature: TC19_LinkTesting

Test all the links on a page to make sure that their pages are available
@Selenium
Scenario: [Test that no links contain error codes]
	Given [We have navigated to the TC19A page]
	When [I get all the links]
	And [I discard the disabled links]
	And [I test the remaining links]
	Then [They should all be working]

@Selenium
Scenario: [Test that we find the broken links in this page]
	Given [We have navigated to the TC19B page]
	When [I get all the links]
	And [I discard the disabled links]
	And [I test the remaining links]
	Then [They should not all be working]
