Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowTests/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@priority1
Scenario: Add two numbers with 50
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120
@priority1
Scenario: Add two numbers with 60
	Given the first number is 60
	And the second number is 80
	When the two numbers are added
	Then the result should be 140
@priority1
Scenario: Add two numbers with 100
	Given the first number is 50
	And the second number is 50
	When the two numbers are added
	Then the result should be 100
@priority1
Scenario: Add two numbers with negative
	Given the first number is -50
	And the second number is 50
	When the two numbers are added
	Then the result should be 0