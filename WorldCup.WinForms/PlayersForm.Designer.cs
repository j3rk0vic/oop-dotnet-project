namespace WorldCup.WinForms
{
    partial class PlayersForm
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
            lbPlayers = new Label();
            lstPlayers = new ListBox();
            lstFavoritePlayers = new ListBox();
            btnAddToFavorites = new Button();
            btnSaveFavoritePlayers = new Button();
            picPlayer = new PictureBox();
            btnSetImage = new Button();
            ((System.ComponentModel.ISupportInitialize)picPlayer).BeginInit();
            SuspendLayout();
            // 
            // lbPlayers
            // 
            lbPlayers.AutoSize = true;
            lbPlayers.Location = new Point(12, 27);
            lbPlayers.Name = "lbPlayers";
            lbPlayers.Size = new Size(222, 25);
            lbPlayers.TabIndex = 0;
            lbPlayers.Text = "Players from first match of";
            // 
            // lstPlayers
            // 
            lstPlayers.FormattingEnabled = true;
            lstPlayers.ItemHeight = 25;
            lstPlayers.Location = new Point(12, 68);
            lstPlayers.Name = "lstPlayers";
            lstPlayers.SelectionMode = SelectionMode.MultiExtended;
            lstPlayers.Size = new Size(776, 179);
            lstPlayers.TabIndex = 1;
            lstPlayers.SelectedIndexChanged += lstPlayers_SelectedIndexChanged;
            // 
            // lstFavoritePlayers
            // 
            lstFavoritePlayers.FormattingEnabled = true;
            lstFavoritePlayers.ItemHeight = 25;
            lstFavoritePlayers.Location = new Point(12, 361);
            lstFavoritePlayers.Name = "lstFavoritePlayers";
            lstFavoritePlayers.Size = new Size(776, 104);
            lstFavoritePlayers.TabIndex = 3;
            // 
            // btnAddToFavorites
            // 
            btnAddToFavorites.Location = new Point(333, 266);
            btnAddToFavorites.Name = "btnAddToFavorites";
            btnAddToFavorites.Size = new Size(134, 76);
            btnAddToFavorites.TabIndex = 4;
            btnAddToFavorites.Text = "Add to favorites";
            btnAddToFavorites.UseVisualStyleBackColor = true;
            btnAddToFavorites.Click += btnAddToFavorites_Click;
            // 
            // btnSaveFavoritePlayers
            // 
            btnSaveFavoritePlayers.Location = new Point(333, 483);
            btnSaveFavoritePlayers.Name = "btnSaveFavoritePlayers";
            btnSaveFavoritePlayers.Size = new Size(134, 76);
            btnSaveFavoritePlayers.TabIndex = 5;
            btnSaveFavoritePlayers.Text = "Save favorite players";
            btnSaveFavoritePlayers.UseVisualStyleBackColor = true;
            btnSaveFavoritePlayers.Click += btnSaveFavoritePlayers_Click;
            // 
            // picPlayer
            // 
            picPlayer.Location = new Point(871, 68);
            picPlayer.Name = "picPlayer";
            picPlayer.Size = new Size(395, 397);
            picPlayer.SizeMode = PictureBoxSizeMode.StretchImage;
            picPlayer.TabIndex = 6;
            picPlayer.TabStop = false;
            // 
            // btnSetImage
            // 
            btnSetImage.Location = new Point(1003, 483);
            btnSetImage.Name = "btnSetImage";
            btnSetImage.Size = new Size(134, 76);
            btnSetImage.TabIndex = 7;
            btnSetImage.Text = "Set image";
            btnSetImage.UseVisualStyleBackColor = true;
            btnSetImage.Click += btnSetImage_Click;
            // 
            // PlayersForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1289, 571);
            Controls.Add(btnSetImage);
            Controls.Add(picPlayer);
            Controls.Add(btnSaveFavoritePlayers);
            Controls.Add(btnAddToFavorites);
            Controls.Add(lstFavoritePlayers);
            Controls.Add(lstPlayers);
            Controls.Add(lbPlayers);
            Name = "PlayersForm";
            Text = "PlayersForm";
            Load += PlayersForm_Load;
            ((System.ComponentModel.ISupportInitialize)picPlayer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbPlayers;
        private ListBox lstPlayers;
        private ListBox lstFavoritePlayers;
        private Button btnAddToFavorites;
        private Button btnSaveFavoritePlayers;
        private PictureBox picPlayer;
        private Button btnSetImage;
    }
}