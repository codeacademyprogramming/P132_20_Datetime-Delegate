using System;
using System.Threading;

namespace LessonDate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("az-AZ");
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            DateTime date = new DateTime(2022, 9, 6, 15, 30, 55);

            date = date.AddDays(4);
            date = date.AddYears(4);
            date = date.AddYears(-26);
            date = date.AddDays(-20);

            date = DateTime.Now;
            date = DateTime.UtcNow;


            date = date.AddHours(4);

            DateTime date1 = new DateTime(2020, 01, 20,14,20,0);
            DateTime date2 = new DateTime(2020, 01, 20,18,30,0);


            Console.WriteLine(date2==date1);

            Console.WriteLine(date);
            Console.WriteLine(date.ToLongDateString());
            Console.WriteLine(date.ToShortDateString());
            Console.WriteLine(date.ToLongTimeString());
            Console.WriteLine(date.ToShortTimeString());
            date = date.AddHours(8);
            Console.WriteLine(date.ToString("dddd-MMMM dd-yyyy"));
            Console.WriteLine(date.ToString("dd-MM-yyyy HH:mm:ss"));


            Console.WriteLine("Tarixi daxil edin:");

            string dateStr = Console.ReadLine();

            //DateTime newDate = Convert.ToDateTime(dateStr);
            //DateTime newDate = DateTime.Parse(dateStr);
            DateTime newDate;


            if(DateTime.TryParse(dateStr, out newDate))
            {
                Console.WriteLine(newDate.ToString("dd-MM-yyyy HH:mm"));
            }
            else
            {
                Console.WriteLine("Format yanlisdir!");
            }



            Console.WriteLine("=====================================");

            string dateInputStr;
            DateTime dateInput;

            do
            {
                Console.WriteLine("Dogum tarixinizi daxil edin");
                dateInputStr = Console.ReadLine();

            } while (!DateTime.TryParse(dateInputStr,out dateInput));

            Console.WriteLine(dateInput.DayOfWeek);
            Console.WriteLine(dateInput.ToString("dddd"));

        }
    }
}
