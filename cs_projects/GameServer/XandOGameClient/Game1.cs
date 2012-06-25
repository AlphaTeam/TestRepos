using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myDll
{
    public class Game1
    {
        public static char[] m_Char = new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' };
        public static bool fl_Message = false;
        public static bool fl_Wait = false;
        public static frm_Game1 frm1;

        public static void Create_frm_Game1(char symbol)
        {
            frm1 = new frm_Game1(symbol);
            frm1.Show();
        }

        public static void GetMessage(string st)
        {
            char[] arr = st.ToCharArray();
            for (int i = 0; i < 9; i++)
            {
                m_Char[i] = arr[i];
            }
            frm1.GetMessage();
        }

        public static string SetMessage()
        {
            string st = "";
            for (int i = 0; i < 9; i++)
            {
                st += m_Char[i];
            }
            return st;
        }
    }
}
