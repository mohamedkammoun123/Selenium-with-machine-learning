Feature: chosenRatePage
	Simple calculator for adding two numbers

@returnButton
Scenario: check in return button
	Given I am in chosen Rate Page 
	When I click in return button
	Then I should be in list provider page

@getIntouchButton
Scenario: check get in touch button
	Given I am in chosen Rate Page
	When I click in get in touch button
	Then I should be in contact page



