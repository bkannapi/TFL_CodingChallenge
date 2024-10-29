Feature: Verifynolocation

A short summary of the feature

@tag1
Scenario: Verifynolocation
	Given Loading the TFL site
	When I hit plan my journey button without locations in fromto fields	
	Then I should be shown with relevant error message
