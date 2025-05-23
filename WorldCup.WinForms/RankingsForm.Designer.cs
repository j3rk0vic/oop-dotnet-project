namespace WorldCup.WinForms
{
    partial class RankingsForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lstTopScorers = new ListBox();
            lstYellowCards = new ListBox();
            lstAttendance = new ListBox();
            btnExport = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(86, 9);
            label1.Name = "label1";
            label1.Size = new Size(104, 25);
            label1.TabIndex = 0;
            label1.Text = "Top Scorers";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1020, 9);
            label2.Name = "label2";
            label2.Size = new Size(203, 25);
            label2.TabIndex = 1;
            label2.Text = "Most Attended Matches";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(464, 9);
            label3.Name = "label3";
            label3.Size = new Size(157, 25);
            label3.TabIndex = 2;
            label3.Text = "Most Yellow Cards";
            // 
            // lstTopScorers
            // 
            lstTopScorers.FormattingEnabled = true;
            lstTopScorers.ItemHeight = 25;
            lstTopScorers.Location = new Point(12, 55);
            lstTopScorers.Name = "lstTopScorers";
            lstTopScorers.Size = new Size(296, 129);
            lstTopScorers.TabIndex = 3;
            // 
            // lstYellowCards
            // 
            lstYellowCards.FormattingEnabled = true;
            lstYellowCards.ItemHeight = 25;
            lstYellowCards.Location = new Point(383, 55);
            lstYellowCards.Name = "lstYellowCards";
            lstYellowCards.Size = new Size(327, 129);
            lstYellowCards.TabIndex = 4;
            // 
            // lstAttendance
            // 
            lstAttendance.FormattingEnabled = true;
            lstAttendance.ItemHeight = 25;
            lstAttendance.Location = new Point(793, 55);
            lstAttendance.Name = "lstAttendance";
            lstAttendance.Size = new Size(603, 129);
            lstAttendance.TabIndex = 5;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(548, 299);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(312, 87);
            btnExport.TabIndex = 6;
            btnExport.Text = "Export to TXT";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // RankingsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1408, 463);
            Controls.Add(btnExport);
            Controls.Add(lstAttendance);
            Controls.Add(lstYellowCards);
            Controls.Add(lstTopScorers);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RankingsForm";
            Text = "RankingsForm";
            Load += RankingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ListBox lstTopScorers;
        private ListBox lstYellowCards;
        private ListBox lstAttendance;
        private Button btnExport;
    }
}