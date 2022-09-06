using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp
{
    internal class Store
    {
        public List<Product> Products = new List<Product>();

        public List<Product> FindAll(Predicate<Product> check)
        {
            List<Product> newProducts = new List<Product>();

            foreach (Product product in this.Products)
            {
                if (check(product))
                    newProducts.Add(product);
            }   

            return newProducts; 
        }
    }
}
