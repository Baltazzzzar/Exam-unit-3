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
JsonElement arraysJsonData = JsonSerializer.Deserialize<JsonElement>(jsonString);


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

List<int> flattenedArray = FlattenJaggedArray(arraysJsonData);
Console.WriteLine(string.Join(", ", flattenedArray));


// Task 3

fileName = "nodes.json";
jsonString = File.ReadAllText(fileName);
Node nodesJsonData = JsonSerializer.Deserialize<Node>(jsonString);

int FindDeepestLevel(Node node)
{
    if (node == null)
    {
        return 0;
    }
    else
    {
        int leftLevel = FindDeepestLevel(node.left);
        int rightLevel = FindDeepestLevel(node.right);
        if (leftLevel > rightLevel)
        {
            return leftLevel + 1;
        }
        else
        {
            return rightLevel + 1;
        }
    }
}
int SumOfNodes(Node node)
{
    if (node == null)
    {
        return 0;
    }
    else
    {
        return node.value + SumOfNodes(node.right) + SumOfNodes(node.left);
    }
}
int FindAmountOfNodes(Node node)
{
    if (node == null)
    {
        return 0;
    }
    else
    {
        return 1 + FindAmountOfNodes(node.right) + FindAmountOfNodes(node.left);
    }
}

int deepestLevel = FindDeepestLevel(nodesJsonData);
int sumOfNodes = SumOfNodes(nodesJsonData);
int nodesCount = FindAmountOfNodes(nodesJsonData);
Console.WriteLine($"Deepest level is: {deepestLevel}");
Console.WriteLine($"Sum of nodes is: {sumOfNodes}");
Console.WriteLine($"Number of nodes is: {nodesCount}");




// Testing

Testing.Test(4, Square(2), "Square of 2");
Testing.Test(9, Root(81), "Root of 81");
Testing.Test(8, Cube(2), "Cube of 2");
Testing.Test(Math.PI * 4, AreaOfCircle(2), "Area of Circle with radius 2");
Testing.Test(50.8, InchToMm(2), "2 inch to mm");
Testing.Test("Good Day, John!", Greet("John"), "Greet John");

public class Node
{
    public int value { get; set; }
    public Node left { get; set; }
    public Node right { get; set; }
}