using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace _4.Largest_palindrome_product_CSharp
{
    class Program
    {
        public static List<ulong> palindromes = new List<ulong>();
        public static List<List<ulong>> palindrome_list = new List<List<ulong>>();
        public static List<ulong> xes = new List<ulong>();
        public static List<List<ulong>> xes_list = new List<List<ulong>>();
        public static List<ulong> ises = new List<ulong>();
        public static List<List<ulong>> ises_list = new List<List<ulong>>();
        public static int threadsDone = 0;
        public static string digits_str;

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
                        xes_list[threadNum].Add(x);
                        ises_list[threadNum].Add(i);
                        palindrome_list[threadNum].Add(number);
                        //string line = number + " " + i + " " + x;
                        //Console.WriteLine(line);
                    }
                }
            }
            Console.WriteLine("Thread " + threadNum + " done");
            threadsDone++;
        }

        static string palindrome_product(int digits)
        {
            digits_str = digits.ToString();

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

            ulong divided = largest_number / 9;

            /*List<Thread> threads = new List<Thread>();

            // Readabillity for the win
            threads.Add(new Thread(() => palindrome_product_between(divided * 1, 1, 0)));
            threads.Add(new Thread(() => palindrome_product_between(divided * 2, divided, 1)));
            threads.Add(new Thread(() => palindrome_product_between(divided * 3, divided * 2, 2)));
            threads.Add(new Thread(() => palindrome_product_between(divided * 4, divided * 3, 3)));
            threads.Add(new Thread(() => palindrome_product_between(divided * 5, divided * 4, 4)));
            threads.Add(new Thread(() => palindrome_product_between(divided * 6, divided * 5, 5)));
            threads.Add(new Thread(() => palindrome_product_between(divided * 7, divided * 6, 6)));
            threads.Add(new Thread(() => palindrome_product_between(divided * 8, divided * 7, 7)));
            threads.Add(new Thread(() => palindrome_product_between(divided * 9, divided * 8, 8)));

            foreach (Thread thread in threads)
            {
                ises_list.Add(new List<ulong>());
                xes_list.Add(new List<ulong>());
                palindrome_list.Add(new List<ulong>());
                thread.Start();
            }*/

            for (int i = 0; i < 9; i++)
            {
                ises_list.Add(new List<ulong>());
                xes_list.Add(new List<ulong>());
                palindrome_list.Add(new List<ulong>());
            }

            Task[] tasks = new Task[9];

            tasks[0] = Task.Factory.StartNew(() => palindrome_product_between(divided * 1, 1, 0));
            tasks[1] = Task.Factory.StartNew(() => palindrome_product_between(divided * 2, divided, 1));
            tasks[2] = Task.Factory.StartNew(() => palindrome_product_between(divided * 3, divided * 2, 2));
            tasks[3] = Task.Factory.StartNew(() => palindrome_product_between(divided * 4, divided * 3, 3));
            tasks[4] = Task.Factory.StartNew(() => palindrome_product_between(divided * 5, divided * 4, 4));
            tasks[5] = Task.Factory.StartNew(() => palindrome_product_between(divided * 6, divided * 5, 5));
            tasks[6] = Task.Factory.StartNew(() => palindrome_product_between(divided * 7, divided * 6, 6));
            tasks[7] = Task.Factory.StartNew(() => palindrome_product_between(divided * 8, divided * 7, 7));
            tasks[8] = Task.Factory.StartNew(() => palindrome_product_between(divided * 9, divided * 8, 8));

            Console.WriteLine("All threads started");

            Task.WaitAll(tasks);

            for (int i = 0; i < 9; i++)
            {
                //palindrome_list[i].ForEach(e => palindromes.Add(e));
                palindromes.AddRange(palindrome_list[i]);
                //xes_list[i].ForEach(e => xes.Add(e));
                xes.AddRange(xes_list[i]);
                //ises_list[i].ForEach(e => ises.Add(e));
                ises.AddRange(ises_list[i]);
            }
            Console.WriteLine(palindromes.Count);
            int index = palindromes.IndexOf(palindromes.Max());
            return palindromes[index] + " " + xes[index] + " " + ises[index];
        }

        static void Main(string[] args)
        {
            Console.Write("Digits: ");
            Stopwatch applicationTime = new Stopwatch();
            applicationTime.Start();
            string result = palindrome_product(Convert.ToInt32(Console.ReadLine()));
            applicationTime.Stop();
            Console.WriteLine("Application run time: " + applicationTime.Elapsed);
            
            Console.Write("Largest palidrome: ");
            Console.WriteLine(result);
            Console.WriteLine("Writing results to file");
            Console.WriteLine(palindromes.Count + " " + ises.Count + " " + xes.Count);

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("1 to " + digits_str + " digit palindromes.txt", true))
            {
                for (int i = 0; i < palindromes.Count; i++)
                {
                    string line = palindromes[i] + " " + ises[i] + " " + xes[i];
                    file.WriteLine(line);
                }
            }
            Console.WriteLine("Done writing results to file");
            //palindrome_product_between(999, 100);
            Console.ReadLine();
        }
    }
}
