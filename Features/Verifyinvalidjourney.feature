Feature: Verifyinvalidjourney

As a Senior Test Analyst i want to Verify that the widget does not provide results when an invalid
journey is planned.

@tag1
Scenario: verifyinvalid journey
	Given load the TFL site
	When I enter inlvald location in From field
	And I enter invalid location in To field
	Then I should be shown with error message
