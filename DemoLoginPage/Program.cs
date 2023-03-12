using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLoginPage
{
    public class Program
    {
        public static List<(string username, string password)> userCredentials = new List<(string, string)>()
            {
                ("user123", "pass123"),
                ("johnsmith", "password"),
                ("janesmith", "12345")
            };
        static void Main(string[] args)
        {
            GetUser();

            Console.ReadLine();
        }

        private static void GetUser()
        {
           
            Console.WriteLine("Please enter your username:");
            string enteredUsername = Console.ReadLine();

            Console.WriteLine("Please enter your password:");
            string enteredPassword = Console.ReadLine();

            bool credentialsMatch = false;
            foreach (var userCredential in userCredentials)
            {
                if (enteredUsername == userCredential.username && enteredPassword == userCredential.password)
                {
                    credentialsMatch = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Inputs.Please Try Agian");
                    GetUser();
                }
            }

            if (credentialsMatch)
            {
                Console.WriteLine("Login successful!");
                Console.WriteLine("WelCome Karan.....!olol");

                while (true)
                {
                    Console.WriteLine("Please select an option:");
                    Console.WriteLine("1. Add product");
                    Console.WriteLine("2. Delete product");
                    Console.WriteLine("3. Update product");
                    Console.WriteLine("4. Exit");

                    int option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Add product selected");
                            break;
                        case 2:
                            Console.WriteLine("Delete product selected");
                            break;
                        case 3:
                            Console.WriteLine("Update product selected");
                            break;
                        case 4:
                            Console.WriteLine("Exiting program...");
                            return;
                        default:
                            Console.WriteLine("Invalid option selected");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again.");
            }

            IsValidUser();


        }

        private static void IsValidUser()
        {
            throw new NotImplementedException();
        }
    }
}
