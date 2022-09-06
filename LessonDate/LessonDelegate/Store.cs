using System;
using System.Collections.Generic;
using System.Text;

namespace LessonDelegate
{
    internal class Store
    {
        public List<Product> Products = new List<Product>();

        public List<Product> FindProductsLessThan1()
        {
            List<Product> newProducts = new List<Product>();
            foreach (var item in this.Products)
            {
                if (item.Price < 1)
                    newProducts.Add(item);
            }
            return newProducts;
        }

        public List<Product> FindProductsGreaterThan10()
        {
            List<Product> newProducts = new List<Product>();
            foreach (var item in this.Products)
            {
                if (item.Price >10)
                    newProducts.Add(item);
            }
            return newProducts;
        }

        public List<Product> FindAll(Predicate<Product> func)
        {
            List<Product> newProducts = new List<Product>();

            foreach (var item in this.Products)
            {
                if (func(item))
                    newProducts.Add(item);
            }

            return newProducts;
        }




    }
}
