﻿using System;
using System.Collections.Generic;

// Task 1

double Square(double x)
{
    return x * x;
}

double Root(double x)
{
    return Math.Sqrt(x);
}

double Cube(double x)
{
    return x * x * x;
}

double AreaOfCircle(double r)
{
    return Math.PI * r * r;
}

double InchToMm(double inch)
{
    return inch * 25.4;
}

string Greet(string name)
{
    return $"Good Day, {name}!";
}




// Testing

Testing.Test(4, Square(2), "Square of 2");
Testing.Test(9, Root(81), "Root of 81");
Testing.Test(8, Cube(2), "Cube of 2");
Testing.Test(Math.PI * 4, AreaOfCircle(2), "Area of Circle with radius 2");
Testing.Test(50.8, InchToMm(2), "2 inch to mm");
Testing.Test("Good Day, John!", Greet("John"), "Greet John");