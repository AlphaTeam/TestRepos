namespace WinFormGameClient
{
    partial class GameClientMainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonInvait = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.groupBoxGamers = new System.Windows.Forms.GroupBox();
            this.buttonCheckInvite = new System.Windows.Forms.Button();
            this.dataGridViewGamers = new System.Windows.Forms.DataGridView();
            this.ColumnGamers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxNickname = new System.Windows.Forms.TextBox();
            this.labelNickname = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.groupBoxGamers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGamers)).BeginInit();
            this.groupBoxLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonInvait
            // 
            this.buttonInvait.Location = new System.Drawing.Point(206, 19);
            this.buttonInvait.Name = "buttonInvait";
            this.buttonInvait.Size = new System.Drawing.Size(105, 48);
            this.buttonInvait.TabIndex = 1;
            this.buttonInvait.Text = "Invait to game";
            this.buttonInvait.UseVisualStyleBackColor = true;
            this.buttonInvait.Click += new System.EventHandler(this.buttonInvait_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(206, 94);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(105, 48);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(248, 255);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 37);
            this.buttonConnect.TabIndex = 3;
            this.buttonConnect.Text = "Connect to server";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // groupBoxGamers
            // 
            this.groupBoxGamers.Controls.Add(this.buttonCheckInvite);
            this.groupBoxGamers.Controls.Add(this.dataGridViewGamers);
            this.groupBoxGamers.Controls.Add(this.buttonRefresh);
            this.groupBoxGamers.Controls.Add(this.buttonInvait);
            this.groupBoxGamers.Location = new System.Drawing.Point(12, 0);
            this.groupBoxGamers.Name = "groupBoxGamers";
            this.groupBoxGamers.Size = new System.Drawing.Size(317, 248);
            this.groupBoxGamers.TabIndex = 4;
            this.groupBoxGamers.TabStop = false;
            this.groupBoxGamers.Text = "Gamers";
            // 
            // buttonCheckInvite
            // 
            this.buttonCheckInvite.Location = new System.Drawing.Point(220, 166);
            this.buttonCheckInvite.Name = "buttonCheckInvite";
            this.buttonCheckInvite.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckInvite.TabIndex = 4;
            this.buttonCheckInvite.Text = "Check invite";
            this.buttonCheckInvite.UseVisualStyleBackColor = true;
            this.buttonCheckInvite.Click += new System.EventHandler(this.buttonCheckInvite_Click);
            // 
            // dataGridViewGamers
            // 
            this.dataGridViewGamers.AllowUserToAddRows = false;
            this.dataGridViewGamers.AllowUserToDeleteRows = false;
            this.dataGridViewGamers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGamers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnGamers,
            this.ColumnStatus});
            this.dataGridViewGamers.Location = new System.Drawing.Point(11, 19);
            this.dataGridViewGamers.Name = "dataGridViewGamers";
            this.dataGridViewGamers.ReadOnly = true;
            this.dataGridViewGamers.Size = new System.Drawing.Size(183, 223);
            this.dataGridViewGamers.TabIndex = 3;
            // 
            // ColumnGamers
            // 
            this.ColumnGamers.HeaderText = "Gamers";
            this.ColumnGamers.Name = "ColumnGamers";
            this.ColumnGamers.ReadOnly = true;
            this.ColumnGamers.Width = 140;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.HeaderText = "Status";
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.ReadOnly = true;
            this.ColumnStatus.Width = 43;
            // 
            // textBoxNickname
            // 
            this.textBoxNickname.Location = new System.Drawing.Point(23, 271);
            this.textBoxNickname.MaxLength = 30;
            this.textBoxNickname.Name = "textBoxNickname";
            this.textBoxNickname.Size = new System.Drawing.Size(183, 20);
            this.textBoxNickname.TabIndex = 5;
            // 
            // labelNickname
            // 
            this.labelNickname.Location = new System.Drawing.Point(20, 251);
            this.labelNickname.Name = "labelNickname";
            this.labelNickname.Size = new System.Drawing.Size(100, 17);
            this.labelNickname.TabIndex = 6;
            this.labelNickname.Text = "Your nickname:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBoxLog
            // 
            this.groupBoxLog.Controls.Add(this.textBoxLog);
            this.groupBoxLog.Location = new System.Drawing.Point(12, 297);
            this.groupBoxLog.Name = "groupBoxLog";
            this.groupBoxLog.Size = new System.Drawing.Size(317, 128);
            this.groupBoxLog.TabIndex = 7;
            this.groupBoxLog.TabStop = false;
            this.groupBoxLog.Text = "Client log";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(11, 20);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(300, 102);
            this.textBoxLog.TabIndex = 0;
            // 
            // GameClientMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 437);
            this.Controls.Add(this.groupBoxLog);
            this.Controls.Add(this.labelNickname);
            this.Controls.Add(this.textBoxNickname);
            this.Controls.Add(this.groupBoxGamers);
            this.Controls.Add(this.buttonConnect);
            this.Name = "GameClientMainForm";
            this.Text = "Game Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameClientMainForm_FormClosing);
            this.groupBoxGamers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGamers)).EndInit();
            this.groupBoxLog.ResumeLayout(false);
            this.groupBoxLog.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonInvait;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.GroupBox groupBoxGamers;
        private System.Windows.Forms.TextBox textBoxNickname;
        private System.Windows.Forms.Label labelNickname;
        private System.Windows.Forms.DataGridView dataGridViewGamers;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGamers;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBoxLog;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonCheckInvite;
    }
}

