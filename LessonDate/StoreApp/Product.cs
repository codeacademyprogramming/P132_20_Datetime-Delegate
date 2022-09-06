using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp
{
    internal class Product
    {
        public Product(string name,double price,DateTime date,DateTime enterDate)
        {
            this.Name = name;
            this.ExpireDate = date;
            this.Price = price;
            this.EnterDate = enterDate;
        }
        public string Name;
        public double Price;
        public DateTime ExpireDate;
        public DateTime EnterDate;
    }
}
