using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Text.Json;
using AnsiTools;
using TaskFunctions;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "";
            string jsonString = "";
            if(args.Length == 0)
            {
                Console.WriteLine("Please provide the task number as an argument");
                return;
            }
            else if(args.Length > 1)
            {
                Console.WriteLine("Please provide only one argument");
                return;
            }
            else if(args[0] == "1")
            {
                Task1Functions task1Functions = new Task1Functions();
                Console.Clear();
                Console.WriteLine("Choose between the following options: \n 1. Square \n 2. Root \n 3. Cube \n 4. Area of Circle \n 5. Inch to mm \n 6. Greet \n");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                        Console.WriteLine("Please provide the number you want to square");
                        double numberToSquare = double.Parse(Console.ReadLine());
                        double squaredNumber = task1Functions.Square(numberToSquare);
                        Console.WriteLine($"The square of {numberToSquare} is {squaredNumber}");
                        break;
                        }
                    case 2:
                        {
                        Console.WriteLine("Please provide the number you want to root");
                        double numberToRoot = double.Parse(Console.ReadLine());
                        double rootedNumber = task1Functions.Root(numberToRoot);
                        Console.WriteLine($"The root of {numberToRoot} is {rootedNumber}");
                        break;
                        }
                    case 3:
                        {
                        Console.WriteLine("Please provide the number you want to cube");
                        double numberToCube = double.Parse(Console.ReadLine());
                        double cubedNumber = task1Functions.Cube(numberToCube);
                        Console.WriteLine($"The cube of {numberToCube} is {cubedNumber}");
                        break;
                        }
                    case 4:
                        {
                        Console.WriteLine("Please provide the radius of the circle");
                        double radius = double.Parse(Console.ReadLine());
                        double areaOfCircle = task1Functions.AreaOfCircle(radius);
                        Console.WriteLine($"The area of the circle with radius {radius} is {areaOfCircle}");
                        break;
                        }
                    case 5:
                        {
                        Console.WriteLine("Please provide the inch value you want to convert to mm");
                        double inch = double.Parse(Console.ReadLine());
                        double mm = task1Functions.InchToMm(inch);
                        Console.WriteLine($"{inch} inches is equal to {mm} mm");
                        break;
                        }
                    case 6:
                        {
                        Console.WriteLine("Please provide your name");
                        string name = Console.ReadLine();
                        string greeting = task1Functions.Greet(name);
                        Console.WriteLine(greeting);
                        break;
                        }
                    default:
                        {
                        Console.WriteLine("Invalid option");
                        break;
                        }
                }
            }
            else if(args[0] == "2")
            {
            Task2Function task2Function = new Task2Function();
            fileName = "jsonFiles/arrays.json";
            jsonString = File.ReadAllText(fileName);
            JsonElement arraysJsonData = JsonSerializer.Deserialize<JsonElement>(jsonString);

            List<int> flattenedArray = task2Function.FlattenJaggedArray(arraysJsonData);
            Console.WriteLine($"{ANSICodes.Colors.Red}Flattened array:{ANSICodes.Reset}");
            Console.WriteLine(string.Join(", ", flattenedArray));

            }
            else if(args[0] == "3")
            {
            Task3Functions task3Functions = new Task3Functions();
            fileName = "jsonFiles/nodes.json";
            jsonString = File.ReadAllText(fileName);
            Node nodesJsonData = JsonSerializer.Deserialize<Node>(jsonString);

            int sumOfNodes = task3Functions.CalculateSumOfNodesValue(nodesJsonData);
            int nodesCount = task3Functions.CountNodes(nodesJsonData);
            int deepestLevel = task3Functions.FindDeepestLevel(nodesJsonData);
            Console.WriteLine($"Deepest level is: {deepestLevel}");
            Console.WriteLine($"Sum of nodes is: {sumOfNodes}");
            Console.WriteLine($"Number of nodes is: {nodesCount}");
            }
            else if(args[0] == "4")
            {
            Task4Functions task4Functions = new Task4Functions();
            fileName = "jsonFiles/books.json";
            jsonString = File.ReadAllText(fileName);
            Books[] booksJsonData = JsonSerializer.Deserialize<Books[]>(jsonString);
            Console.Clear();
            Console.WriteLine("Choose between the following options: \n 1. Find books starting with 'The' \n 2. Find books written by authors with 'T' in their name \n 3. Count number of books written after 1994 \n 4. Count number of books written before 2004 \n 5. Find ISBN numbers of books written by Terry Pratchett \n 6. Sort books by author first name \n 7. Group books by author last name \n 8. Group books by author first name \n 9. Sort books alphabetically by title \n 10. Sort books chronologically by publication year \n");
            int option = int.Parse(Console.ReadLine());
            switch(option)
            {
                case 1:
                    {
                    Console.Clear();
                    List<string> booksStartingWithThe = task4Functions.FindBooksStartingWithThe(booksJsonData);
                    Console.WriteLine($"{ANSICodes.Colors.Yellow} Books starting with the : {ANSICodes.Reset}" + string.Join(", ", booksStartingWithThe));
                    break;
                    }
                case 2:
                    {
                    Console.Clear();
                    List<string> booksWithAuthorsWithTIntheirName = task4Functions.FindBooksWithAuthorsWithTIntheirName(booksJsonData);
                    Console.WriteLine($"{ANSICodes.Colors.Green} Books written by author with T in their name : {ANSICodes.Reset}" + string.Join(", ", booksWithAuthorsWithTIntheirName));
                    break;
                    }

                case 3:
                    {
                    Console.Clear();
                    int numberOfBooksWrittenAfter1994 = task4Functions.CountNumberOfBooksPublishedAfter1992(booksJsonData);
                    Console.WriteLine($"{ANSICodes.Colors.Blue} Number of books written after 1994 : {ANSICodes.Reset}" + numberOfBooksWrittenAfter1994);
                    break;
                    }

                case 4:
                    {
                    Console.Clear();
                    int numberOfBooksWrittenBefore2004 = task4Functions.CountNumberOfBooksPublishedBefore2004(booksJsonData);
                    Console.WriteLine($"{ANSICodes.Colors.Red} Number of books written before 2004 : {ANSICodes.Reset}" + numberOfBooksWrittenBefore2004);
                    break;
                    }

                case 5:
                    {
                    Console.Clear();
                    List<string> isbnNumbers = task4Functions.FindISBNNumbersFromAuthor(booksJsonData, "Terry Pratchett");
                    Console.WriteLine($"{ANSICodes.Colors.Magenta} ISBN numbers of books written by Terry Pratchett : {ANSICodes.Reset}" + string.Join(", ", isbnNumbers));
                    break;
                    }

                case 6:
                    {
                    Console.Clear();
                    Console.WriteLine("Choose between the following options: \n 1. Ascending \n 2. Descending \n");
                    int input = int.Parse(Console.ReadLine());
                    if(input == 1)
                    {
                        List<Books> sortedBooksByFirstName = task4Functions.SortBooksByAuthorFirstName(booksJsonData, "ascending");
                        Console.WriteLine($"{ANSICodes.Colors.Cyan} Grouped books by author first name : {ANSICodes.Reset}");
                        task4Functions.PrintGroupedBooksByAuthorFirstName(sortedBooksByFirstName);
                    }
                    else
                    {
                        List<Books> sortedBooksByFirstName = task4Functions.SortBooksByAuthorFirstName(booksJsonData, "descending");
                        Console.WriteLine($"{ANSICodes.Colors.Cyan} Grouped books by author first name : {ANSICodes.Reset}");
                        task4Functions.PrintGroupedBooksByAuthorFirstName(sortedBooksByFirstName);
                    }
                    break;
                    }   
                case 7:
                    {
                    Console.Clear();
                    Console.WriteLine("Choose between the following options: \n 1. Ascending \n 2. Descending \n");
                    int input = int.Parse(Console.ReadLine());
                    if(input == 1)
                    {
                        List<Books> sortedBooksByLastName = task4Functions.SortBooksByAuthorLastName(booksJsonData, "ascending");
                        Console.WriteLine($"{ANSICodes.Colors.Cyan} Grouped books by author last name : {ANSICodes.Reset}");
                        task4Functions.PrintGroupedBooksByAuthorLastName(sortedBooksByLastName);
                    }
                    else
                    {
                        List<Books> sortedBooksByLastName = task4Functions.SortBooksByAuthorLastName(booksJsonData, "descending");
                        Console.WriteLine($"{ANSICodes.Colors.Cyan} Grouped books by author last name : {ANSICodes.Reset}");
                        task4Functions.PrintGroupedBooksByAuthorLastName(sortedBooksByLastName);
                    }
                    break;
                    }
                case 8:
                    {
                    Console.Clear();
                    Console.WriteLine("Choose between the following options: \n 1. Ascending \n 2. Descending \n");
                    int input = int.Parse(Console.ReadLine());
                    if(input == 1)
                    {
                        List<Books> sortedBooksByFirstName = task4Functions.SortBooksByAuthorFirstName(booksJsonData, "ascending");
                        Console.WriteLine($"{ANSICodes.Colors.Cyan} Grouped books by author first name : {ANSICodes.Reset}");
                        task4Functions.PrintGroupedBooksByAuthorFirstName(sortedBooksByFirstName);
                    }
                    else
                    {
                        List<Books> sortedBooksByFirstName = task4Functions.SortBooksByAuthorFirstName(booksJsonData, "descending");
                        Console.WriteLine($"{ANSICodes.Colors.Cyan} Grouped books by author first name : {ANSICodes.Reset}");
                        task4Functions.PrintGroupedBooksByAuthorFirstName(sortedBooksByFirstName);
                    }
                    break;
                    }
                case 9:
                    {
                    Console.Clear();
                    Console.WriteLine("Choose between the following options: \n 1. Ascending \n 2. Descending \n");
                    int input = int.Parse(Console.ReadLine());
                    if(input == 1)
                    {
                        List<Books> sortedBooksByTitle = task4Functions.SortBooksAlphabeticallyByTitle(booksJsonData, "ascending");
                        Console.WriteLine($"{ANSICodes.Colors.Cyan} Sorted books by title : {ANSICodes.Reset}");
                        foreach (Books book in sortedBooksByTitle)
                        {
                            Console.WriteLine($"{book.title}");
                        }
                    }
                    else
                    {
                        List<Books> sortedBooksByTitle = task4Functions.SortBooksAlphabeticallyByTitle(booksJsonData, "ascending");
                        Console.WriteLine($"{ANSICodes.Colors.Cyan} Sorted books by title : {ANSICodes.Reset}");
                        foreach (Books book in sortedBooksByTitle)
                        {
                            Console.WriteLine($"{book.title}");
                        }
                    }
                    break;
                    }
                case 10:
                    {
                    Console.Clear();
                    List<Books> sortedBooksByPublicationYear = task4Functions.SortBooksChronologicallyByPublicationYear(booksJsonData, "ascending");
                    Console.WriteLine($"{ANSICodes.Colors.Cyan} Sorted books by publication year : {ANSICodes.Reset}");
                    foreach (Books book in sortedBooksByPublicationYear)
                    {
                        Console.WriteLine($"{book.title} - {book.publication_year}");
                    }
                    break;
                    }
                default:
                    {
                    Console.WriteLine("Invalid option");
                    break;
                    }
            }
        }
    }
}
}


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