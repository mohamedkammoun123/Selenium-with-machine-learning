Feature: interset rate calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowProject1/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@myFirstScinario
Scenario: check intrest rate
	Given I navigate to web app on following environement
	And i move the amount to invest striders to 50
	And i move the maximum term striders to 48
	Then the total return should be 358

@mySecondScinario
Scenario:  check the calculator of total return
	Given I navigate to web app on following environement
	Then the Calculator should giving the truly the total return

@myThridScinario
Scenario: check the compare rates button
	Given I navigate to web app on following environement
	And I move the amount to invest slider to <percent_amount_to_invest>
	And I move the maximum Term to <percent_maximum_term>
	When I press the compare rate button
	Then I must be int the right page
	Examples: 
		| percent_amount_to_invest | percent_maximum_term |
		| 20                       | 14                   |
 
		


	