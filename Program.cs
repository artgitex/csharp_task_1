using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Unhide to create User table
            //var buildtable = new BuildUserTable();
            //buildtable.FillTable();

            var repository = new UserRepository();           

            //main Menu
            bool menu = false;
            Console.WriteLine("Choose an option:\r");
            Console.WriteLine("------------------------\n");
            Console.WriteLine("1 - Show Users");
            Console.WriteLine("2 - Find Users");
            Console.WriteLine("3 - Remove Users");
            Console.WriteLine("4 - Exit");
            Console.WriteLine("\n------------------------");

            while (!menu)
            {
                Console.Write("\r\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("\r\n- SHOW USERS - \r\n");
                        ShowTable(repository.GetAllUsers());
                        break;
                    case "2":
                        Console.Write("\r\n- FIND USERS - \r\n");
                        FindData(repository.GetUser(AskID()));
                        break;
                    case "3":
                        Console.Write("\r\n- REMOVE USER - \r\n");
                        DeleteData(repository.Delete(AskID()));                        
                        break;
                    case "4":
                        menu = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private static int AskID()
        {
            int id;

            Console.Write("\r\nProvide User's ID:\r\n");

            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("This is not valid input. Please enter an integer value!");
                Console.Write("\r\nProvide the ID of the User: ");
            }

            return id;
        }

        private static void ShowTable(IEnumerable<User> userList)
        {
            PrintTableHeader();

            foreach (var user in userList)
            {
                TablePrint.PrintRow(user.Id.ToString(), user.Date, user.FirstName, user.SecondName, user.City, user.Country);
            }

            TablePrint.PrintLine();
        }

        private static void FindData(User user)
        {
            if (user != null)
            {
                PrintTableHeader();
                TablePrint.PrintRow(user.Id.ToString(), user.Date, user.FirstName, user.SecondName, user.City, user.Country);
                TablePrint.PrintLine();
            }
            else            
                Console.WriteLine("\r\nThe User you tried to find doesn't exist!");
        }

        private static void DeleteData(bool removed)
        {
            if (removed)            
                Console.WriteLine("\r\nThe user successfully removed!");
            else
                Console.WriteLine("\r\nThe User you tried to remove doesn't exist!");           
        }

        private static void PrintTableHeader()
        {
            TablePrint.PrintLine();
            TablePrint.PrintRow("ID", "Date", "First Name", "Second Name", "City", "Country");
            TablePrint.PrintLine();
        }       
    }
}
