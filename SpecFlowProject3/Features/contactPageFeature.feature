Feature: contactPageFeature
	Simple calculator for adding two numbers

@mytag
Scenario: Subbmit button is it worked
	Given I navigate to web app on following environement
	And I move the amount to invest slider to 20
	And I move the maximum Term to 30
	When I press the compare rate button
	And I press in any provider <index_provider>
	And I click in get in touch button
	Given I enter the first_name <firstName>
	And I enter the last_name <last_name>
	And I enter the language<lang>
	And I enter the best way <best_way>
	And I enter my contact <contact>
	When I click in subbmit button
	Then I should be in the page
	Examples: 
		| index_provider | firstName | last_name | lang | best_way | contact                    |
		| 0              | kammoun   | mohamed   | eng  | email    | mohamed.kamoun@ensi-uma.tn |
		

@mytag1
Scenario: check subbmit button while all info is empty
	Given I am in chosen Rate Page
	When I click in get in touch button
	And I click in subbmit button
	Then I should be in same page

@mytag2
Scenario: Subbmit button is it worked1
	Given I navigate to web app on following environement
	And I move the amount to invest slider to 20
	And i move the maximum term striders to 20
	When I press the compare rate button
	And I press in any provider <index_provider>
	And I click in get in touch button
	Given I enter the first_name <firstName>
	And I enter the last_name <last_name>
	And I enter the language<lang>
	And I enter the best way <best_way>
	And I enter my contact <contact>
	When I click in subbmit button
	Then I should be in the page
		Examples: 
		| index_provider | firstName | last_name | lang | best_way | contact                    |
		| 0              | kammoun   | mohamed   | fr   | email    | mohamed.kamoun@ensi-uma.tn |

@mytag3
Scenario: Subbmit button is it worked2
	Given I navigate to web app on following environement
	And I move the amount to invest slider to 20
	And I move the maximum Term to 20
	When I press the compare rate button
	And I press in any provider <index_provider>
	And I click in get in touch button
	Given I enter the first_name <firstName>
	And I enter the last_name <last_name>
	And I enter the language<lang>
	And I enter the best way <best_way>
	And I enter my contact <contact>
	When I click in subbmit button
	Then I should be in the page
		Examples: 
		| index_provider | firstName | last_name | lang | best_way | contact                    |
		| 0              | kammoun   | mohamed   | fr   | phone    | 33333333333                |
		