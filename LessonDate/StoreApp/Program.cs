using System;
using System.Collections.Generic;

namespace StoreApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            store.Products = new List<Product>
            {
                new Product("Cola 1L",2,new DateTime(2023,10,20),new DateTime(2022,9,6,20,30,0)),
                new Product("Ayran 1L",1.5,new DateTime(2020,10,20),new DateTime(2021,9,6,20,30,0)),
                new Product("Cole 1L",2,new DateTime(2024,9,20),new DateTime(2022,9,4,20,30,0)),
                new Product("Fante 1L",2.5,new DateTime(2025,10,20),new DateTime(2022,9,6,0,30,0)),
                new Product("Sprite 1L",3,new DateTime(2022,10,20),new DateTime(2020,9,6,20,30,0)),
                new Product("Corek",3.5,new DateTime(2021,10,20),new DateTime(2022,5,6,20,30,0)),
                new Product("Halal nemet min bereket",5.5,new DateTime(2022,10,20),new DateTime(2022,9,3,20,30,0)),
                new Product("Sacaqli pendir",3.3,new DateTime(2022,9,20),new DateTime(2022,3,6,20,30,0)),
                new Product("Mehsul1",2,new DateTime(2022,9,25),new DateTime(2022,3,6,20,30,0)),
                new Product("Mehsul2 1L",2,new DateTime(2023,10,20),new DateTime(2021,9,6,20,30,0)),
                new Product("Mehsul3",2,new DateTime(2022,9,10),new DateTime(2022,9,1,20,30,0)),
                new Product("Mehsul4",2,new DateTime(2023,10,20),new DateTime(2022,9,3,20,30,0)),
            };

            Console.WriteLine("==============================================================");
            Console.WriteLine("Istifade muddet bitmis mehsullar:");
            foreach (var item in store.FindAll(x=>x.ExpireDate<DateTime.Now))
            {
                Console.WriteLine($"{item.Name} - {item.Price} - {item.ExpireDate.ToString("dd-MM-yyyy")}");
            }

            Console.WriteLine("\n==============================================================");
            Console.WriteLine("Istifade muddeti bu ay icinde bitecek mehsullar:");
            foreach (var item in store.FindAll(x => x.ExpireDate.Month==DateTime.Now.Month && x.ExpireDate.Year == DateTime.Now.Year))
            {
                Console.WriteLine($"{item.Name} - {item.Price} - {item.ExpireDate.ToString("dd-MM-yyyy")}");
            }

            Console.WriteLine("\n==============================================================");
            Console.WriteLine("Istifade muddetinin bitmeyine 1 il ve ya daha cox qalan mehsullar:");
            foreach (var item in store.Products.FindAll(x => x.ExpireDate>=DateTime.Now.AddYears(1)))
            {
                Console.WriteLine($"{item.Name} - {item.Price} - {item.ExpireDate.ToString("dd-MM-yyyy")}");
            }

            var r = store.Products[0].ExpireDate - DateTime.Now;
            Console.WriteLine(r.TotalHours);


            Console.WriteLine(store.Products.FindAll(x=>x.ExpireDate<DateTime.Now).Count>0);
            Console.WriteLine(store.Products.Exists(x => x.ExpireDate < DateTime.Now));
            Console.WriteLine(store.Products.Find(x=>x.Price<100)?.Price);
            var pr = store.Products.Find(x => x.Price < 100);
            Console.WriteLine(pr==null?"Mehsul yoxdur":pr.Name);

            Console.WriteLine("\n==============================================================");
            Console.WriteLine("Son 3 gunde elave edilmisler:");
            //foreach (var item in store.Products.FindAll(x => (DateTime.Now-x.EnterDate).TotalDays<=3))
            foreach (var item in store.Products.FindAll(x => DateTime.Now.Date<=x.EnterDate.AddDays(3).Date))
            {
                Console.WriteLine($"{item.Name} - {item.Price} - {item.ExpireDate.ToString("dd-MM-yyyy")} - {item.EnterDate.ToString("dd-MM-yyyy HH:mm")}");
            }

            Console.WriteLine("\n==============================================================");
            Console.WriteLine("Bugun elave edilmisler:");
            foreach (var item in store.Products.FindAll(x => x.EnterDate.Date == DateTime.Now.Date))
            {
                Console.WriteLine($"{item.Name} - {item.Price} - {item.ExpireDate.ToString("dd-MM-yyyy")} - {item.EnterDate.ToString("dd-MM-yyyy HH:mm")}");
            }

            Console.WriteLine("100 gunden evven elave edilmis mehsullar:");
            foreach (var item in store.Products.FindAll(x => (DateTime.Now - x.EnterDate).TotalHours > 2400))
            {
                Console.WriteLine($"{item.Name} - {item.Price} - {item.ExpireDate.ToString("dd-MM-yyyy")} - {item.EnterDate.ToString("dd-MM-yyyy HH:mm")}");
            }




        }
    }
}
