using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    [Serializable]
    public class ProductStore
    {
        private List<Product> ProductList = new List<Product>();

        public  IEnumerable<Product> GetAllProducts()
        {
            return ProductList;
        }

        public  void AddProduct(Product product)
        {
            ProductList.Add(product);
        }

        public void Update(Product product)
        {
            foreach (var item in ProductList)
            {
                if(item.Id == product.Id)
                {
                    item.EndDate = product.StartDate;
                    break;
                }
            }
            ProductList.Add(product);
        }
        public void Delete(int productId)
        {
            foreach (var item in ProductList)
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
            foreach (var item in ProductList)
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
            foreach (var item in ProductList)
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
