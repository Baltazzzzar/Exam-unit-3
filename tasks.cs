using System;
using System.Collections.Generic;
using System.Text.Json;

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

string fileName = "arrays.json";
string jsonString = File.ReadAllText(fileName);
JsonElement jsonData = JsonSerializer.Deserialize<JsonElement>(jsonString)!;


List<int> FlattenJaggedArray(JsonElement jaggedArray)
{
    List<int> flattenedArray = new List<int>();
    if (jaggedArray.ValueKind == JsonValueKind.Array)
    {
        foreach (var item in jaggedArray.EnumerateArray())
        {
            List<int> sublist = FlattenJaggedArray(item);
            foreach (int number in sublist)
            {
                flattenedArray.Add(number);
            }
        }
    }
    else if (jaggedArray.ValueKind == JsonValueKind.Number)
    {
        int number = int.Parse(jaggedArray.ToString());
        flattenedArray.Add(number);
    }
    return flattenedArray;
}

List<int> flattenedArray = FlattenJaggedArray(jsonData);
Console.WriteLine(string.Join(", ", flattenedArray));




// Testing

Testing.Test(4, Square(2), "Square of 2");
Testing.Test(9, Root(81), "Root of 81");
Testing.Test(8, Cube(2), "Cube of 2");
Testing.Test(Math.PI * 4, AreaOfCircle(2), "Area of Circle with radius 2");
Testing.Test(50.8, InchToMm(2), "2 inch to mm");
Testing.Test("Good Day, John!", Greet("John"), "Greet John");