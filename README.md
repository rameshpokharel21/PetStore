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