Feature: Verifyinvalidjourney

A short summary of the feature

@tag1
Scenario: verifyinvalid journey
	Given load the TFL site
	When I enter inlvald location in From field
	And I enter invalid location in To field
	Then I should be shown with error message
