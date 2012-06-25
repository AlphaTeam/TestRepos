using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Game1
{
    public partial class Form1 : Form
    {

        public static char[] m_Char = new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        public static bool fl_Ok = false;
        public static bool fl_Read = false;
        public static char WhoGo;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            frm_Game1 frm1 = new frm_Game1('X');
            frm1.Show();
            frm_Game1 frm2 = new frm_Game1('0');
            frm2.Show();
        }

    }
}
