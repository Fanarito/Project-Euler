using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace _4.Largest_palindrome_product_CSharp_Forms
{
    public partial class Form1 : Form
    {
        public static List<ulong> palindromes = new List<ulong>();
        public static List<List<ulong>> palindrome_list = new List<List<ulong>>();
        public static List<ulong> xes = new List<ulong>();
        public static List<List<ulong>> xes_list = new List<List<ulong>>();
        public static List<ulong> ises = new List<ulong>();
        public static List<List<ulong>> ises_list = new List<List<ulong>>();
        public static int threadsDone = 0;
        public static string digits_str;
        public static ulong palin_count = 0;
        public static List<ulong> palin_count_list = new List<ulong>();

        public Form1()
        {
            InitializeComponent();
        }

        static bool check_if_palindrome(ulong number)
        {
            string palindrome = number.ToString();
            int even = 0;

            if (palindrome.Length % 2 == 0)
            {
                even = 1;
            }

            for (int i = 0; i < palindrome.Length - even / 2; i++)
            {
                if (palindrome[i] != palindrome[(palindrome.Length - 1) - i])
                {
                    return false;
                }
            }
            return true;
        }

        static void palindrome_product(int digits)
        {
            
        }

        private void btn_calc_Click(object sender, EventArgs e)
        {
            // Run palindrome_product with selected digit and thread count
            if (rb_1_thread.Checked)
            {
                palindrome_calc.RunWorkerAsync(Convert.ToInt32(nud_digits.Value));
            }
            else if (rb_3_threads.Checked)
            {
                palindrome_calc_3_threads.RunWorkerAsync(Convert.ToInt32(nud_digits.Value));
            }
            else if (rb_9_threads.Checked)
            {
                palindrome_calc_9_threads.RunWorkerAsync(Convert.ToInt32(nud_digits.Value));
            }
        }

        void palindrome_product_between(ulong highest, ulong lowest, int threadNum)
        {
            txt_debug.Invoke((MethodInvoker)delegate
            {
                txt_debug.Text += "\r\nThread: " + highest + " " + lowest + " " + threadNum;
            });
            for (ulong i = highest; i >= lowest; i--)
            {
                for (ulong x = i; x >= 1; x--)
                {
                    ulong number = i * x;

                    if (check_if_palindrome(number))
                    {
                        xes_list[threadNum].Add(x);
                        ises_list[threadNum].Add(i);
                        palindrome_list[threadNum].Add(number);
                        palin_count_list[threadNum]++;
                        //string line = number + " " + i + " " + x;
                        //Console.WriteLine(line);
                    }
                }
            }
            Console.WriteLine("Thread " + threadNum + " done");
            threadsDone++;
        }

        private void palindrome_calc_DoWork(object sender, DoWorkEventArgs e)
        {
            // Reset variables for calculations
            palindromes.Clear();
            palindrome_list.Clear();
            xes.Clear();
            xes_list.Clear();
            ises.Clear();
            ises_list.Clear();
            threadsDone = 0;
            palin_count_list.Clear();
            palin_count = 0;
            txt_debug.Invoke((MethodInvoker)delegate
            {
                txt_debug.Clear();
            });

            progressBar1.Invoke((MethodInvoker)delegate
            {
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 100;
            });

            lb_current_task.Invoke((MethodInvoker)delegate
            {
                lb_current_task.Text = "Calculating Palindromes";
            });

            Stopwatch applicationTime = new Stopwatch();
            applicationTime.Start();

            // Get argument and cast to int
            int digits = (int)e.Argument;
            string digits_str = digits.ToString();

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

            for (ulong i = largest_number; i >= 1; i--)
            {
                for (ulong x = i; x >= 1; x--)
                {
                    ulong number = i * x;

                    if (check_if_palindrome(number))
                    {
                        xes.Add(x);
                        ises.Add(i);
                        palindromes.Add(number);

                        palin_count++;
                        //MessageBox.Show(palin_count.ToString());
                        //lb_palin_count.Text = "Count: " + palin_count.ToString();
                    }
                }
            }

            applicationTime.Stop();

            lb_palin_count.Invoke((MethodInvoker)delegate
            {
                lb_palin_count.Text = "Count: " + palin_count;
            });

            lb_run_time.Invoke((MethodInvoker)delegate
            {
                lb_run_time.Text = "Run Time: " + applicationTime.Elapsed;
            });

            lb_current_task.Invoke((MethodInvoker)delegate
            {
                lb_current_task.Text = "Adding to table";
            });

            Thread.Sleep(100);

            dataG_palindromes.Invoke((MethodInvoker)delegate
            {
                dataG_palindromes.Rows.Clear();
                for (int i = 0; i < palindromes.Count; i++)
                {
                    dataG_palindromes.Rows.Add(palindromes[i], ises[i], xes[i]);
                }
            });

            progressBar1.Invoke((MethodInvoker)delegate
            {
                progressBar1.Style = ProgressBarStyle.Continuous;
                progressBar1.MarqueeAnimationSpeed = 0;
                progressBar1.Value = 100;
            });

            lb_current_task.Invoke((MethodInvoker)delegate
            {
                lb_current_task.Text = "Completed";
            });
        }

        private void palindrome_calc_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void palindrome_calc_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void palindrome_calc_9_threads_DoWork(object sender, DoWorkEventArgs e)
        {
            // Reset variables for calculations
            palindromes.Clear();
            palindrome_list.Clear();
            xes.Clear();
            xes_list.Clear();
            ises.Clear();
            ises_list.Clear();
            threadsDone = 0;
            palin_count_list.Clear();
            palin_count = 0;
            txt_debug.Invoke((MethodInvoker)delegate
            {
                txt_debug.Clear();
            });

            progressBar1.Invoke((MethodInvoker)delegate
            {
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 100;
            });

            lb_current_task.Invoke((MethodInvoker)delegate
            {
                lb_current_task.Text = "Calculating Palindromes";
            });

            Stopwatch applicationTime = new Stopwatch();
            applicationTime.Start();

            // Get argument and cast to int
            int digits = (int)e.Argument;
            string digits_str = digits.ToString();

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

            // Readabillity for the win
            //threads.Add(new Thread(() => palindrome_product_between(divided * 1, 1, 0)));
            //MessageBox.Show((divided + " " + 1));

            for (int i = 0; i < 9; i++)
            {
                ises_list.Add(new List<ulong>());
                xes_list.Add(new List<ulong>());
                palindrome_list.Add(new List<ulong>());
                palin_count_list.Add(0);
            }

            Task[] tasks = new Task[9];

            tasks[0] = Task.Factory.StartNew(() => palindrome_product_between(divided * 1, 1, 0));
            tasks[1] = Task.Factory.StartNew(() => palindrome_product_between(divided * 2, divided+1, 1));
            tasks[2] = Task.Factory.StartNew(() => palindrome_product_between(divided * 3, (divided * 2) + 1, 2));
            tasks[3] = Task.Factory.StartNew(() => palindrome_product_between(divided * 4, (divided * 3) + 1, 3));
            tasks[4] = Task.Factory.StartNew(() => palindrome_product_between(divided * 5, (divided * 4) + 1, 4));
            tasks[5] = Task.Factory.StartNew(() => palindrome_product_between(divided * 6, (divided * 5) + 1, 5));
            tasks[6] = Task.Factory.StartNew(() => palindrome_product_between(divided * 7, (divided * 6) + 1, 6));
            tasks[7] = Task.Factory.StartNew(() => palindrome_product_between(divided * 8, (divided * 7) + 1, 7));
            tasks[8] = Task.Factory.StartNew(() => palindrome_product_between(divided * 9, (divided * 8) + 1, 8));

            Task.WaitAll(tasks);

            for (int i = 0; i < 9; i++)
            {
                palindromes.AddRange(palindrome_list[i]);
                xes.AddRange(xes_list[i]);
                ises.AddRange(ises_list[i]);
                palin_count += palin_count_list[i];
            }

            applicationTime.Stop();

            lb_palin_count.Invoke((MethodInvoker)delegate
            {
                lb_palin_count.Text = "Count: " + palin_count;
            });

            lb_run_time.Invoke((MethodInvoker)delegate
            {
                lb_run_time.Text = "Run Time: " + applicationTime.Elapsed;
            });

            lb_current_task.Invoke((MethodInvoker)delegate
            {
                lb_current_task.Text = "Adding to table";
            });

            Thread.Sleep(100);

            dataG_palindromes.Invoke((MethodInvoker)delegate
            {
                dataG_palindromes.Rows.Clear();
                for (int i = 0; i < palindromes.Count; i++)
                {
                    dataG_palindromes.Rows.Add(palindromes[i], ises[i], xes[i]);
                }
            });

            progressBar1.Invoke((MethodInvoker)delegate
            {
                progressBar1.Style = ProgressBarStyle.Continuous;
                progressBar1.MarqueeAnimationSpeed = 0;
                progressBar1.Value = 100;
            });

            lb_current_task.Invoke((MethodInvoker)delegate
            {
                lb_current_task.Text = "Completed";
            });
        }

        private void palindrome_calc_9_threads_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Killing it with fire
            Environment.Exit(Environment.ExitCode);
        }

        private void palindrome_calc_3_threads_DoWork(object sender, DoWorkEventArgs e)
        {
            // Reset variables for calculations
            palindromes.Clear();
            palindrome_list.Clear();
            xes.Clear();
            xes_list.Clear();
            ises.Clear();
            ises_list.Clear();
            threadsDone = 0;
            palin_count_list.Clear();
            palin_count = 0;
            txt_debug.Invoke((MethodInvoker)delegate
            {
                txt_debug.Clear();
            });

            progressBar1.Invoke((MethodInvoker)delegate
            {
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 100;
            });

            lb_current_task.Invoke((MethodInvoker)delegate
            {
                lb_current_task.Text = "Calculating Palindromes";
            });

            Stopwatch applicationTime = new Stopwatch();
            applicationTime.Start();

            // Get argument and cast to int
            int digits = (int)e.Argument;
            string digits_str = digits.ToString();

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

            // Readabillity for the win
            //threads.Add(new Thread(() => palindrome_product_between(divided * 1, 1, 0)));
            //MessageBox.Show((divided + " " + 1));

            for (int i = 0; i < 3; i++)
            {
                ises_list.Add(new List<ulong>());
                xes_list.Add(new List<ulong>());
                palindrome_list.Add(new List<ulong>());
                palin_count_list.Add(0);
            }

            Task[] tasks = new Task[3];

            tasks[0] = Task.Factory.StartNew(() => palindrome_product_between(divided * 1, 1, 0));
            tasks[1] = Task.Factory.StartNew(() => palindrome_product_between(divided * 2, divided + 1, 1));
            tasks[2] = Task.Factory.StartNew(() => palindrome_product_between(divided * 3, (divided * 2) + 1, 2));

            Task.WaitAll(tasks);

            for (int i = 0; i < 3; i++)
            {
                palindromes.AddRange(palindrome_list[i]);
                xes.AddRange(xes_list[i]);
                ises.AddRange(ises_list[i]);
                palin_count += palin_count_list[i];
            }

            applicationTime.Stop();

            lb_palin_count.Invoke((MethodInvoker)delegate
            {
                lb_palin_count.Text = "Count: " + palin_count;
            });

            lb_run_time.Invoke((MethodInvoker)delegate
            {
                lb_run_time.Text = "Run Time: " + applicationTime.Elapsed;
            });

            lb_current_task.Invoke((MethodInvoker)delegate
            {
                lb_current_task.Text = "Adding to table";
            });

            Thread.Sleep(100);

            dataG_palindromes.Invoke((MethodInvoker)delegate
            {
                dataG_palindromes.Rows.Clear();
                for (int i = 0; i < palindromes.Count; i++)
                {
                    dataG_palindromes.Rows.Add(palindromes[i], ises[i], xes[i]);
                }
            });

            progressBar1.Invoke((MethodInvoker)delegate
            {
                progressBar1.Style = ProgressBarStyle.Continuous;
                progressBar1.MarqueeAnimationSpeed = 0;
                progressBar1.Value = 100;
            });

            lb_current_task.Invoke((MethodInvoker)delegate
            {
                lb_current_task.Text = "Completed";
            });
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            txt_debug.Invoke((MethodInvoker)delegate
            {
                txt_debug.Clear();
            });

            progressBar1.Invoke((MethodInvoker)delegate
            {
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 100;
            });

            lb_current_task.Invoke((MethodInvoker)delegate
            {
                lb_current_task.Text = "Saving to file";
            });

            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "palindromes.txt";
            save.Filter = "Text File | *.txt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.OpenFile());
                for (int i = 0; i < palindromes.Count; i++)
                {
                    writer.WriteLine(palindromes[i] + " " + ises[i] + " " + xes[i]);
                }
                writer.Dispose();
                writer.Close();
            }

            progressBar1.Invoke((MethodInvoker)delegate
            {
                progressBar1.Style = ProgressBarStyle.Continuous;
                progressBar1.MarqueeAnimationSpeed = 0;
                progressBar1.Value = 100;
            });

            lb_current_task.Invoke((MethodInvoker)delegate
            {
                lb_current_task.Text = "Completed";
            });
        }
    }
}
