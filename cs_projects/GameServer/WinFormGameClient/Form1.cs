using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormGameClient
{
    public partial class GameClientMainForm : Form
    {
        private SocketClient client = new SocketClient();

        public GameClientMainForm()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (this.textBoxNickname.Text != string.Empty)
            {
                this.client.SendCredentials(textBoxNickname.Text);
                string[] gamersList = this.client.GetGamersList();
                //.textBoxLog.Text = this.client.ClientStreamStr + "\n";
                foreach (string gamer in gamersList)
                {
                    string[] tmp = new string[2];
                    tmp = gamer.Split(new string[] { "::" }, System.StringSplitOptions.RemoveEmptyEntries);
                    this.dataGridViewGamers.Rows.Add();
                    this.dataGridViewGamers.Rows[this.dataGridViewGamers.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[0].Value = tmp[0];
                    this.dataGridViewGamers.Rows[this.dataGridViewGamers.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[1].Value = tmp[1];
                }
            }
            else
            {
                MessageBox.Show("Please enter your nickname");
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            this.dataGridViewGamers.Rows.Clear();
            client.Refresh();
            string[] gamersList = this.client.GetGamersList();
            //this.textBoxLog.Text = this.client.ClientStreamStr + "\n";
            foreach (string gamer in gamersList)
            {
                string[] tmp = new string[2];
                tmp = gamer.Split(new string[] { "::" }, System.StringSplitOptions.RemoveEmptyEntries);
                this.dataGridViewGamers.Rows.Add();
                this.dataGridViewGamers.Rows[this.dataGridViewGamers.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[0].Value = tmp[0];
                this.dataGridViewGamers.Rows[this.dataGridViewGamers.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[1].Value = tmp[1];
            }
        }

        private void buttonInvait_Click(object sender, EventArgs e)
        {
            try
            {
                int count = this.dataGridViewGamers.SelectedRows.Count;
                string free = this.dataGridViewGamers.Rows[this.dataGridViewGamers.Rows.GetLastRow(DataGridViewElementStates.Selected)].Cells[1].Value.ToString();
                if (count > 0 && free.Equals("Free"))
                {
                    this.client.SendInviteTo(this.dataGridViewGamers.Rows[this.dataGridViewGamers.Rows.GetLastRow(DataGridViewElementStates.Selected)].Cells[0].Value.ToString(),
                                            this.textBoxNickname.Text);
                    //this.textBoxLog.Text = this.client.ClientStreamStr + "\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.TargetSite + "  " + ex.Source, ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("Timer is working!");
            //if (client.CheckInvite())
            //{
            //    MessageBox.Show("Player " + this.client.Partner + " invited you for game\n\n Are you agree to play?",
            //                    "Attention!!!", MessageBoxButtons.YesNo);
            //}
        }

        private void buttonCheckInvite_Click(object sender, EventArgs e)
        {
            if (client.CheckInvite())
               // MessageBox.Show("Test");
            {
                MessageBox.Show("Player " + this.client.Partner + " invited you for game\n\n Are you agree to play?",
                                "Attention!!!", MessageBoxButtons.YesNo);
            }
        }

        private void GameClientMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.client.DoDisconnect(this.textBoxNickname.Text);
        }
    }
}
