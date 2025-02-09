using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class BorrowingDetails
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string Faculty { get; set; }
        public string BookBorrowed { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Fine { get; set; }
        public string Status { get; set; }

        static List<List<string>> borrowing1 = new List<List<string>>(); //StudentID, StudentName, Faculty, BookBorrowed, DateBorrowed, DueDate, Fine, Status
        static List<List<string>> borrowing2 = new List<List<string>>();

        public List<string> ReadBorrowerData()
        {
            List<string> borrowingData = new List<string>();
            Console.Write("Enter Student ID: ");
            StudentID = Console.ReadLine();

            Console.Write("\n\nEnter Student Name: ");
            StudentName = Console.ReadLine();

            Console.Write("\n\nEnter Faculty (Ex: FMSC, FHSS...): ");
            Faculty = Console.ReadLine();

            borrowingData.Add($"student id: {StudentID.ToLower()}");
            borrowingData.Add($"student name: {StudentName.ToLower()}");
            borrowingData.Add($"faculty: {Faculty.ToLower()}");
            return borrowingData;
        }

        public void AddBorrowings(List<string> borrowerDataList)
        {
            DateBorrowed= DateTime.Now;
            DueDate = DateBorrowed.AddDays(14);
            Fine = 0.00m;
            Status = "Not Received";

            int count = 0;
            while (count < 2)
            {
                if (count == 0)
                {
                    Console.Write("\n\nEnter the book borrowed: ");
                    BookBorrowed = Console.ReadLine();

                    borrowerDataList.Add($"book name: {BookBorrowed.ToLower()}");
                    borrowerDataList.Add($"date borrowed: {DateBorrowed.ToString("yyyy - MM - dd")}");
                    borrowerDataList.Add($"due date: {DueDate.ToString("yyyy - MM - dd")}");
                    borrowerDataList.Add($"fine: {Fine}");
                    borrowerDataList.Add($"status: {Status.ToLower()}");

                    borrowing1.Append(borrowerDataList);
                    Console.WriteLine($"\n\nBorrowing No.: {borrowing1.IndexOf(borrowerDataList)}");
                }

                else
                {
                    Console.Write("\n\nEnter the book borrowed (Press 0 to skip): ");
                    string bookBorrowed = Console.ReadLine();

                    if(bookBorrowed != "0")
                    {
                        borrowerDataList.Add($"Book Name: {BookBorrowed.ToLower()}");
                        borrowerDataList.Add($"Date Borrowed: {DateBorrowed.ToString("yyyy - MM - dd")}");
                        borrowerDataList.Add($"Due Date: {DueDate.ToString("yyyy - MM - dd")}");
                        borrowerDataList.Add($"Fine: {Fine}");
                        borrowerDataList.Add($"Status: {Status.ToLower()}");

                        borrowing2.Append(borrowerDataList);
                        Console.WriteLine($"\n\nBorrowing No.: {borrowing2.IndexOf(borrowerDataList)}");
                        Console.WriteLine("\nBorrowing Added Successfully!");
                    }

                    else
                    {
                        Console.WriteLine("\n\nBorrowing Added Successfully!");
                        break;
                    }
                }
            }
        }

        public void ReturnBooks()
        {
            Console.Write("Enter Student ID: ");
            StudentID = Console.ReadLine();

            Console.Write("Enter Borrowing No: ");
            int borrowingNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Book Name: ");
            BookBorrowed = Console.ReadLine();

            for (int i=0; i < borrowing1.Count(); i++)
            {
                if ((borrowingNumber == i) && (borrowing1[i][0] == $"student id: {StudentID}") && (borrowing1[i][3]== $"book name: {BookBorrowed.ToLower()}") && (borrowing1[i][7] == $"status: not received"))
                {
                    DateTime dueDate = Convert.ToDateTime(borrowing1[i][5].Substring(borrowing1[i][5].IndexOf(" ") + 1)).Date;
                    DateTime currentDate = DateTime.Now.Date;
                    if (dueDate < currentDate)
                    {
                        decimal finePerDay = 20.00m; //Fine for a day is Rs.20.00
                        Fine = finePerDay * Convert.ToInt32(currentDate - dueDate);
                        borrowing1[i][5] = $"fine: {Fine}";
                    }

                    Console.Write($"\n\nborrowing no: {i}");
                    foreach (string borrowingData in borrowing1[i])
                    {
                        Console.Write($"\t{borrowingData}");
                    }

                    Console.Write("\n\nPress 1 to switch book status: ");
                    int statusSwitch=Convert.ToInt32(Console.ReadLine());
                    if(statusSwitch == 1)
                    {
                        borrowing1[i][7] = $"status: received";
                        Console.WriteLine("Database Updated!");
                    }

                    else
                    {
                        break;
                    }
                }
            }

            for (int i = 0; i < borrowing2.Count(); i++)
            {
                if ((borrowingNumber == i) && (borrowing2[i][0] == $"student id: {StudentID}") && (borrowing2[i][3] == $"book name: {BookBorrowed.ToLower()}") && (borrowing2[i][7] == $"status: not received"))
                {
                    DateTime dueDate = Convert.ToDateTime(borrowing2[i][5].Substring(borrowing2[i][5].IndexOf(" ") + 1)).Date;
                    DateTime currentDate = DateTime.Now.Date;
                    if (dueDate < currentDate)
                    {
                        decimal finePerDay = 20.00m; //Fine for a day is Rs.20.00
                        Fine = finePerDay * Convert.ToInt32(currentDate - dueDate);
                        borrowing2[i][5] = $"fine: {Fine}";
                    }

                    Console.Write($"\n\nborrowing no: {i}");
                    foreach (string borrowingData in borrowing2[i])
                    {
                        Console.Write($"\t{borrowingData}");
                    }

                    Console.Write("\n\nPress 1 to switch book status: ");
                    int statusSwitch = Convert.ToInt32(Console.ReadLine());
                    if (statusSwitch == 1)
                    {
                        borrowing2[i][7] = $"status: received";
                        Console.WriteLine("Database Updated!");
                    }

                    else
                    {
                        break;
                    }
                }
            }
        }

        public void UpdateBorrowingData()
        {
            Console.Write("Enter Student ID: ");
            StudentID = Console.ReadLine();

            Console.Write("Enter Borrowing No: ");
            int borrowingNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Book Name: ");
            BookBorrowed = Console.ReadLine();

            for (int i = 0; i < borrowing1.Count(); i++)
            {
                if ((borrowingNumber == i) && (borrowing1[i][0] == $"student id: {StudentID}") && (borrowing1[i][3] == $"book name: {BookBorrowed.ToLower()}") && (borrowing1[i][7] == $"status: not received"))
                {

                    Console.WriteLine("------------------- BORROWING DETAILS -------------------");
                    Console.Write($"\n\nborrowing no: {i}");
                    foreach (string borrowingData in borrowing2[i])
                    {
                        Console.Write($"\t{borrowingData}");
                    }
                    Console.Write("");
                }
            }
        }
    }
}
