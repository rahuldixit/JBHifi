Feature: White
	
Scenario: Add New Client
	Given I launch the client application
	When I add a new client with name "Client 02", street "Adelaide Street", street number "21", postcode "1041", city "Melbourne" and phone number "021 303 404"
	Then client name "Client 02" should appear in the existing clients list

Scenario: Close Client
	Given I launch the client application
	When I add a new client with name "New Client 01", street "Adelaide Street", street number "21", postcode "1041", city "Melbourne" and phone number "021 303 404"
	Then client name "New Client 01" should appear in the existing clients list
	When I view client details for "New Client 01"
	When I add new account "Account 1"
	Then the account is displayed in the accounts list "Account 1"
	When I delete account "Account 1"
	Then the account does not display in the list "Account 1"
