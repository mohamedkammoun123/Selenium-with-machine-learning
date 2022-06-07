Feature: filtresProvider
	Simple calculator for adding two numbers

@mytag
Scenario: filtre provider
	Given I navigate to web app on following environement
	And I move the amount to invest slider to <amount_to_invest>
	And I move the maximum Term to <maximum_term>
	When I press the compare rate button
	Given I press In Any Filtres <filtre_name>
	Then I Should be watch the correct list provider
	Examples: 
		| amount_to_invest | maximum_term | filtre_name |
		| 14               | 20           | banks       |
		| 20               | 70           | banks       |
		| 0                | 0            | banks       |