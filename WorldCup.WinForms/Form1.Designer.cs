namespace WorldCup.WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSaveSettings = new Button();
            grpLanguage = new GroupBox();
            rbEnglish = new RadioButton();
            rbCroatian = new RadioButton();
            grpChampionship = new GroupBox();
            rbWomen = new RadioButton();
            rbMen = new RadioButton();
            label1 = new Label();
            grpLanguage.SuspendLayout();
            grpChampionship.SuspendLayout();
            SuspendLayout();
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(562, 438);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(182, 48);
            btnSaveSettings.TabIndex = 11;
            btnSaveSettings.Text = "Save Settings";
            btnSaveSettings.UseVisualStyleBackColor = true;
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // grpLanguage
            // 
            grpLanguage.Controls.Add(rbEnglish);
            grpLanguage.Controls.Add(rbCroatian);
            grpLanguage.Location = new Point(685, 209);
            grpLanguage.Name = "grpLanguage";
            grpLanguage.Size = new Size(302, 167);
            grpLanguage.TabIndex = 10;
            grpLanguage.TabStop = false;
            grpLanguage.Text = "Language";
            // 
            // rbEnglish
            // 
            rbEnglish.AutoSize = true;
            rbEnglish.Location = new Point(6, 103);
            rbEnglish.Name = "rbEnglish";
            rbEnglish.Size = new Size(93, 29);
            rbEnglish.TabIndex = 1;
            rbEnglish.Text = "English";
            rbEnglish.UseVisualStyleBackColor = true;
            // 
            // rbCroatian
            // 
            rbCroatian.AutoSize = true;
            rbCroatian.Checked = true;
            rbCroatian.Location = new Point(6, 52);
            rbCroatian.Name = "rbCroatian";
            rbCroatian.Size = new Size(103, 29);
            rbCroatian.TabIndex = 0;
            rbCroatian.TabStop = true;
            rbCroatian.Text = "Croatian";
            rbCroatian.UseVisualStyleBackColor = true;
            // 
            // grpChampionship
            // 
            grpChampionship.Controls.Add(rbWomen);
            grpChampionship.Controls.Add(rbMen);
            grpChampionship.Location = new Point(319, 209);
            grpChampionship.Name = "grpChampionship";
            grpChampionship.Size = new Size(302, 167);
            grpChampionship.TabIndex = 9;
            grpChampionship.TabStop = false;
            grpChampionship.Text = "Championship";
            // 
            // rbWomen
            // 
            rbWomen.AutoSize = true;
            rbWomen.Location = new Point(6, 103);
            rbWomen.Name = "rbWomen";
            rbWomen.Size = new Size(99, 29);
            rbWomen.TabIndex = 1;
            rbWomen.Text = "Women";
            rbWomen.UseVisualStyleBackColor = true;
            // 
            // rbMen
            // 
            rbMen.AutoSize = true;
            rbMen.Checked = true;
            rbMen.Location = new Point(6, 52);
            rbMen.Name = "rbMen";
            rbMen.Size = new Size(72, 29);
            rbMen.TabIndex = 0;
            rbMen.TabStop = true;
            rbMen.Text = "Men";
            rbMen.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(509, 30);
            label1.Name = "label1";
            label1.Size = new Size(288, 25);
            label1.TabIndex = 8;
            label1.Text = "Select championship and language";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1307, 739);
            Controls.Add(btnSaveSettings);
            Controls.Add(grpLanguage);
            Controls.Add(grpChampionship);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            grpLanguage.ResumeLayout(false);
            grpLanguage.PerformLayout();
            grpChampionship.ResumeLayout(false);
            grpChampionship.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSaveSettings;
        private GroupBox grpLanguage;
        private RadioButton rbEnglish;
        private RadioButton rbCroatian;
        private GroupBox grpChampionship;
        private RadioButton rbWomen;
        private RadioButton rbMen;
        private Label label1;
    }
}
