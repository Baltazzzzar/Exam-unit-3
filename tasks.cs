using System;
using System.Collections.Generic;

// Task 1

double Square(double numberToSquare)
{
    return numberToSquare * numberToSquare;
}

double Root(double numberToRoot)
{
    return Math.Sqrt(numberToRoot);
}

double Cube(double numberToCube)
{
    return numberToCube * numberToCube * numberToCube;
}

double AreaOfCircle(double radius)
{
    return Math.PI * radius * radius;
}

double InchToMm(double inch)
{
    return inch * 25.4;
}

string Greet(string name)
{
    return $"Good Day, {name}!";
}



// Task 2

int[] FlattenJaggedArray(int[][] jaggedArray)
{
    int[] flattenedArray = new int[0];
    //1. Test if current element is a number or an array
    //2. If it's a number, add it to the result array
    //3. If it's an array, call back to step 1
    //4. If the array is empty, return to previous array, and go to step 1
    return flattenedArray;
}



// Testing

Testing.Test(4, Square(2), "Square of 2");
Testing.Test(9, Root(81), "Root of 81");
Testing.Test(8, Cube(2), "Cube of 2");
Testing.Test(Math.PI * 4, AreaOfCircle(2), "Area of Circle with radius 2");
Testing.Test(50.8, InchToMm(2), "2 inch to mm");
Testing.Test("Good Day, John!", Greet("John"), "Greet John");