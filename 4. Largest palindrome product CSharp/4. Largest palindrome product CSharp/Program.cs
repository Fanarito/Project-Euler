using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _4.Largest_palindrome_product_CSharp
{
    class Program
    {
        public static List<ulong> palindromes = new List<ulong>();
        public static List<ulong> xes = new List<ulong>();
        public static List<ulong> ises = new List<ulong>();
        public static int threadsDone = 0;

        // Should work faster than reversing string and then checking
        static bool check_if_palindrome(ulong number)
        {
            string palindrome = number.ToString();
            int even = 0;

            if (palindrome.Length % 2 == 0)
            {
                even = 1;
            }

            for (int i = 0; i < palindrome.Length-even/2; i++)
            {
                if (palindrome[i] != palindrome[(palindrome.Length - 1) - i])
                {
                    return false;
                }
            }
            return true;
        }

        static void palindrome_product_between(ulong highest, ulong lowest, int threadNum)
        {
            for (ulong i = highest; i >= lowest; i--)
            {
                for (ulong x = i; x >= lowest; x--)
                {
                    ulong number = i * x;

                    if (check_if_palindrome(number))
                    {
                        palindromes.Add(number);
                        xes.Add(x);
                        ises.Add(i);
                        //Console.WriteLine(number + " " + i + " " + x);
                    }
                }
            }
            Console.WriteLine("Thread " + threadNum + " done");
            threadsDone++;
        }

        static string palindrome_product(int digits)
        {
            string largest_number_str = "";
            string smallest_number_str = "1";

            for (int i = 0; i < digits; i++)
            {
                largest_number_str += "9";

                if (smallest_number_str.Length != digits)
                {
                    smallest_number_str += "0";
                }
            }

            ulong largest_number = Convert.ToUInt64(largest_number_str);
            ulong smallest_number = Convert.ToUInt64(smallest_number_str);

            ulong divided = largest_number / 3;

            Thread one = new Thread(() => palindrome_product_between(divided, smallest_number, 1));
            Thread two = new Thread(() => palindrome_product_between(divided*2, divided, 2));
            Thread three = new Thread(() => palindrome_product_between(divided * 3, divided*2, 3));

            one.Start();
            two.Start();
            three.Start();

            while (threadsDone != 3)
            {
                Thread.Sleep(100); 
            }
            int index = palindromes.IndexOf(palindromes.Max());
            return palindromes[index] + " " + xes[index] + " " + ises[index];
        }

        static void Main(string[] args)
        {
            Console.Write("Digits: ");
            string result = palindrome_product(Convert.ToInt32(Console.ReadLine()));
            Console.Write("Largest palidrome: ");
            Console.WriteLine(result);
            //palindrome_product_between(999, 100);
            Console.ReadKey();
        }
    }
}
