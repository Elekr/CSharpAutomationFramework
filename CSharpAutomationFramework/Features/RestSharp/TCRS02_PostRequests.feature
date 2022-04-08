Feature: TCRS02_PostRequests

A short summary of the feature

@RestSharp
Scenario: [A user creates an entry using a post request]
    Given [I create a post request]
    When [The post request is successful]
    Then [I am able to validate the entry has been added]