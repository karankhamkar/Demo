using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    public class ProductStore
    {
        private static List<Product> productList = new List<Product>();

        public static IEnumerable<Product> GetAllProducts()
        {
            return productList;
        }
        #region Non-Static Methods
        public static void AddProduct()
        {
            char again;
            do
            {
                int id = GetProductId();
                string name = GetName();
                decimal price = GetPrice();

                Product product = new Product(id, name, price);
                productList.Add(product);
                Console.WriteLine("Do you want to continue, press y / n : ");
                again = char.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            while (again == 'Y' || again == 'y');
           
            foreach (var item in productList)
            {
                DisplayProducts(item);
            }
        }

        public static void ShowProducts()
        {
            
        }
        private static void DisplayProducts(Product item)
        {
            Console.WriteLine($"\nProduct ID : {item.Id}\nProduct Name : {item.Name}\nProduct Price : {item.Price}\nProduct Form Date : {item.StartDate}");
        }

        public static void UpdateTrackHistory()
        {
            throw new NotImplementedException();
        }

        public static void DeleteTrackHistory()
        {
            throw new NotImplementedException();
        }

        public static void Update()
        {
            throw new NotImplementedException();
        }

        public static void Deleted()
        {
            throw new NotImplementedException();
        }


        #endregion

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
    }
}
