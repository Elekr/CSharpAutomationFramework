Feature: TCRS03_PutRequests

A short summary of the feature

@RestSharp
Scenario: [A User updates an existing entry using a put request]
    Given [I send a put request]
    When [The put request is successful]
    Then [I am able to validate the entry has been updated]
