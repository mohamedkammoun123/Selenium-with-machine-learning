Feature: pageOfListProvieder
	Simple calculator for adding two numbers

@firstScinarioFfpageListProvider
Scenario: Click in retour button
	Given I navigate to web app on following environement
	And I move the amount to invest slider to <percent_amount_to_invest>
	And I move the maximum Term to <percent_maximum_term>
	When I press the compare rate button
	When I press in any provider <index_provider>
	Then I should be in the chosen rate page
	Examples: 
		| percent_amount_to_invest | percent_maximum_term | index_provider |
		| 20                       | 28                   | 2              |

@third
Scenario: Check the calculator of total return in list provider
	Given I navigate to web app on following environement
	And I move the amount to invest slider to <percent_amount_to_invest>
	And I move the maximum Term to <percent_maximum_term>
	When I press the compare rate button
	Then the Calculator should giving the total return of all providers
	Examples: 
		| percent_amount_to_invest | percent_maximum_term |
		| 10                      | 14                    |

@calculatorInListProvider
Scenario: check the calculator
	Given I navigate to web app on following environement
	And I move the amount to invest slider to 20
	And I move the maximum Term to 30
	When I press the compare rate button
	Then the Calculator should giving the total return of all providers
	Examples: 
		| p0 | p1 |
		| 80 | 56 |

@ProvividerSlider
Scenario: check the provider slider
	Given I navigate to web app on following environement
	And I move the amount to invest slider to 20
	And I move the maximum Term to 20
	When I press the compare rate button
	Given I move provider amount to invest to <p0>
	And I move maximum term provider slider <p1>
	Then the Calculator should giving the total return of all providers
	Examples: 
		| amount_to_invest | maximum_term | p0 | p1 |
		| 10               | 28           | 10 | 28 |


		
 
	
				