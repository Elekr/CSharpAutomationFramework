Feature: TCRS04_DeleteRequests

A short summary of the feature

@RestSharp
Scenario: [A user deletes an entry using a delete request]
    Given [I create a request to delete an entry]
    When [The delete request is sent]
    Then [I am able to validate entry has been deleted]