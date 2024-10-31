Feature: Verifynolocation

As a Senior Test Analyst I want to Verify that the widget is unable to plan a journey if no locations
are entered into the widget.

@tag1
Scenario: Verifynolocation
	Given Loading the TFL site
	When I hit plan my journey button without locations in fromto fields	
	Then I should be shown with relevant error message
