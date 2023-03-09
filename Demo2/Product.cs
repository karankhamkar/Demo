using System;

namespace Demo2
{
    public class Product
    {

        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        #endregion

        #region Constructor
        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }


        #endregion
        #region Methods
        public static bool IsNameValid(string input)
        {
            bool result = false;
            if (string.IsNullOrEmpty(input) == false && input.Length <= 100)
            {
                result = true;
            }
            return result;
        }
        public static bool IsValidProductId(string input, out int productId)
        {
            bool result = false;
            productId = -1;
            int parsedInteger;
            bool isValidInteger = int.TryParse(input, out parsedInteger);
            if (isValidInteger)
            {
                result = true;
                productId = parsedInteger;
            }
            return result;
        }
        public static bool IsValidPrice(string input, out decimal price)
        {
            bool result = false;
            price = -1;
            decimal parsedDecimal;
            bool isValidPrice = decimal.TryParse(input, out parsedDecimal);
            if (isValidPrice)
            {
                result= true;
                price = parsedDecimal;
            }
            return result;
        }
        #endregion
    }
}