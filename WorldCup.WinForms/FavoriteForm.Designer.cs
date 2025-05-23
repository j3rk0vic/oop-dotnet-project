namespace WorldCup.WinForms
{
    partial class FavoriteForm
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
            lbFavoriteTeam = new Label();
            lbSelectTeam = new Label();
            cmbFavorites = new ComboBox();
            btnSaveFavorite = new Button();
            btnContinue = new Button();
            SuspendLayout();
            // 
            // lbFavoriteTeam
            // 
            lbFavoriteTeam.AutoSize = true;
            lbFavoriteTeam.Location = new Point(12, 9);
            lbFavoriteTeam.Name = "lbFavoriteTeam";
            lbFavoriteTeam.Size = new Size(120, 25);
            lbFavoriteTeam.TabIndex = 0;
            lbFavoriteTeam.Text = "Favorite Team";
            // 
            // lbSelectTeam
            // 
            lbSelectTeam.AutoSize = true;
            lbSelectTeam.Location = new Point(12, 127);
            lbSelectTeam.Name = "lbSelectTeam";
            lbSelectTeam.Size = new Size(213, 25);
            lbSelectTeam.TabIndex = 1;
            lbSelectTeam.Text = "Select your favorite team:";
            // 
            // cmbFavorites
            // 
            cmbFavorites.FormattingEnabled = true;
            cmbFavorites.Location = new Point(12, 179);
            cmbFavorites.Name = "cmbFavorites";
            cmbFavorites.Size = new Size(182, 33);
            cmbFavorites.TabIndex = 2;
            // 
            // btnSaveFavorite
            // 
            btnSaveFavorite.Location = new Point(282, 251);
            btnSaveFavorite.Name = "btnSaveFavorite";
            btnSaveFavorite.Size = new Size(187, 43);
            btnSaveFavorite.TabIndex = 3;
            btnSaveFavorite.Text = "Save Favorite";
            btnSaveFavorite.UseVisualStyleBackColor = true;
            btnSaveFavorite.Click += btnSaveFavorite_Click;
            // 
            // btnContinue
            // 
            btnContinue.Location = new Point(282, 328);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(187, 43);
            btnContinue.TabIndex = 4;
            btnContinue.Text = "Continue";
            btnContinue.UseVisualStyleBackColor = true;
            btnContinue.Click += btnContinue_Click;
            // 
            // FavoriteForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 409);
            Controls.Add(btnContinue);
            Controls.Add(btnSaveFavorite);
            Controls.Add(cmbFavorites);
            Controls.Add(lbSelectTeam);
            Controls.Add(lbFavoriteTeam);
            Name = "FavoriteForm";
            Text = "FavoriteForm";
            FormClosed += FavoriteForm_FormClosed;
            Load += FavoriteForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbFavoriteTeam;
        private Label lbSelectTeam;
        private ComboBox cmbFavorites;
        private Button btnSaveFavorite;
        private Button btnContinue;
    }
}