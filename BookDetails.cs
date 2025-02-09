using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class BookDetails
    {
        public string BookName { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public int NoOfCopies { get; set; }

        static List<List<string>> bookList = new List<List<string>>();
        public List<string> read()
        {
            List<string> bookDetails = new List<string>();
            Console.Write("Enter Book Name: ");
            BookName = Console.ReadLine();
            bookDetails.Add($"Book Name: {BookName.ToLower()}");

            Console.Write("Enter Author: ");
            Author = Console.ReadLine();
            bookDetails.Add($"Author: {Author.ToLower()}");

            Console.Write("Enter ISBN (Press '0' to skip): ");
            ISBN = Console.ReadLine();
            if (ISBN == "-")
            {
                ISBN = "None";
            }
            bookDetails.Add($"ISBN: {ISBN.ToLower()}");

            Console.Write("Enter Publisher (Press '0' to skip): ");
            Publisher = Console.ReadLine();
            if (Publisher == "-")
            {
                Publisher = "None";
            }
            bookDetails.Add($"Publisher: {Publisher.ToLower()}");

            Console.Write("Enter Number of Copies Avaiable (Press '0' to skip): ");
            NoOfCopies = Convert.ToInt32(Console.ReadLine());

            bookDetails.Add($"Number of Copies Available: {NoOfCopies.ToString().ToLower()}");

            return bookDetails;
        }

        //AddBooks()
        public void AddBooks(List<string> bookDetailsList) 
        {
            bookList.Add(bookDetailsList);

            Console.WriteLine("\nBook Added Successfully!");
            Console.WriteLine($"\nSequence No: {bookList.IndexOf(bookDetailsList)+1}");
        }

        //DeleteBooks()
        public void DeleteBooks() 
        {
            Console.Write("\nEnter the Sequence Number: ");
            int recordNo = Convert.ToInt32(Console.ReadLine()) - 1;

            foreach (string bookData in bookList[recordNo])
            {
                Console.WriteLine(bookData);
            }

            Console.WriteLine("\nYou are about to delete this record.");
            Console.Write("Confirm Deletion (1 - Delete/ 0 - Cancel): ");
            int confirmation = Convert.ToInt32(Console.ReadLine());

            if (confirmation == 1)
            {
                BookDetails.bookList.Remove(bookList[recordNo]);
                Console.WriteLine("\nBook Removed Successfully!");
            }

            else if (confirmation == 0)
            {
                Console.WriteLine("\nBook Deletion Cancelled!");
            }
        }

        //UpdateBooks()
        public void UpdateBooks() 
        {
            Console.Write("\nEnter the Sequence Number: ");
            int recordNo = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.WriteLine("\n------------------- PROPERTIES OF BOOK -------------------");
            for (int i=0; i < bookList[recordNo].Count; i++)
            {
                int endIndex = bookList[recordNo][i].IndexOf(":"); //To print Only the field without its values.
                int Length = endIndex - 0;
                Console.WriteLine($"{i+ 1}. {bookList[recordNo][i].Substring(0,Length)}"); //bookData + 1 to get the sequence
            }

            Console.WriteLine();
            while (true)
            {
                Console.Write("Enter the number of the field you want update: ");
                int fieldNo = Convert.ToInt32(Console.ReadLine());
                if (fieldNo == 1)
                {
                    Console.WriteLine($"\nCurrent Book Name: {bookList[recordNo][0]}");
                    Console.Write("Enter the new name: ");
                    string newName = Console.ReadLine();
                    newName = bookList[recordNo][0];

                    Console.WriteLine("\nDo you want to update another filed? (1 - Yes/ 0 - No)");
                    string userInput = Console.ReadLine();
                    if (Convert.ToInt32(userInput) == 1)
                    {
                        continue;
                    }

                    else if (Convert.ToInt32(userInput) == 0)
                    {
                        Console.WriteLine("\nBook Updated Successfully!\n\n");
                        break;
                    }
                }

                else if (fieldNo == 2)
                {
                    Console.WriteLine($"\nCurrent Author's Name: {bookList[recordNo][1]}");
                    Console.Write("Enter the new author: ");
                    string newAuthor = Console.ReadLine();
                    newAuthor = bookList[recordNo][1];

                    Console.WriteLine("\nDo you want to update another filed? (1 - Yes/ 0 - No)");
                    string userInput = Console.ReadLine();
                    if (Convert.ToInt32(userInput) == 1)
                    {
                        continue;
                    }

                    else if (Convert.ToInt32(userInput) == 0)
                    {
                        Console.WriteLine("\nBook Updated Successfully!\n\n");
                        break;
                    }
                }

                else if (fieldNo == 3)
                {
                    Console.WriteLine($"\nCurrent ISBN: {bookList[recordNo][2]}");
                    Console.Write("Enter the new ISBN: ");
                    string newISBN = Console.ReadLine();
                    newISBN = bookList[recordNo][2];

                    Console.WriteLine("\nDo you want to update another filed? (1 - Yes/ 0 - No)");
                    string userInput = Console.ReadLine();
                    if (Convert.ToInt32(userInput) == 1)
                    {
                        continue;
                    }

                    else if (Convert.ToInt32(userInput) == 0)
                    {
                        Console.WriteLine("\nBook Updated Successfully!\n\n");
                        break;
                    }
                }

                else if (fieldNo == 4)
                {
                    Console.WriteLine($"\nCurrent Publisher's Name: {bookList[recordNo][3]}");
                    Console.Write("Enter the new publisher: ");
                    string newPublisher = Console.ReadLine();
                    newPublisher = bookList[recordNo][3];

                    Console.WriteLine("\nDo you want to update another filed? (1 - Yes/ 0 - No)");
                    string userInput = Console.ReadLine();
                    if (Convert.ToInt32(userInput) == 1)
                    {
                        continue;
                    }

                    else if (Convert.ToInt32(userInput) == 0)
                    {
                        Console.WriteLine("\nBook Updated Successfully!\n\n");
                        break;
                    }
                }

                else
                {
                    Console.WriteLine($"\nCurrent No. of Copies Available: {bookList[recordNo][4]}");
                    Console.Write("Enter the new name: ");
                    string newNoOfCopies = Console.ReadLine();
                    newNoOfCopies = bookList[recordNo][4];

                    Console.WriteLine("\nDo you want to update another filed? (1 - Yes/ 0 - No)");
                    string userInput = Console.ReadLine();
                    if (Convert.ToInt32(userInput) == 1)
                    {
                        continue;
                    }

                    else if (Convert.ToInt32(userInput) == 0)
                    {
                        Console.WriteLine("\nBook Updated Successfully!\n\n");
                        break;
                    }
                }
            
            }
        }

        //SearchBooks()
        public void SearchBooks()
        {
            Console.WriteLine("\n------------------- SEARCH PARAMETERS OF BOOK -------------------");
            for (int i=0; i < bookList[0].Count; i++) //only to get serch options
            {
                int endIndex = bookList[0][i].IndexOf(":"); //To print Only the field without its values.
                int Length = endIndex - 0;
                Console.WriteLine($"{i + 1}. {bookList[0][i].Substring(0, Length)}"); //bookData + 1 to get the sequence
            }

            Console.Write("\nEnter the number of the parameter you want to search with: ");
            int searchParameter = Convert.ToInt32(Console.ReadLine());
            if (searchParameter == 1)
            {
                Console.Write("\nEnter the name of the book: ");
                string searchedBookName = Console.ReadLine();
                Console.WriteLine();
                for (int i=0; i < bookList.Count; i++)
                {
                    List<string> bookArray = bookList[i];
                    if (bookArray[0].ToLower()==$"book name: {searchedBookName}")
                    {
                        Console.Write($"sequence no.: {i + 1}");
                        foreach(string item in bookArray)
                        {
                            Console.Write($"\t{item}");
                        }
                        Console.WriteLine();
                    }

                    else
                    {
                        continue;
                    }
                }
            }

            else if (searchParameter == 2)
            {
                Console.Write("\nEnter the author of the book: ");
                string searchedBookAuthor = Console.ReadLine();
                Console.WriteLine();
                for (int i = 0; i < bookList.Count; i++)
                {
                    List<string> bookArray = bookList[i];
                    if (bookArray[1].ToLower() == $"author: {searchedBookAuthor}")
                    {
                        Console.Write($"sequence no.: {i + 1}");
                        foreach (string item in bookArray)
                        {
                            Console.Write($"\t{item}");
                        }
                        Console.WriteLine();
                    }           

                    else
                    {
                        continue;
                    }
                }
            }

            else if (searchParameter == 3)
            {
                Console.Write("\nEnter the ISBN of the book: ");
                string searchedBookISBN = Console.ReadLine();
                Console.WriteLine();
                for (int i = 0; i < bookList.Count; i++)
                {
                    List<string> bookArray = bookList[i];
                    if (bookArray[2].ToLower() == $"isbn: {searchedBookISBN}")
                    {
                        Console.Write($"sequence no.: {i + 1}");
                        foreach (string item in bookArray)
                        {
                            Console.Write($"\t{item}");
                        }
                        Console.WriteLine();
                    }

                    else
                    {
                        continue;
                    }
                }
            }

            else if(searchParameter==4)
            {
                Console.Write("\nEnter the publisher of the book: ");
                string searchedBookPublisher = Console.ReadLine();
                Console.WriteLine();
                for (int i = 0; i < bookList.Count; i++)
                {
                    List<string> bookArray = bookList[i];
                    if (bookArray[3].ToLower() == $"publisher: {searchedBookPublisher}")
                    {
                        Console.Write($"sequence no.: {i + 1}");
                        foreach (string item in bookArray)
                        {
                            Console.Write($"\t{item}");
                        }
                        Console.WriteLine();
                    }

                    else
                    {
                        continue;
                    }
                }
            }

            else
            {
                Console.Write("\nEnter the no. of the copies: ");
                string searchedNoOfCopies = Console.ReadLine();
                Console.WriteLine();
                for (int i = 0; i < bookList.Count; i++)
                {
                    List<string> bookArray = bookList[i];
                    if (bookArray[4].ToLower() == $"number of copies available:: {searchedNoOfCopies}")
                    {
                        Console.Write($"sequence no.: {i + 1}");
                        foreach (string item in bookArray)
                        {
                            Console.Write($"\t{item}");
                        }
                        Console.WriteLine();
                    }

                    else
                    {
                        continue;
                    }
                }
            }
        }
        public BookDetails() {}
        public BookDetails(string bookName, string author, string iSBN, string publisher, int noOfCopies)
        {
            BookName = bookName;
            Author = author;
            ISBN = iSBN;
            Publisher = publisher;
            NoOfCopies = noOfCopies;
            List<string> bookDetails=new List<string>();
            AddBooks(bookDetails);
        } //book1
    }
}
