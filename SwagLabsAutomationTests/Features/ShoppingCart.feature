Feature: ShoppingCart

This file contains scenarios for shopping cart features

@shoppingCart
Scenario: Adding product to cart
	Given user is logged in with username "standard_user" and password "secret_sauce"
	When user clicks on add to cart for product "Sauce Labs Backpack"
	Then the product should be added to cart with number showing 1
	
@shoppingCart
Scenario: Adding product to cart with problem user
	Given user is logged in with username "problem_user" and password "secret_sauce"
	When user clicks on add to cart for product "Sauce Labs Backpack"
	Then the product should be added to cart with number showing 1

@shoppingCart
Scenario: View product in cart
	Given user is logged in with username "standard_user" and password "secret_sauce"
	And user clicks on add to cart for product "Sauce Labs Backpack"
	When user clicks on the cart button
	Then the product "Sauce Labs Backpack" should be visible in cart
	
@shoppingCart
Scenario: Remove product from catalog
	Given user is logged in with username "standard_user" and password "secret_sauce"
	And user clicks on add to cart for product "Sauce Labs Backpack"
	And the product should be added to cart with number showing 1
	When user clicks on remove button for product "Sauce Labs Backpack"
	Then the cart should be emptied
		
@shoppingCart
Scenario: Remove product from catalog with problem user
	Given user is logged in with username "problem_user" and password "secret_sauce"
	And user clicks on add to cart for product "Sauce Labs Backpack"
	And the product should be added to cart with number showing 1
	When user clicks on remove button for product "Sauce Labs Backpack"
	Then the cart should be emptied
	
@shoppingCart
Scenario: Remove product from cart page
	Given user is logged in with username "standard_user" and password "secret_sauce"
	And user clicks on add to cart for product "Sauce Labs Backpack"
	And the product should be added to cart with number showing 1
	When user clicks on the cart button
	And user clicks on remove button for product "Sauce Labs Backpack"
	Then the cart should be emptied
	
@shoppingCart
Scenario: Proceed to checkout page
	Given user is logged in with username "standard_user" and password "secret_sauce"
	And user clicks on add to cart for product "Sauce Labs Backpack"
	And the product should be added to cart with number showing 1
	When user clicks on the cart button
	And user clicks on checkout button
	Then the user should be redirected to the page "https://www.saucedemo.com/checkout-step-one.html"
	
@shoppingCart
Scenario: Proceed to order placement page
	Given user is logged in with username "standard_user" and password "secret_sauce"
	And user clicks on add to cart for product "Sauce Labs Backpack"
	And the product should be added to cart with number showing 1
	And user clicks on the cart button
	And user clicks on checkout button
	And the user should be redirected to the page "https://www.saucedemo.com/checkout-step-one.html"
	When user inputs "First Name" as "Test" 
	And user inputs "Last Name" as "Test" 
	And user inputs "Postal Code" as "Test" 
	And user clicks on continue button
	Then the user should be redirected to the page "https://www.saucedemo.com/checkout-step-two.html"
	
@shoppingCart
Scenario: Place order
	Given user is logged in with username "standard_user" and password "secret_sauce"
	And user clicks on add to cart for product "Sauce Labs Backpack"
	And the product should be added to cart with number showing 1
	And user clicks on the cart button
	And user clicks on checkout button
	And the user should be redirected to the page "https://www.saucedemo.com/checkout-step-one.html"
	And user inputs "First Name" as "Test"
	And user inputs "Last Name" as "Test" 
	And user inputs "Postal Code" as "Test"
	And user clicks on continue button
	And the user should be redirected to the page "https://www.saucedemo.com/checkout-step-two.html"
	When user clicks on finish button
	Then the user should be redirected to the page "https://www.saucedemo.com/checkout-complete.html"
	 And a message with "Thank you for your order!" is displayed to the user
	
	