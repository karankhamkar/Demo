using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    public class ProductStore
    {
        private  List<Product> productList = new List<Product>();

        public  IEnumerable<Product> GetAllProducts()
        {
            return productList;
        }

        public  void AddProduct(Product product)
        {
            productList.Add(product);
        }

        public void Update(Product product)
        {
            foreach (var item in productList)
            {
                if(item.Id == product.Id)
                {
                    item.EndDate = product.StartDate;
                    break;
                }
            }
            productList.Add(product);
        }
        public void Delete(int productId)
        {
            foreach (var item in productList)
            {
                if (item.Id == productId)
                {
                    item.Delete();
                    break;
                }
            }
        }

        public IEnumerable<Product> GetUpdateHistory()
        {
           List<Product> products = new List<Product>();
            foreach (var item in productList)
            {
                if(item.EndDate != null && item.IsDeleted == false)
                {
                    products.Add(item);
                }
            }
            return products;
        }
        public IEnumerable<Product> GetDeleteHistory()
        {
            List<Product> products = new List<Product>();
            foreach (var item in productList)
            {
                if (item.IsDeleted == true)
                {
                    products.Add(item);
                }
            }
            return products;
        }
    }
}
