using System;
using System.Collections.Generic;


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