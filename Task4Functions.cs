using System.Text.Json;
using AnsiTools;
using Program;

namespace TaskFunctions
{
    public class Task4Functions
    {
        public List<string> FindBooksStartingWithThe(Books[] books)
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
        public List<string> FindBooksWithAuthorsWithTIntheirName(Books[] books)
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

        public int CountNumberOfBooksPublishedAfter1992(Books[] books)
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

        public int CountNumberOfBooksPublishedBefore2004(Books[] books)
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

        public List<string> FindISBNNumbersFromAuthor(Books[] books, string author)
        {
            List<string> isbnNumbers = new List<string>();
            foreach (Books book in books)
            {
                if (book.author == author)
                {
                    isbnNumbers.Add(book.isbn);
                }
            }
            return isbnNumbers;
        }

        public List<Books> SortBooksByAuthorFirstName(Books[] books, string order)
        {
            List<Books> sortedBooks = new List<Books>(books);
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

        public List<Books> SortBooksByAuthorLastName(Books[] books, string order)
        {
            List<Books> sortedBooks = new List<Books>(books);
            for (int i = 0; i < sortedBooks.Count; i++)
            {
                for (int j = i + 1; j < sortedBooks.Count; j++)
                {
                    if (order == "ascending")
                    {
                        if (sortedBooks[i].author.Split(' ')[1] == "(Translated")
                        {
                            if (sortedBooks[i].author.Split(" ")[0].CompareTo(sortedBooks[j].author.Split(" ")[1]) > 0)
                            {
                                Books temp = sortedBooks[i];
                                sortedBooks[i] = sortedBooks[j];
                                sortedBooks[j] = temp;
                            }
                        }
                        if (sortedBooks[j].author.Split(' ')[1] == "(Translated")
                        {
                            if (sortedBooks[i].author.Split(" ")[1].CompareTo(sortedBooks[j].author.Split(" ")[0]) > 0)
                            {
                                Books temp = sortedBooks[i];
                                sortedBooks[i] = sortedBooks[j];
                                sortedBooks[j] = temp;
                            }
                        }
                        if (sortedBooks[i].author.Split(' ')[1] == "(Translated" && sortedBooks[j].author.Split(' ')[1] == "(Translated")
                        {
                            if (sortedBooks[i].author.Split(" ")[0].CompareTo(sortedBooks[j].author.Split(" ")[0]) > 0)
                            {
                                Books temp = sortedBooks[i];
                                sortedBooks[i] = sortedBooks[j];
                                sortedBooks[j] = temp;
                            }
                        }
                        if (sortedBooks[i].author.Split(' ')[1] != "(Translated" && sortedBooks[j].author.Split(' ')[1] != "(Translated")
                        {
                            if (sortedBooks[i].author.Split(" ")[1].CompareTo(sortedBooks[j].author.Split(" ")[1]) > 0)
                            {
                                Books temp = sortedBooks[i];
                                sortedBooks[i] = sortedBooks[j];
                                sortedBooks[j] = temp;
                            }
                        }
                    }
                    else if (order == "descending")
                    {
                        if (sortedBooks[i].author.Split(' ')[1] == "(Translated")
                        {
                            if (sortedBooks[i].author.Split(" ")[0].CompareTo(sortedBooks[j].author.Split(" ")[1]) < 0)
                            {
                                Books temp = sortedBooks[i];
                                sortedBooks[i] = sortedBooks[j];
                                sortedBooks[j] = temp;
                            }
                        }
                        if (sortedBooks[j].author.Split(' ')[1] == "(Translated")
                        {
                            if (sortedBooks[i].author.Split(" ")[1].CompareTo(sortedBooks[j].author.Split(" ")[0]) < 0)
                            {
                                Books temp = sortedBooks[i];
                                sortedBooks[i] = sortedBooks[j];
                                sortedBooks[j] = temp;
                            }
                        }
                        if (sortedBooks[i].author.Split(' ')[1] == "(Translated" && sortedBooks[j].author.Split(' ')[1] == "(Translated")
                        {
                            if (sortedBooks[i].author.Split(" ")[0].CompareTo(sortedBooks[j].author.Split(" ")[0]) < 0)
                            {
                                Books temp = sortedBooks[i];
                                sortedBooks[i] = sortedBooks[j];
                                sortedBooks[j] = temp;
                            }
                        }
                        if (sortedBooks[i].author.Split(' ')[1] != "(Translated" && sortedBooks[j].author.Split(' ')[1] != "(Translated")
                        {
                            if (sortedBooks[i].author.Split(" ")[1].CompareTo(sortedBooks[j].author.Split(" ")[1]) < 0)
                            {
                                Books temp = sortedBooks[i];
                                sortedBooks[i] = sortedBooks[j];
                                sortedBooks[j] = temp;
                            }
                        }
                    }
                }
            }
            return sortedBooks;
        }

        public void PrintGroupedBooksByAuthorLastName(List<Books> sortedBooks)
        {
            string currentAuthor = sortedBooks[0].author.Split(" ")[1];
            if (currentAuthor == "(Translated")
            {
                Console.Write($"{ANSICodes.Colors.Cyan}{currentAuthor}{ANSICodes.Reset}");
            }
            else
            {
                Console.Write($"{ANSICodes.Colors.Cyan}{currentAuthor}{ANSICodes.Reset}");
            }
            foreach (Books book in sortedBooks)
            {
                if (currentAuthor != book.author.Split(" ")[1])
                {
                    if (book.author.Split(" ")[1] == "(Translated")
                    {
                        currentAuthor = book.author.Split(" ")[0];
                        Console.WriteLine("");
                        Console.Write($"{ANSICodes.Colors.Cyan}{currentAuthor} : {ANSICodes.Reset}");
                        Console.Write($"{book.title} , ");
                    }
                    else
                    {
                        currentAuthor = book.author.Split(" ")[1];
                        Console.WriteLine("");
                        Console.Write($"{ANSICodes.Colors.Cyan}{currentAuthor} : {ANSICodes.Reset}");
                        Console.Write($"{book.title} , ");
                    }
                }
                else
                {
                    Console.Write($"{book.title} , ");
                }
            }
            Console.WriteLine("");
        }

        public void PrintGroupedBooksByAuthorFirstName(List<Books> sortedBooks)
        {
            string currentAuthor = sortedBooks[0].author.Split(" ")[0];
            Console.Write($"{ANSICodes.Colors.Cyan}{currentAuthor}{ANSICodes.Reset}");
            foreach (Books book in sortedBooks)
            {
                if (currentAuthor != book.author.Split(" ")[0])
                {
                    currentAuthor = book.author.Split(" ")[0];
                    Console.WriteLine("");
                    Console.Write($"{ANSICodes.Colors.Cyan}{currentAuthor} : {ANSICodes.Reset}");
                    Console.Write($"{book.title} , ");
                }
                else
                {
                    Console.Write($"{book.title} , ");
                }
            }
            Console.WriteLine("");
        }

        public List<Books> SortBooksAlphabeticallyByTitle(Books[] books, string order)
        {
            List<Books> sortedBooks = new List<Books>(books);

            for (int i = 0; i < sortedBooks.Count; i++)
            {
                for (int j = i + 1; j < sortedBooks.Count; j++)
                {
                    if (order == "ascending")
                    {
                        if (sortedBooks[i].title.CompareTo(sortedBooks[j].title) > 0)
                        {
                            Books temp = sortedBooks[i];
                            sortedBooks[i] = sortedBooks[j];
                            sortedBooks[j] = temp;
                        }
                    }
                    else if (order == "descending")
                    {
                        if (sortedBooks[i].title.CompareTo(sortedBooks[j].title) < 0)
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
        public List<Books> SortBooksChronologicallyByPublicationYear(Books[] books, string order)
        {
            List<Books> sortedBooks = new List<Books>(books);

            for (int i = 0; i < sortedBooks.Count; i++)
            {
                for (int j = i + 1; j < sortedBooks.Count; j++)
                {
                    if (order == "ascending")
                    {
                        if (sortedBooks[i].publication_year > sortedBooks[j].publication_year)
                        {
                            Books temp = sortedBooks[i];
                            sortedBooks[i] = sortedBooks[j];
                            sortedBooks[j] = temp;
                        }
                    }
                    else if (order == "descending")
                    {
                        if (sortedBooks[i].publication_year < sortedBooks[j].publication_year)
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
    }
}