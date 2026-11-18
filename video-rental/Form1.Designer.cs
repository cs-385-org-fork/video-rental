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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(800, 511);
            Controls.Add(lblTitle2);
            Controls.Add(lblTitle1);
            Name = "Form1";
            Text = "BluckBosterTM Video Rental Portal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle1;
        private Label lblTitle2;
    }
}
