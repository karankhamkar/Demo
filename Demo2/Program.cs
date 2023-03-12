using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Demo2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================== Welcome To Product Application ==================================");
            ProductStore productStore = new ProductStore();
            int option;
            GetUser();
            do
            {
                Menu();
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Product product = GetProduct(true);
                        productStore.AddProduct(product);
                        break;
                    case 2:
                        ShowProducts(productStore.GetAllProducts());
                        break;
                    case 3:
                        DeleteProduct(productStore);
                        break;
                    case 4:
                        UpadateProduct(productStore);
                        break;
                    case 5:
                        DisplayDeletedHistory(productStore);
                        break;
                    case 6:
                        DisplayUpdatedHistory(productStore);
                        break;
                    case 7:
                        ConvertToFile(productStore);
                        break;
                    case 8:
                        ConvertFileToConsole(productStore);
                        break;
                }
            }
            while (option < 9);
            Console.ReadLine();
        }

        #region Static Methods
        private static void GetUser()
        {
           
            string enteredUsername = GetUserName();
            string enteredPassword = GetPassWord();

            bool credentialsMatch = false;
            foreach (var userCredential in ProductStore.GetAllUser())
            {
                if (enteredUsername == userCredential.UserName && enteredPassword == userCredential.Password)
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
        }

        private static string GetPassWord()
        {
            Console.WriteLine("\nPlease enter your password :");
            string input = Console.ReadLine();
            if (User.IsPasswordValid(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Invaid PassWord or Password exceeds the character limit.\nPlease Re-enter name.");
                return GetName();
            }
        }

        private static string GetUserName()
        {
            Console.WriteLine("\nPlease enter your username :");
            string input = Console.ReadLine();
            if (User.IsUserNameValid(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("\nInvalid User Name.\nPlease Re-enter name.");
                return GetName();
            }
        }

        private static void Menu()
        {
            Console.WriteLine("\nSelect your choice from following Menu : \n1. Add Products.\n2. Show Products.\n3. Delete Product.\n4. Update Product.\n5. Delete Record History.\n6. Get Product JanamKundali.\n7. Create File Of Product.\n8. Get File From Machine.\n9. Exit Program.\nEnter Your Choice : ");
        }

        public static Product GetProduct(bool isNew, int? productId = null)
        {
            int id;
            string name;
            decimal price;
            if (isNew)
            {
                id = GetProductId();
            }
            else
            {
                id = productId.Value;
            }
            name = GetName();
            price = GetPrice();

            Product product = new Product(id, name, price);
            return product;
        }

        public static void ShowProducts(IEnumerable<Product> productList)
        {
            foreach (var item in productList)
            {
                DisplayProducts(item);
            }
        }
        private static void DisplayProducts(Product item)
        {
            Console.WriteLine($"\nProduct ID : {item.Id}\nProduct Name : {item.Name}\nProduct Price : {item.Price}\nProduct Form Date : {item.StartDate}\nProduct End Date : {item.EndDate}");
        }

        private static decimal GetPrice()
        {
            Console.WriteLine("Enter Product Price : ");
            string input = Console.ReadLine();
            decimal price;
            bool isValidPrice = Product.IsValidPrice(input, out price);
            if (isValidPrice)
            {
                return price;
            }
            else
            {
                Console.WriteLine("Invalid Product Price.\nRe-enter Product Price.");
                return GetPrice();
            }
        }
        private static string GetName()
        {
            Console.WriteLine("Enter Name : ");
            string input = Console.ReadLine();
            if (Product.IsNameValid(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Product name exceeds the character limit.\nPlease Re-enter name.");
                return GetName();
            }
        }
        private static int GetProductId()
        {
            Console.WriteLine("Enter Product Id : ");
            string input = Console.ReadLine();
            int productId;
            bool isValidProduct = Product.IsValidProductId(input, out productId);
            if (isValidProduct)
            {
                return productId;
            }
            else
            {
                Console.WriteLine("Invalid Product Id.\nRe-enter Product Id.");
                return GetProductId();
            }
        }
        private static void ConvertToFile(ProductStore productStore)
        {
            Console.WriteLine("Create File Here.");
            string path = @"C:\Training\Pitech\Pune Training\C#\Day 6\ProductList"+ Guid.NewGuid()+".txt";
            var productList = productStore.GetUpdateHistory();
            FileStream stream = new FileStream(path,FileMode.OpenOrCreate);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, productList);
            stream.Close();
            Console.WriteLine("\nFile Created Successfully at ->\n"+path);

        }
        private static void ConvertFileToConsole(ProductStore productStore)
        {
            string path = @"C:\Training\Pitech\Pune Training\C#\Day 6\ProductList2cfa5d99-a5f6-454b-8781-2dde388815ce.txt";
            FileStream stream  = new FileStream(path, FileMode.OpenOrCreate);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            productStore = (ProductStore)binaryFormatter.Deserialize(stream);
            Console.WriteLine(productStore.GetAllProducts());
            stream.Close();

        }
        private static void DisplayUpdatedHistory(ProductStore productStore)
        {
            var productList = productStore.GetUpdateHistory();

            if (productList != null && productList.Any())
            {
                Console.WriteLine("\nShowing History Of Updated Products.");
                ShowProducts(productList);
            }
            else
            {
                Console.WriteLine("\nUpdated History Is Empty.");
            }
        }

        private static void DisplayDeletedHistory(ProductStore productStore)
        {
            var productList = productStore.GetDeleteHistory();
            if (productList != null && productList.Any())
            {
                Console.WriteLine("\nShowing History Of Deleted Products.");
                ShowProducts(productList);
            }
            else
            {
                Console.WriteLine("\nDeletd History Is Empty.");
            }

        }

        private static void DeleteProduct(ProductStore productStore)
        {
            Console.WriteLine("Which Product Do You Want To Delete?\nPlease enter Product Id.");
            int productId = int.Parse(Console.ReadLine());
            productStore.Delete(productId);
            Console.WriteLine("\nDelete Product Successfully.");
        }

        private static void UpadateProduct(ProductStore productStore)
        {
            Console.WriteLine("Which Product Do You Want To Udate?\nPlease enter Product Id.");
            int productId = int.Parse(Console.ReadLine());
            Product product = GetProduct(false, productId);
            productStore.Update(product);
            Console.WriteLine("\nUpdate Product Successfully.");
        }
        #endregion
    }
}
