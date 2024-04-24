4/25: Added option 8 showing all products and 10 showing out-of-stock
	products. Also changed option 3 to 9 to show instock products.

4/16: Updated for PetStore Part 4.
	Added IProductLogic interface with two abstract methods. 	ProductLogic class implements IProductLogic.
	Changed Program class with main method: Added option 3 to list 	in-stock products. Modified if else if logic with switch 		statement.
	
4/10: Removed Environment.Exit(). Instead introduced bool flag to 		to check the condition and break out of the nested loop.

4/9: when searching for DogLeash or CatFood type, the refereces for both types were changed to Product type. 

4/8: adding null conditional operator ?. for name input from user

4/7: changes made to enforce user input of right type. and added try catch block in GetDogLeashByName() and GetCatFoodByName() methods of ProductLogic class instead of if else. But the return type is still null if the type doesn't match.

4/4: Added ToStiring() method for Product class and also for subclasses DogLeash and CatFood. Refactored Program class and PrintMessages() method to display instructions for user.

3/29: Updated ProductLogic class: if key is not found from the 
Dictionary class null is thrown instead of Argument Exception
That null is checked when outputting Dictionary collection of 
the right type.

Updated Program class main method to change the Product name
Updated for Exercise 2 for Code:You SD January 2024.
Changed solution name to PetStore.
Added ProductLogic class.

Refactored main class to convert product name(key for our Dictionary Collection)
to lower case while input from user and while getting output, only product name
with lower case is checked and null is checked as well.
Also input of decimal, double, int types were forced to enter right type using
TryParse() method inside do while loop as suggested by my mentors.

This is Exercise1 for Code:You SD January 2024.
The console app has been created using visual basic 2022.
It is very basic console app with base class named Product.
CatFood class and DogLeash classes extend Product class.
The main console asks user to enter values for CatFood or DogLeash
Properties and creates the object and prints the object. 