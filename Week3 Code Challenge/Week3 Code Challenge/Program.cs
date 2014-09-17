using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_Code_Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            Console.WriteLine("Enter a number to find prime numebrs until that number");
            num = int.Parse(Console.ReadLine());
            // MaxPrime(num);

            //calling fibonacci function
            //EvenFibonacciSequencer(90);

            //calling Longest Collatz function
            LongestCollatz();
        }
            
        //Find Nth prime number
        public static void MaxPrime(int number)
        {
            int num = number;
            List<int> primeNumbers = new List<int>();
            primeNumbers.Add(2);

            int count = 1; //started at one, because 2 is a prime numebr
            int i = 3;

            if (num == 1)
            {
                Console.WriteLine("The first prime number is 2");
            }
            else
            {
                while (count < num)
                {

                    if (IsPrime(i))
                    {
                        primeNumbers.Add(i);
                        count++;
                    }
                    i++;
                }

                Console.WriteLine("The " + num + "th Prime number is " + primeNumbers.Last());
                Console.WriteLine("\nThose are");
                foreach (var item in primeNumbers)
                {
                    Console.Write(item + " ");
                }
            }
        }

        //function to find, if a number is a prime number or not
        static bool IsPrime(int num)
        {
            //declaring a variable to keep track of the number of factor for the given number

            double doubleOfNum = double.Parse(num.ToString());
            double sqrtOfNum = Math.Round(Math.Sqrt(doubleOfNum));
            int count = 0; //variable to keep track of number of factors

            if ((num % 2) == 0)
            {
                return false;
            }
            else
            {
                //to save processing time we can break the loop once you find one factor (i.e if you are checking from 2)
                for (int i = 2; i <= sqrtOfNum; i++)
                {
                    if ((num % i) == 0)
                    {
                        count++;
                        return false; 
                    }                 
                }
                //if the number has only 2 factors, then it's a prime number. 
                //But since we are checking until the square root only, it will have only one factor.
                return true;
            }

            
        }

        //Find Fibonacci Sequence until the MaxValue. Then find the sum of all even numbers
        public static void EvenFibonacciSequencer(int maxValue)
        {
            //list to hold the fibonacci sequence
            List<int> fibonacci = new List<int>();
            fibonacci.Add(1);
            fibonacci.Add(2);
            int sum = 0, temp = 1, evenTotal = 0;

            //while loop to generate Fibonacci sequence until max value
            while (sum < maxValue)
            {
                sum = fibonacci.Last() + temp;
                temp = fibonacci.Last();
                fibonacci.Add(sum);
            }

            //now that we have our fibonacci sequence. 
            //we need to calculate the sum of even numbers
            foreach (var item in fibonacci)
            {
                if (item % 2 == 0)
                {
                    evenTotal += item;
                }
            }

            //print the output
            Console.WriteLine("\n\nThe sum of all even numbers in Fibonacci sequence is: " + evenTotal);

            Console.WriteLine("The Fibonacci sequence is");
            foreach (var item in fibonacci)
            {
                Console.Write(item + " ");
            }
        }

        //function to find longest collatz sequence below one million
        public static void LongestCollatz()
        {
            long num, start = 1;
            int length = 0, longest = 0;

            //for loop to find the sequence for each number between 1 and 1000000
            for (long i = 1; i <= 1000000; i++)
            {
                num = i; //starting point
                length = 1; //put one so that it will count the num also
                while (num > 1)
                {
                    if (num % 2 == 0)
                        num = num / 2;
                    else
                        num = (3 * num) + 1;
                    length++;
                }
                //now we have lenght of a sequence
                //need to compare that with the previous longest.
                if (length > longest)
                {
                    longest = length;
                    start = i;
                }
            }

            //print the output
            Console.WriteLine("\n\nThe number that produced longest Collatz sequence is: " + start);
            Console.WriteLine("\nIt produced a sequence of " + longest + " numbers");

        }
    }
}
