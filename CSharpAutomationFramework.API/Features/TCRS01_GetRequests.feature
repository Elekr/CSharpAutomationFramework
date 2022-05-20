Feature: TCRS01_GetRequests_SqlServer

This feature goes over get requests using the Rest Sharp API

@RestSharp
  Scenario: [A user gets a single object back from a response]
    Given [I send a request for a single object]
    When [The request is successful]
    Then [I am able to validate the returned object]