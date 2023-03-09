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
            
            int option;
            do
            {
                Console.WriteLine("Select your choice from following Menu : \n1. Add Products.\n2. Show Products.\n3. Delete Product.\n4. Update Product.\n5. Delete Record History.\n6. Get Product JanamKundali.\n7. Exit Program.\nEnter Your Choice : ");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        ProductStore.AddProduct();
                        break;
                    case 2:
                        ProductStore.ShowProducts();
                        break;
                    case 3:
                        ProductStore.Deleted();
                        break;
                    case 4:
                        ProductStore.Update();
                        break;
                    case 5:
                        DeleteTrackHistory();
                        break;
                    case 6:
                        UpdateTrackHistory();
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

        
    }
}
