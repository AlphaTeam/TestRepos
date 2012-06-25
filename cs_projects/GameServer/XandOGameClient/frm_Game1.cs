using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace myDll
{
    public partial class frm_Game1 : Form
    {
        public static char Symbol;
        public static char NotMySymbol;

        public frm_Game1(char symbol)
        {
            InitializeComponent();
            Symbol = symbol;
            NotMySymbol = (Symbol == 'X') ? '0' : 'X';
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Game1_Load(object sender, EventArgs e)
        {
            this.Text = Symbol.ToString();
            Init();
        }

        private void Init()
        {
            for (int i = 0; i < 9; i++)
            {
                Game1.m_Char[i] = '.';
            }
            foreach (Control control in this.panel1.Controls)
            {
                control.Enabled = (Symbol == 'X');
            }
            Result.Text = (Symbol == 'X') ? "your turn..." : "wait...";
            Game1.fl_Message = false;
            Game1.fl_Wait = (Symbol == '0');
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            (sender as Button).Text = Symbol.ToString();
            Game1.m_Char[(sender as Button).TabIndex] = Symbol;
            foreach (Control control in this.panel1.Controls)
            {
                control.Enabled = false;
            }
            if (Test_Ok(Symbol))
            {
                this.panel1.Enabled = false;
                Result.Text = "You have won!!!";
                btnExit.Visible = true;
            }
            else
            {
                Result.Text = "wait...";
            }
            Game1.fl_Message = true;
        }

        public void GetMessage()
        {
            foreach (Control control in this.panel1.Controls)
            {
                int k = control.TabIndex;
                string st = Game1.m_Char[k].ToString();
                control.Text = st;
                control.Enabled = (st == ".");
            }
            if (Test_Ok(NotMySymbol))
            {
                this.panel1.Enabled = false;
                Result.Text = "You lose...";
                btnExit.Visible = true;
            }
            else
            {
                Result.Text = "your turn...";
            }
        }

        private bool Test_Ok(char ch)
        {
            bool fl_Ok = false;
            int[,] mOk = new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
            for (int i = 0; i < 8; i++)
            {
                if ((Game1.m_Char[mOk[i, 0]] == ch) && (Game1.m_Char[mOk[i, 1]] == ch) && (Game1.m_Char[mOk[i, 2]] == ch)) fl_Ok = true;
            }
            return fl_Ok;
        }
    }
}
