STA Coding Challenge – Web Development Decisions
-------------------------------------------------

I)Technology Used:-
	C#,
	Selenium
	Specflow
	PageObjectModel
	Gherkin Language to write the scenario

II)IDE Used to develop the code-Visual Studio professional 2022(we can use Visual studio free version too)

Instruction to load and run the project:-
------------------------------------------

1)Clone the repository in local,

	https://github.com/bkannapi/TFL_CodingChallenge

2) Open the TFL_CodingChallenge folder from local and run TFL.sln file in Visual Studio IDE.

3)Go to Tools and Nugetpackagemanger in Visul Studio and install dependencies,
	SeleniumWebDriver
	SeleniumWaitHelpers
	SpecflowNunit
	ChromeDriver
	Microsoft.Extensions.Configuration
	Microsoft.Extensions.Configuration.Binder
	Microsoft.Extensions.Configuration_Json
	Microsoft.NET.Test.Sdk
	NUnit
	NUnit3TestAdapter
	SpecFlow.Plus.LivingDocPlugin

4)Rebuild the code to auto install relevant dependencies if not already.

5)RUN the test:-
	Select Test-Test Explorer and select 'Run all tests in view'
    you can see all five test run in sequence and PASS, expand the result in test explorer for review.

Purpose of eatch folder,file and coding technique used explained
---------------------------------------------------------------------
6) The URL been read from the config file not hardcoded
	Support-Appsettings.Environments.json
	Configuration-EnvironmentConfig.cs
	ReadConfig.cs

7)NUnit Hooks been used
	Hooks BeforeTestRun-To make sure chrome webdriver kept open for alltestrun.
	Hooks AfterTestRun-To make sure chrome webdriver closed post test finished. 
	Multi browesr run capability also been used in Hooks.

8)Features Folder
	Valid journey, edit preferences & view details test scenarios been covered in ValidJourney.Feature file since it's all involved a sequentiol flow of actions.
	Verifyinvalidjourney.feature file is to test the invalid journey.
	Verifynolocation.feature file is to test the no locations test scenario.

9)Pages Folder
	Editpreferencespages.cs:-Edit and update journey object repositories and methods. 
	Validjourneypages.cs:-Valid journey object repositories and methods.
    These two class files been used across all stepdefinitions file to ensure code reusability and establishing page object model implementation.

10)StepDefinitions Folder
	Validjourneystepdefinitions.cs-To cover valid journey, edit preferences & view details test scenario.
	verifyinvlidjourneystepdefinitions.cs-To cover invalid journey test scenario.
	verifynolocationstepdefinitions-To cover no locations test scenario
    Code reusability, page object model been implemented
	WebDriverWait been used, so the releavnt action on the webelement will wait until ensure element load.
	Assert statement used for vefification and validation.

	Challenges faced:-
	------------------
	When click acccept cookie button on the home page, 
	cookie overlay that remains visible on the page and blocks interactions with the elements beneath it. 
	To resolve this,I handled the cookie consent overlay by waiting for it to appear and then closing it.



	
	
	
	


