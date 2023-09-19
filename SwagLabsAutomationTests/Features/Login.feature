Feature: Login

This file contains scenarios for the login features

@login
Scenario: Login with valid credentials
	Given user redirected to login page
	When user inputs username "standard_user"
	 And user inputs password "secret_sauce"
	 And the login button is clicked
	Then the user should be redirected to page "https://www.saucedemo.com/inventory.html"
	
@login
Scenario: Logout
	Given user redirected to login page
	 And user inputs username "standard_user"
	 And user inputs password "secret_sauce"
	 And the login button is clicked
	 And the user should be redirected to page "https://www.saucedemo.com/inventory.html"
	When user clicks on hamburger menu
	 And user clicks on logout
	Then the user should be redirected to page "https://www.saucedemo.com"
	
@login
Scenario: Login with locked out user credentials
	Given user redirected to login page
	When user inputs username "locked_out_user"
	 And user inputs password "secret_sauce"
	 And the login button is clicked
	Then the user stays on the login page "https://www.saucedemo.com/"
	 And the user should displayed with an error message "Epic sadface: Sorry, this user has been locked out."
	 
@login
Scenario: Login with problem user credentials
	Given user redirected to login page
	When user inputs username "problem_user"
	 And user inputs password "secret_sauce"
	 And the login button is clicked
	Then the user should be redirected to page "https://www.saucedemo.com/inventory.html"
	
@login
Scenario: Login with user credentials on a slow performing website
	Given user redirected to login page
	When user inputs username "performance_glitch_user"
	 And user inputs password "secret_sauce"
	 And the login button is clicked
	Then the user should be redirected to page "https://www.saucedemo.com/inventory.html"
