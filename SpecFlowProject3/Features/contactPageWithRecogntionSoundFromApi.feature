Feature: contactPageWithRecogntionSoundFromApi
	contact page witt sound from api

@myApiSoundContatctPageScinario
Scenario: contatct page with sound from api
	Given I navigate to web app on following environement
	When I press the compare rate button
	And I press in any provider <index_provider>
	And I click in get in touch button
	Given I entre the name from a sound file <path_sound_first_name>
	And I enter last name from sound file <path_sound_last_name>
	And I press In language Button correctly <language>
	And I press In the bust way button correctly <best_way>
	And  I enter the contact <path_sound_best_way>  
	Then I should be  In Contact From Sent Page
	Examples:
		| index_provider | path_sound_first_name                      | path_sound_last_name                             | language | best_way | path_sound_best_way                         |
		| 0              | C:-Users-lenovo-Desktop-ficher audio-m.wav | C:-Users-lenovo-Desktop-ficher audio-kammoun.wav | eng      | phone    | C:-Users-lenovo-Desktop-ficher audio-24.wav |