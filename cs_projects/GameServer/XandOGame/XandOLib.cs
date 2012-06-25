using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XandOGame
{
    class XandOLib:IGameLib
    {
        private char[] turns = new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' };
        int[,] mOk = new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
        private string message = string.Empty;

        public const string nameOfGame = "X and O";
        
        public void SetMessage(string st)
        {
            char[] arr = st.ToCharArray();
            this.turns[Convert.ToInt32(arr[1])] = arr[0];
            this.message = arr[1] + "::" + this.Test_Ok(arr[0]).ToString();
        }

        public string GetMessage()
        {
            return this.message;
        }

        private bool Test_Ok(char ch)
        {
            bool fl_Ok = false;
            
            for (int i = 0; i < 8; i++)
            {
                if ((this.turns[mOk[i, 0]] == ch) && 
                    (this.turns[mOk[i, 1]] == ch) && 
                    (this.turns[mOk[i, 2]] == ch)) 
                {
                    fl_Ok = true;
                }
            }

            return fl_Ok;
        }
    }

}
