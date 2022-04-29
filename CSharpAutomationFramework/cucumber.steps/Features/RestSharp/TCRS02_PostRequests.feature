Feature: TCRS02_PostRequests

A short summary of the feature

@RestSharp
Scenario Outline: [A user creates an entry using a post request]
    Given [I create a post request with <Employee_name> and <Designation>]
    When [The post request is successful]
    Then [I am able to validate the entry has been added]

    Examples:
    | Employee_name | Designation      |
    | Employee1     | SoftwareEngineer |