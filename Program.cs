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
            // Task 1
            Task1Functions task1Functions = new Task1Functions();

            // Task 2
            Task2Function task2Function = new Task2Function();
            string fileName = "jsonFiles/arrays.json";
            string jsonString = File.ReadAllText(fileName);
            JsonElement arraysJsonData = JsonSerializer.Deserialize<JsonElement>(jsonString);

            List<int> flattenedArray = task2Function.FlattenJaggedArray(arraysJsonData);
            Console.WriteLine(string.Join(", ", flattenedArray));


            // Task 3
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


            // Task 4
            Task4Functions task4Functions = new Task4Functions();
            fileName = "jsonFiles/books.json";
            jsonString = File.ReadAllText(fileName);
            Books[] booksJsonData = JsonSerializer.Deserialize<Books[]>(jsonString);



            List<string> booksStartingWithThe = task4Functions.FindBooksStartingWithThe(booksJsonData);
            Console.WriteLine($"{ANSICodes.Colors.Yellow} Books starting with the : {ANSICodes.Reset}" + string.Join(", ", booksStartingWithThe));
            List<string> booksWithAuthorsWithTIntheirName = task4Functions.FindBooksWithAuthorsWithTIntheirName(booksJsonData);
            Console.WriteLine($"{ANSICodes.Colors.Green} Books written by author with T in their name : {ANSICodes.Reset}" + string.Join(", ", booksWithAuthorsWithTIntheirName));
            int numberOfBooksWrittenAfter1994 = task4Functions.CountNumberOfBooksPublishedAfter1992(booksJsonData);
            Console.WriteLine($"{ANSICodes.Colors.Blue} Number of books written after 1994 : {ANSICodes.Reset}" + numberOfBooksWrittenAfter1994);
            int numberOfBooksWrittenBefore2004 = task4Functions.CountNumberOfBooksPublishedBefore2004(booksJsonData);
            Console.WriteLine($"{ANSICodes.Colors.Red} Number of books written before 2004 : {ANSICodes.Reset}" + numberOfBooksWrittenBefore2004);
            List<string> isbnNumbers = task4Functions.FindISBNNumbersFromAuthor(booksJsonData, "Terry Pratchett");
            Console.WriteLine($"{ANSICodes.Colors.Magenta} ISBN numbers of books written by Terry Pratchett : {ANSICodes.Reset}" + string.Join(", ", isbnNumbers));
            List<Books> sortedBooksByFirstName = task4Functions.SortBooksByAuthorFirstName(booksJsonData, "descending");
            Console.WriteLine($"{ANSICodes.Colors.Cyan} Sorted books by author first name : {ANSICodes.Reset}");
            foreach (var book in sortedBooksByFirstName)
            {
                Console.WriteLine($"{book.author} , {book.title}");
            }
            List<Books> sortedBooksByLastName = task4Functions.SortBooksByAuthorLastName(booksJsonData, "ascending");
            Console.WriteLine($"{ANSICodes.Colors.Cyan} Grouped books by author last name : {ANSICodes.Reset}");
            task4Functions.PrintGroupedBooksByAuthorLastName(task4Functions.SortBooksByAuthorLastName(booksJsonData, "ascending"));
            Console.WriteLine($"{ANSICodes.Colors.Cyan} Grouped books by author first name : {ANSICodes.Reset}");
            task4Functions.PrintGroupedBooksByAuthorFirstName(sortedBooksByFirstName);

            List<Books> sortedBooksByTitle = task4Functions.SortBooksAlphabeticallyByTitle(booksJsonData, "ascending");
            Console.WriteLine($"{ANSICodes.Colors.Cyan} Sorted books by title : {ANSICodes.Reset}");
            foreach (var book in sortedBooksByTitle)
            {
                Console.WriteLine($"{book.title} , {book.author}");
            }
            List<Books> sortedBooksByPublicationYear = task4Functions.SortBooksChronologicallyByPublicationYear(booksJsonData, "ascending");
            Console.WriteLine($"{ANSICodes.Colors.Cyan} Sorted books by publication year : {ANSICodes.Reset}");
            foreach (var book in sortedBooksByPublicationYear)
            {
                Console.WriteLine($"{book.title} , {book.author} , {book.publication_year}");
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