Feature: TC19_LinkTesting

Test all the links on a page to make sure that their pages are available
@tag1
Scenario: [Test that no links contain error codes]
	Given [We have navigated to the TC19 page]
	When [I test all links]
	Then [They should all be working]
