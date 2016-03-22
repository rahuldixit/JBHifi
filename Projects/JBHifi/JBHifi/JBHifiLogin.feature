Feature: JBHifiLogin

Scenario: Invalid Login
	Given I goto the JBHifi website at: "https://www.jbhifi.com.au/"
	When I signup for special offers with: "test user at jbhifi.com" 
	Then the email entered is unsuccessful
