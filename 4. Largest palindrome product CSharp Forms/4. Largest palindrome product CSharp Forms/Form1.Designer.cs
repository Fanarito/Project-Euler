namespace _4.Largest_palindrome_product_CSharp_Forms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataG_palindromes = new System.Windows.Forms.DataGridView();
            this.c_palindrome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_i = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lb_digits = new System.Windows.Forms.Label();
            this.nud_digits = new System.Windows.Forms.NumericUpDown();
            this.lb_run_time = new System.Windows.Forms.Label();
            this.lb_palin_count = new System.Windows.Forms.Label();
            this.btn_calc = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.palindrome_calc = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lb_current_task = new System.Windows.Forms.Label();
            this.rb_1_thread = new System.Windows.Forms.RadioButton();
            this.rb_9_threads = new System.Windows.Forms.RadioButton();
            this.rb_3_threads = new System.Windows.Forms.RadioButton();
            this.palindrome_calc_9_threads = new System.ComponentModel.BackgroundWorker();
            this.txt_debug = new System.Windows.Forms.TextBox();
            this.palindrome_calc_3_threads = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataG_palindromes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_digits)).BeginInit();
            this.SuspendLayout();
            // 
            // dataG_palindromes
            // 
            this.dataG_palindromes.AllowUserToAddRows = false;
            this.dataG_palindromes.AllowUserToDeleteRows = false;
            this.dataG_palindromes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataG_palindromes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_palindrome,
            this.c_i,
            this.c_x});
            this.dataG_palindromes.Location = new System.Drawing.Point(13, 13);
            this.dataG_palindromes.Name = "dataG_palindromes";
            this.dataG_palindromes.Size = new System.Drawing.Size(643, 530);
            this.dataG_palindromes.TabIndex = 0;
            // 
            // c_palindrome
            // 
            this.c_palindrome.HeaderText = "Palindrome products";
            this.c_palindrome.Name = "c_palindrome";
            this.c_palindrome.ReadOnly = true;
            this.c_palindrome.Width = 200;
            // 
            // c_i
            // 
            this.c_i.HeaderText = "I";
            this.c_i.Name = "c_i";
            this.c_i.ReadOnly = true;
            this.c_i.Width = 200;
            // 
            // c_x
            // 
            this.c_x.HeaderText = "X";
            this.c_x.Name = "c_x";
            this.c_x.ReadOnly = true;
            this.c_x.Width = 200;
            // 
            // lb_digits
            // 
            this.lb_digits.AutoSize = true;
            this.lb_digits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_digits.Location = new System.Drawing.Point(663, 13);
            this.lb_digits.Name = "lb_digits";
            this.lb_digits.Size = new System.Drawing.Size(53, 20);
            this.lb_digits.TabIndex = 1;
            this.lb_digits.Text = "Digits:";
            // 
            // nud_digits
            // 
            this.nud_digits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_digits.Location = new System.Drawing.Point(722, 11);
            this.nud_digits.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_digits.Name = "nud_digits";
            this.nud_digits.Size = new System.Drawing.Size(67, 26);
            this.nud_digits.TabIndex = 2;
            this.nud_digits.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lb_run_time
            // 
            this.lb_run_time.AutoSize = true;
            this.lb_run_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_run_time.Location = new System.Drawing.Point(663, 157);
            this.lb_run_time.Name = "lb_run_time";
            this.lb_run_time.Size = new System.Drawing.Size(94, 20);
            this.lb_run_time.TabIndex = 3;
            this.lb_run_time.Text = "Run Time: 0";
            // 
            // lb_palin_count
            // 
            this.lb_palin_count.AutoSize = true;
            this.lb_palin_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_palin_count.Location = new System.Drawing.Point(663, 187);
            this.lb_palin_count.Name = "lb_palin_count";
            this.lb_palin_count.Size = new System.Drawing.Size(69, 20);
            this.lb_palin_count.TabIndex = 4;
            this.lb_palin_count.Text = "Count: 0";
            // 
            // btn_calc
            // 
            this.btn_calc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_calc.Location = new System.Drawing.Point(667, 79);
            this.btn_calc.Name = "btn_calc";
            this.btn_calc.Size = new System.Drawing.Size(239, 62);
            this.btn_calc.TabIndex = 5;
            this.btn_calc.Text = "Calculate";
            this.btn_calc.UseVisualStyleBackColor = true;
            this.btn_calc.Click += new System.EventHandler(this.btn_calc_Click);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(667, 481);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(239, 62);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Save List";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // palindrome_calc
            // 
            this.palindrome_calc.DoWork += new System.ComponentModel.DoWorkEventHandler(this.palindrome_calc_DoWork);
            this.palindrome_calc.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.palindrome_calc_ProgressChanged);
            this.palindrome_calc.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.palindrome_calc_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 549);
            this.progressBar1.MarqueeAnimationSpeed = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(893, 37);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 7;
            // 
            // lb_current_task
            // 
            this.lb_current_task.AutoSize = true;
            this.lb_current_task.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_current_task.Location = new System.Drawing.Point(13, 593);
            this.lb_current_task.Name = "lb_current_task";
            this.lb_current_task.Size = new System.Drawing.Size(0, 20);
            this.lb_current_task.TabIndex = 8;
            // 
            // rb_1_thread
            // 
            this.rb_1_thread.AutoSize = true;
            this.rb_1_thread.Checked = true;
            this.rb_1_thread.Location = new System.Drawing.Point(667, 48);
            this.rb_1_thread.Name = "rb_1_thread";
            this.rb_1_thread.Size = new System.Drawing.Size(68, 17);
            this.rb_1_thread.TabIndex = 9;
            this.rb_1_thread.TabStop = true;
            this.rb_1_thread.Text = "1 Thread";
            this.rb_1_thread.UseVisualStyleBackColor = true;
            // 
            // rb_9_threads
            // 
            this.rb_9_threads.AutoSize = true;
            this.rb_9_threads.Location = new System.Drawing.Point(820, 48);
            this.rb_9_threads.Name = "rb_9_threads";
            this.rb_9_threads.Size = new System.Drawing.Size(73, 17);
            this.rb_9_threads.TabIndex = 10;
            this.rb_9_threads.Text = "9 Threads";
            this.rb_9_threads.UseVisualStyleBackColor = true;
            // 
            // rb_3_threads
            // 
            this.rb_3_threads.AutoSize = true;
            this.rb_3_threads.Location = new System.Drawing.Point(741, 48);
            this.rb_3_threads.Name = "rb_3_threads";
            this.rb_3_threads.Size = new System.Drawing.Size(73, 17);
            this.rb_3_threads.TabIndex = 11;
            this.rb_3_threads.Text = "3 Threads";
            this.rb_3_threads.UseVisualStyleBackColor = true;
            // 
            // palindrome_calc_9_threads
            // 
            this.palindrome_calc_9_threads.DoWork += new System.ComponentModel.DoWorkEventHandler(this.palindrome_calc_9_threads_DoWork);
            this.palindrome_calc_9_threads.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.palindrome_calc_9_threads_RunWorkerCompleted);
            // 
            // txt_debug
            // 
            this.txt_debug.Location = new System.Drawing.Point(667, 211);
            this.txt_debug.Multiline = true;
            this.txt_debug.Name = "txt_debug";
            this.txt_debug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_debug.Size = new System.Drawing.Size(239, 264);
            this.txt_debug.TabIndex = 12;
            // 
            // palindrome_calc_3_threads
            // 
            this.palindrome_calc_3_threads.DoWork += new System.ComponentModel.DoWorkEventHandler(this.palindrome_calc_3_threads_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 618);
            this.Controls.Add(this.txt_debug);
            this.Controls.Add(this.rb_3_threads);
            this.Controls.Add(this.rb_9_threads);
            this.Controls.Add(this.rb_1_thread);
            this.Controls.Add(this.lb_current_task);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_calc);
            this.Controls.Add(this.lb_palin_count);
            this.Controls.Add(this.lb_run_time);
            this.Controls.Add(this.nud_digits);
            this.Controls.Add(this.lb_digits);
            this.Controls.Add(this.dataG_palindromes);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataG_palindromes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_digits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataG_palindromes;
        private System.Windows.Forms.Label lb_digits;
        private System.Windows.Forms.NumericUpDown nud_digits;
        private System.Windows.Forms.Label lb_run_time;
        private System.Windows.Forms.Label lb_palin_count;
        private System.Windows.Forms.Button btn_calc;
        private System.Windows.Forms.Button btn_save;
        private System.ComponentModel.BackgroundWorker palindrome_calc;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lb_current_task;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_palindrome;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_i;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_x;
        private System.Windows.Forms.RadioButton rb_1_thread;
        private System.Windows.Forms.RadioButton rb_9_threads;
        private System.Windows.Forms.RadioButton rb_3_threads;
        private System.ComponentModel.BackgroundWorker palindrome_calc_9_threads;
        private System.Windows.Forms.TextBox txt_debug;
        private System.ComponentModel.BackgroundWorker palindrome_calc_3_threads;
    }
}

