Feature: WebSite
	Simple calculator for adding two numbers

@mytag
Scenario: all_page_scenario
	Given I navigate to web app on following environement
	And I move the maximum Term to <maximum_term>
	And I move the amount to invest slider to <amount_to_invest>
	When I press the compare rate button
	And I press in any provider <index_provider>
	Then the chosen rate page should have the correct information of chosen provider
	Examples: 
		| maximum_term | amount_to_invest | index_provider |
		| 84           | 60               | 0              |
