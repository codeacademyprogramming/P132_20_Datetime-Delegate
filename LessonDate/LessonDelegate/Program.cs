using System;

namespace LessonDelegate
{
    internal class Program
    {
        public delegate bool CheckNum(int num);

        public delegate int CalcNums(int num1, int num2);

        static void Main(string[] args)
        {

            int[] numbers = { 3, 10, 4, 34, 50, 77 };

            Console.WriteLine(SumOdd(numbers));
            Console.WriteLine(SumEven(numbers));
            Console.WriteLine(SumDividedBy3(numbers));

            Console.WriteLine(Sum(numbers,IsOdd));

            Console.WriteLine(Sum(numbers, IsEven));
            Console.WriteLine(Sum(numbers,x=>x%3==0));
            Console.WriteLine(Sum(numbers, delegate (int n)
            {
                return n % 3 == 0;
            }));

            //CheckNum func1 = IsOdd;
            //func1.Invoke(45);

            Console.WriteLine(Calc(45,10,(x,y)=>x*y));
            Console.WriteLine(Calc(45, 10, (x, y) => x - y));
            Console.WriteLine(Calc(45, 10, (x, y) => x + y));
            Console.WriteLine(Calc(45, 10, (x, y) => x / y));

            Func<int, bool> funcCheck = IsOdd;

            Func<int, int, int> funcCalc = Sum;

            Action<int> action = (x) => Console.WriteLine($"result={x}");

            Predicate<int> predicate = IsEven;

            Func<string, string, string> funcStr = (x, y) => x + " " + y;

            Store store = new Store();

            store.Products.Add(new Product
            {
                Name = "Milla ayran 1L",
                Price = 2
            });
            store.Products.Add(new Product
            {
                Name = "Eseb dermani",
                Price = 5
            });
            store.Products.Add(new Product
            {
                Name = "Cola zero 0.5",
                Price = 0.9
            });


            foreach (var item in store.FindAll(x=>x.Price>1))
            {
                Console.WriteLine(item.Name+" - "+item.Price);
            }
        }

        static bool IsOdd(int num)
        {
            return num % 2 == 1;
        }

        static bool IsEven(int num)
        {
            return num % 2 == 0;
        }

        static int Sum(int[] numbers,Func<int,bool> check)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (check(numbers[i]))
                    sum += numbers[i];
            }
            return sum;
        }

        static int SumOdd(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 1)
                    sum += numbers[i];
            }
            return sum;
        }

        static int SumEven(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                    sum += numbers[i];
            }
            return sum;
        }

        static int SumDividedBy3(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 3 == 0)
                    sum += numbers[i];
            }
            return sum;
        }

        static int Sum(int x,int y)
        {
            return x + y;
        }

        static int Calc(int x,int y,CalcNums calcNum)
        {
            return calcNum(x, y);
        }

    }
}
