namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Adding books While Developing the System
            /*BookDetails book1 = new BookDetails("Madol Duwa","Martin Wickramasinghe","978-955-0201-39-6","Sarasa pvt. Ltd.",2);
            List<string> bookArray = new List<string> { "Madol Duwa".ToLower(), "Martin Wickramasinghe".ToLower(), "978-955-0201-39-6".ToLower(), "Sarasa pvt. Ltd.".ToLower(), 2.ToString().ToLower() };
            book1.AddBooks(bookArray);*/

            //System
            Console.WriteLine("Welcome to the Library Management System!\n");
            while (true)
            {
                Console.WriteLine("------------------- OPERATIONS -------------------");
                Console.WriteLine("1. Add Books\n2. Delete Books\n3. Update Books\n4. Search Books\n5. Add Borrowings\n6. Return Books\n7. Update Borrowing Details\n8. Quit");
                Console.Write("\nEnter the number of the operation you want to proceed with: ");
                int operationNo = Convert.ToInt32(Console.ReadLine());
                
                while (true)
                {
                    BookDetails book = new BookDetails();
                    BorrowingDetails borrowing = new BorrowingDetails();
                    if (operationNo == 1)
                    {
                        Console.WriteLine("\n------------------- ADDING BOOKS -------------------");
                        List<string> bookProperties = book.read();
                        book.AddBooks(bookProperties);

                        Console.WriteLine("\nDo you want to add another book? (1 - Yes/ 0 - No)");
                        string userInput = Console.ReadLine();
                        if (Convert.ToInt32(userInput)==1)
                        {
                            continue;
                        }

                        else if(Convert.ToInt32(userInput)==0)
                        {
                            Console.WriteLine("\nDatabase Updated Successfully!\n\n");
                            break;
                        }
                        
                    }

                    else if (operationNo == 2)
                    {
                        Console.WriteLine("\n------------------- DELETING BOOKS -------------------");
                        book.SearchBooks();
                        book.DeleteBooks();

                        Console.WriteLine("Do you want to delete another book? (1 - Yes/ 0 - No)");
                        string userInput = Console.ReadLine();
                        if (Convert.ToInt32(userInput) == 1)
                        {
                            continue;
                        }

                        else if (Convert.ToInt32(userInput) == 0)
                        {
                            Console.WriteLine("\nDatabase Updated Successfully!\n\n");
                            break;
                        }
                    }

                    else if(operationNo == 3)
                    {
                        Console.WriteLine("\n------------------- UPDATING BOOKS -------------------");
                        book.SearchBooks();
                        book.UpdateBooks();

                        Console.WriteLine("Do you want to update another book? (1 - Yes/ 0 - No)");
                        string userInput = Console.ReadLine();
                        if (Convert.ToInt32(userInput) == 1)
                        {
                            continue;
                        }

                        else if (Convert.ToInt32(userInput) == 0)
                        {
                            Console.WriteLine("\nDatabase Updated Successfully!\n\n");
                            break;
                        }
                    }

                    else if(operationNo==4)
                    {
                        Console.WriteLine("\n------------------- SEARCHING BOOKS -------------------");
                        book.SearchBooks();

                        Console.WriteLine("\n\nDo you want to search for another book? (1 - Yes/ 0 - No)");
                        string userInput = Console.ReadLine();
                        if (Convert.ToInt32(userInput) == 1)
                        {
                            continue;
                        }

                        else if (Convert.ToInt32(userInput) == 0)
                        {
                            break;
                        }
                    }

                    else if(operationNo == 5)
                    {
                        Console.WriteLine("\n------------------- ADDING BORROWINGS -------------------");
                        List<string> borrowerDataList = borrowing.ReadBorrowerData();
                        borrowing.AddBorrowings(borrowerDataList);

                        Console.WriteLine("\n\nDo you want to add another borrowing? (1 - Yes/ 0 - No)");
                        string userInput = Console.ReadLine();
                        if (Convert.ToInt32(userInput) == 1)
                        {
                            continue;
                        }

                        else if (Convert.ToInt32(userInput) == 0)
                        {
                            break;
                        }
                    }

                    else if(operationNo == 6)
                    {
                        Console.WriteLine("\n------------------- RETURNING BOOKS -------------------");
                        borrowing.ReturnBooks();

                        Console.WriteLine("\n\nDo you want to add another returning? (1 - Yes/ 0 - No)");
                        string userInput = Console.ReadLine();
                        if (Convert.ToInt32(userInput) == 1)
                        {
                            continue;
                        }

                        else if (Convert.ToInt32(userInput) == 0)
                        {
                            break;
                        }
                    }
                }

            }
        }
    }
}

