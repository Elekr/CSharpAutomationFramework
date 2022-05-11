Feature: TC09_HandlingFrames

This feature goes through how to move within the frame of the browser

@Selenium
Scenario: [Switch to a frame to access its text]
    Given [I have navigated to the TC09 page]
    And [I am unable to access the text displayed in middle]
    When [I switch focus to the middle frame]
    Then [I am able to access the text displayed in middle]