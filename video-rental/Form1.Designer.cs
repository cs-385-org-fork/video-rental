namespace video_rental {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            lblTitle1 = new Label();
            lblTitle2 = new Label();
            gbxMovies = new GroupBox();
            gbxBoxSets = new GroupBox();
            gbxVideoGames = new GroupBox();
            button1 = new Button();
            tabControl1 = new TabControl();
            tabBrowse = new TabPage();
            tabCart = new TabPage();
            tabAccount = new TabPage();
            lbxMovies = new ListBox();
            lbxBoxSets = new ListBox();
            lbxVideoGames = new ListBox();
            gbxMovies.SuspendLayout();
            gbxBoxSets.SuspendLayout();
            gbxVideoGames.SuspendLayout();
            tabControl1.SuspendLayout();
            tabBrowse.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle1
            // 
            lblTitle1.AutoSize = true;
            lblTitle1.Font = new Font("Impact", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle1.ForeColor = Color.Yellow;
            lblTitle1.Location = new Point(12, 9);
            lblTitle1.Name = "lblTitle1";
            lblTitle1.Size = new Size(202, 39);
            lblTitle1.TabIndex = 0;
            lblTitle1.Text = "BluckBoster™";
            // 
            // lblTitle2
            // 
            lblTitle2.AutoSize = true;
            lblTitle2.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle2.ForeColor = Color.Yellow;
            lblTitle2.Location = new Point(204, 20);
            lblTitle2.Name = "lblTitle2";
            lblTitle2.Size = new Size(238, 25);
            lblTitle2.TabIndex = 1;
            lblTitle2.Text = "Video Rental Portal";
            // 
            // gbxMovies
            // 
            gbxMovies.BackColor = Color.CornflowerBlue;
            gbxMovies.Controls.Add(lbxMovies);
            gbxMovies.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbxMovies.ForeColor = SystemColors.WindowText;
            gbxMovies.Location = new Point(3, 6);
            gbxMovies.Name = "gbxMovies";
            gbxMovies.Size = new Size(250, 400);
            gbxMovies.TabIndex = 2;
            gbxMovies.TabStop = false;
            gbxMovies.Text = "Movies";
            // 
            // gbxBoxSets
            // 
            gbxBoxSets.BackColor = Color.LightCoral;
            gbxBoxSets.Controls.Add(lbxBoxSets);
            gbxBoxSets.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbxBoxSets.ForeColor = SystemColors.WindowText;
            gbxBoxSets.Location = new Point(259, 6);
            gbxBoxSets.Name = "gbxBoxSets";
            gbxBoxSets.Size = new Size(250, 400);
            gbxBoxSets.TabIndex = 3;
            gbxBoxSets.TabStop = false;
            gbxBoxSets.Text = "TV";
            // 
            // gbxVideoGames
            // 
            gbxVideoGames.BackColor = Color.LightGreen;
            gbxVideoGames.Controls.Add(lbxVideoGames);
            gbxVideoGames.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbxVideoGames.ForeColor = SystemColors.ControlText;
            gbxVideoGames.Location = new Point(515, 6);
            gbxVideoGames.Name = "gbxVideoGames";
            gbxVideoGames.Size = new Size(250, 400);
            gbxVideoGames.TabIndex = 4;
            gbxVideoGames.TabStop = false;
            gbxVideoGames.Text = "Video Games";
            // 
            // button1
            // 
            button1.Location = new Point(25, 186);
            button1.Name = "button1";
            button1.Size = new Size(0, 0);
            button1.TabIndex = 5;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabBrowse);
            tabControl1.Controls.Add(tabCart);
            tabControl1.Controls.Add(tabAccount);
            tabControl1.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(12, 51);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(782, 448);
            tabControl1.TabIndex = 6;
            // 
            // tabBrowse
            // 
            tabBrowse.BackColor = SystemColors.HotTrack;
            tabBrowse.Controls.Add(gbxMovies);
            tabBrowse.Controls.Add(gbxBoxSets);
            tabBrowse.Controls.Add(gbxVideoGames);
            tabBrowse.Location = new Point(4, 32);
            tabBrowse.Name = "tabBrowse";
            tabBrowse.Padding = new Padding(3);
            tabBrowse.Size = new Size(774, 412);
            tabBrowse.TabIndex = 0;
            tabBrowse.Text = "Browse";
            // 
            // tabCart
            // 
            tabCart.BackColor = SystemColors.HotTrack;
            tabCart.Location = new Point(4, 32);
            tabCart.Name = "tabCart";
            tabCart.Padding = new Padding(3);
            tabCart.Size = new Size(774, 412);
            tabCart.TabIndex = 1;
            tabCart.Text = "My Cart (0)";
            // 
            // tabAccount
            // 
            tabAccount.BackColor = SystemColors.HotTrack;
            tabAccount.Location = new Point(4, 32);
            tabAccount.Name = "tabAccount";
            tabAccount.Padding = new Padding(3);
            tabAccount.Size = new Size(774, 412);
            tabAccount.TabIndex = 2;
            tabAccount.Text = "My Account";
            // 
            // lbxMovies
            // 
            lbxMovies.BackColor = Color.CornflowerBlue;
            lbxMovies.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbxMovies.FormattingEnabled = true;
            lbxMovies.Location = new Point(6, 28);
            lbxMovies.Name = "lbxMovies";
            lbxMovies.Size = new Size(238, 361);
            lbxMovies.TabIndex = 0;
            // 
            // lbxBoxSets
            // 
            lbxBoxSets.BackColor = Color.LightCoral;
            lbxBoxSets.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbxBoxSets.FormattingEnabled = true;
            lbxBoxSets.Location = new Point(6, 28);
            lbxBoxSets.Name = "lbxBoxSets";
            lbxBoxSets.Size = new Size(238, 361);
            lbxBoxSets.TabIndex = 1;
            // 
            // lbxVideoGames
            // 
            lbxVideoGames.BackColor = Color.LightGreen;
            lbxVideoGames.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbxVideoGames.FormattingEnabled = true;
            lbxVideoGames.Location = new Point(6, 28);
            lbxVideoGames.Name = "lbxVideoGames";
            lbxVideoGames.Size = new Size(238, 361);
            lbxVideoGames.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(806, 511);
            Controls.Add(tabControl1);
            Controls.Add(button1);
            Controls.Add(lblTitle2);
            Controls.Add(lblTitle1);
            Name = "Form1";
            Text = "BluckBosterTM Video Rental Portal";
            gbxMovies.ResumeLayout(false);
            gbxBoxSets.ResumeLayout(false);
            gbxVideoGames.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabBrowse.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle1;
        private Label lblTitle2;
        private GroupBox gbxMovies;
        private GroupBox gbxBoxSets;
        private GroupBox gbxVideoGames;
        private Button button1;
        private TabControl tabControl1;
        private TabPage tabBrowse;
        private TabPage tabCart;
        private TabPage tabAccount;
        private ListBox lbxMovies;
        private ListBox lbxBoxSets;
        private ListBox lbxVideoGames;
    }
}
