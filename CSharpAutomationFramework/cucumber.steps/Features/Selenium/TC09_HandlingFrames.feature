Feature: TC09_HandlingFrames

This feature goes through how to move within the frame of the browser

@Selenium
Scenario: [Switch between frames and access elements within them]
    Given [I have navigated to the "TC09Page"]
    When [I switch focus to the middle frame]
    Then [I am able to access the text displayed in middle]
    When [I switch focus to the bottom frame]
    Then [I am able to access the text displayed in bottom]