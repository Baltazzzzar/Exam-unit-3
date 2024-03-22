using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Text.Json;
using AnsiTools;

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
int CalculateSumOfNodesValue(Node node)
{
    if (node == null)
    {
        return 0;
    }
    else
    {
        return node.value + CalculateSumOfNodesValue(node.right) + CalculateSumOfNodesValue(node.left);
    }
}
int CountNodes(Node node)
{
    if (node == null)
    {
        return 0;
    }
    else
    {
        return 1 + CountNodes(node.right) + CountNodes(node.left);
    }
}

int deepestLevel = FindDeepestLevel(nodesJsonData);
int sumOfNodes = CalculateSumOfNodesValue(nodesJsonData);
int nodesCount = CountNodes(nodesJsonData);
Console.WriteLine($"Deepest level is: {deepestLevel}");
Console.WriteLine($"Sum of nodes is: {sumOfNodes}");
Console.WriteLine($"Number of nodes is: {nodesCount}");


// Task 4

fileName = "books.json";
jsonString = File.ReadAllText(fileName);
Books[] booksJsonData = JsonSerializer.Deserialize<Books[]>(jsonString);

List<string> FindBooksStartingWithThe(Books[] books)
{
    List<string> booksStartingWithThe = new List<string>();
    string the = "The";
    foreach (Books book in books)
    {
        for (int i = 0; i < the.Length; i++)
        {
            if (the[i] != book.title[i])
            {
                break;
            }
            if (i == the.Length - 1)
            {
                booksStartingWithThe.Add(book.title);
            }
        }
    }
    return booksStartingWithThe;
}

List<string> FindBooksWithAuthorsWithTIntheirName(Books[] books)
{
    List<string> booksWithAuthorsWithTIntheirName = new List<string>();
    foreach (Books book in books)
    {
        for (int i = 0; i < book.author.Length; i++)
        {
            if (book.author[i] == 't' || book.author[i] == 'T')
            {
                booksWithAuthorsWithTIntheirName.Add(book.title);
            }
            else if (book.author[i] == '(')
            {
                break;
            }
        }
    }
    return booksWithAuthorsWithTIntheirName;
}

int CountNumberOfBooksPublishedAfter1992(Books[] books)
{
    int count = 0;
    foreach (Books book in books)
    {
        if (book.publication_year > 1992)
        {
            count++;
        }
    }
    return count;
}

int CountNumberOfBooksPublishedBefore2004(Books[] books)
{
    int count = 0;
    foreach (Books book in books)
    {
        if (book.publication_year < 2004)
        {
            count++;
        }
    }
    return count;
}

List<string> FindISBNNumbersFromAuthor(string author)
{
    List<string> isbnNumbers = new List<string>();
    foreach (Books book in booksJsonData)
    {
        if (book.author == author)
        {
            isbnNumbers.Add(book.isbn);
        }
    }
    return isbnNumbers;
}

List<Books> SortBooksByAuthorFirstName(string order)
{
    List<Books> sortedBooks = new List<Books>(booksJsonData);
    if (order == "ascending")
    {
        for (int i = 0; i < sortedBooks.Count; i++)
        {
            for (int j = i + 1; j < sortedBooks.Count; j++)
            {
                if (sortedBooks[i].author.Split(" ")[0].CompareTo(sortedBooks[j].author.Split(" ")[0]) > 0)
                {
                    Books temp = sortedBooks[i];
                    sortedBooks[i] = sortedBooks[j];
                    sortedBooks[j] = temp;
                }
            }
        }
    }
    else if (order == "descending")
    {
        for (int i = 0; i < sortedBooks.Count; i++)
        {
            for (int j = i + 1; j < sortedBooks.Count; j++)
            {
                if (sortedBooks[i].author.Split(" ")[0].CompareTo(sortedBooks[j].author.Split(" ")[0]) < 0)
                {
                    Books temp = sortedBooks[i];
                    sortedBooks[i] = sortedBooks[j];
                    sortedBooks[j] = temp;
                }
            }
        }
    }
    return sortedBooks;
}



List<string> booksStartingWithThe = FindBooksStartingWithThe(booksJsonData);
Console.WriteLine($"{ANSICodes.Colors.Yellow} Books starting with the : {ANSICodes.Reset}" + string.Join(", ", booksStartingWithThe));
List<string> booksWithAuthorsWithTIntheirName = FindBooksWithAuthorsWithTIntheirName(booksJsonData);
Console.WriteLine($"{ANSICodes.Colors.Green} Books written by author with T in their name : {ANSICodes.Reset}" + string.Join(", ", booksWithAuthorsWithTIntheirName));
int numberOfBooksWrittenAfter1994 = CountNumberOfBooksPublishedAfter1992(booksJsonData);
Console.WriteLine($"{ANSICodes.Colors.Blue} Number of books written after 1994 : {ANSICodes.Reset}" + numberOfBooksWrittenAfter1994);
int numberOfBooksWrittenBefore2004 = CountNumberOfBooksPublishedBefore2004(booksJsonData);
Console.WriteLine($"{ANSICodes.Colors.Red} Number of books written before 2004 : {ANSICodes.Reset}" + numberOfBooksWrittenBefore2004);
List<string> isbnNumbers = FindISBNNumbersFromAuthor("Terry Pratchett");
Console.WriteLine($"{ANSICodes.Colors.Magenta} ISBN numbers of books written by Terry Pratchett : {ANSICodes.Reset}" + string.Join(", ", isbnNumbers));
List<Books> sortedBooks = SortBooksByAuthorFirstName("asc");
Console.WriteLine($"{ANSICodes.Colors.Cyan} Sorted books by author first name : {ANSICodes.Reset}");
foreach (var book in sortedBooks)
{
    Console.WriteLine($"{book.author} , {book.title}");
}


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
public class Books
{
    public string title { get; set; }
    public string author { get; set; }
    public int publication_year { get; set; }
    public string isbn { get; set; }
}