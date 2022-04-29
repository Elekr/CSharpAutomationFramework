Feature: TCRS03_PutRequests

A short summary of the feature

@RestSharp
Scenario: [A User updates an existing entry using a put request]
    Given [I send a put request for employee with name "Employee1" to update the designation as "Team Lead"]
    When [The put request is successful]
    Then [I am able to validate the entry has been updated]
