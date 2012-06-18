using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Game1
{
    public partial class frm_Game1 : Form
    {
        public char Symbol;
        private delegate void CodeBlock();
        
        public frm_Game1(char symbol)
        {
            InitializeComponent();
            Symbol = symbol;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Game1_Load(object sender, EventArgs e)
        {
            //this.timer1.Enabled = true;
            Thread th = new Thread(new ThreadStart(StartTimer));
            th.Start();   
            this.Text = Symbol.ToString();
            Init();
        }

        private void StartTimer()
        {
            this.timer1.Enabled = true;
            //Invoke((CodeBlock)delegate
            //{
            //    this.label1.Text = DateTime.Now.ToString("HH:mm:ss");
            //    Refresh();
            //    Application.DoEvents();
            //});
        }

        private void Init()
        {
            Form1.fl_Ok = false;
            for (int i = 0; i < 9; i++)
            {
                Form1.m_Char[i] = ' ';
            }
            foreach (Control control in this.panel1.Controls)
            {
                int k = control.TabIndex;
                string st = Form1.m_Char[k].ToString();
                control.Text = st;
                control.Enabled = (st == " ");
            }
            btnRead.Enabled = true;
            Result.Visible = false;
            btnStart.Visible = false;
            btnExit.Visible = false;
            Form1.WhoGo = '0';
            Form1.fl_Read = false;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if ((Form1.WhoGo != Symbol)&&(Form1.fl_Read))
            {
                (sender as Button).Text = Symbol.ToString();
                Form1.m_Char[(sender as Button).TabIndex] = Symbol;
                foreach (Control control in this.panel1.Controls)
                {
                    if (control is Button)
                    {
                        int k = control.TabIndex;
                        if (k < 9)
                        {
                            control.Enabled = false;
                        }
                    }
                }
                Form1.WhoGo = Symbol;
                Form1.fl_Read = false;
                int[,] mOk = new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
                for (int i = 0; i < 8; i++)
                {
                    if ((Form1.m_Char[mOk[i, 0]] == Symbol) && (Form1.m_Char[mOk[i, 1]] == Symbol) && (Form1.m_Char[mOk[i, 2]] == Symbol)) Form1.fl_Ok = true;
                }
                if (Form1.fl_Ok == true)
                {
                    btnRead.Enabled = false;
                    Result.Visible = true;
                    Result.Text = "You have won!!!";
                    btnStart.Visible = true;
                    btnExit.Visible = true;
                }
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //foreach (Control control in this.panel1.Controls)
            //{
            //    if (control is Button)
            //    {
            //        int k = control.TabIndex;
            //        if (k<9)
            //        {
            //            string st = Form1.m_Char[k].ToString();
            //            control.Text = st;
            //            control.Enabled = (st == " ");
            //        }
            //    }
            //}
            foreach (Control control in this.panel1.Controls)
            {
                int k = control.TabIndex;
                string st = Form1.m_Char[k].ToString();
                control.Text = st;
                control.Enabled = (st == " ");
            }
            Form1.fl_Read = true;
            if (Form1.fl_Ok == true)
            {
                btnRead.Enabled = false;
                Result.Visible = true;
                Result.Text = "You lose...";
                btnStart.Visible = true;
                btnExit.Visible = true;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToString("HH:mm:ss");
            if ((Form1.WhoGo != Symbol) && (Form1.fl_Read == false))
            {
                btnRead.PerformClick();
            }
        }
    }
}
