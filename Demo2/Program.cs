using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================== Welcome To Product Application ==================================");
            ProductStore productStore = new ProductStore();
            int option;
            do
            {
                Console.WriteLine("Select your choice from following Menu : \n1. Add Products.\n2. Show Products.\n3. Delete Product.\n4. Update Product.\n5. Delete Record History.\n6. Get Product JanamKundali.\n7. Exit Program.\nEnter Your Choice : ");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Product product = GetProduct(true);
                        productStore.AddProduct(product);
                        break;
                    case 2:
                        //ProductStore.ShowProducts();
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
                }
            }
            while (option > 7);
            Console.ReadLine();

            #region Non-Static Methods


            void UpdateTrackHistory()
            {
                throw new NotImplementedException();
            }

            void DeleteTrackHistory()
            {
                throw new NotImplementedException();
            }

            void Update()
            {
                throw new NotImplementedException();
            }

            void Deleted()
            {
                throw new NotImplementedException();
            }

            void ShowProducts()
            {
                throw new NotImplementedException();
            }
            #endregion

        }

        private static void DisplayUpdatedHistory(ProductStore productStore)
        {
            
        }

        private static void DisplayDeletedHistory(ProductStore productStore)
        {
            
        }

        private static void DeleteProduct(ProductStore productStore)
        {
            Console.WriteLine("Which Product Do You Want To Delete?\nPlease enter Product Id.");
            int productId = int.Parse(Console.ReadLine());
            productStore.Delete(productId);
        }

        private static void UpadateProduct(ProductStore productStore)
        {
            Console.WriteLine("Which Product Do You Want To Udate?\nPlease enter Product Id.");
            int productId = int.Parse(Console.ReadLine());
           Product product = GetProduct(false, productId);
           productStore.Update(product);
        }

        #region Non-Static Methods
        public static Product GetProduct(bool isNew,int? productId = null)
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

        public static void ShowProducts()
        {
            // foreach (var item in productList)
            //{
            //    DisplayProducts(item);
            //}
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
        #endregion
    }
}
