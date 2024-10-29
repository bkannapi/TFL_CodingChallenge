Feature: ValidJourney

As a Senior Test Analyst I want to Verify that a valid journey can be planned using the widget
from “Leicester Square Underground Station” to “Covent Garden Underground Station”. 
And I want to Validate the result for both walking and cycling time.


@tag1
Scenario: Validate the Time
	Given Load the TFL site on chrome browser
	When I enter LeicesterSquare in From textbox
	And I enter CoventGarden in To textbox
	Then I click Plan my Journey button
	Then I should be shown with releavnt result
	Then I should Validate the result for both walking and cycling time.

Scenario: VEdit and upate the preference
	When  I select edit preference link in the journey result
	And I select routes with least walking
	And click update journey button
	Then the TFL site should present relevant result

Scenario: Viewdetails
	When  I click view details button
	Then I should be shown and verify the access information
	

