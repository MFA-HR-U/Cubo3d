namespace Udemy3d_1
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
            ptbox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)ptbox).BeginInit();
            SuspendLayout();
            // 
            // ptbox
            // 
            ptbox.BackColor = SystemColors.ActiveCaptionText;
            ptbox.Dock = DockStyle.Fill;
            ptbox.Location = new Point(0, 0);
            ptbox.Name = "ptbox";
            ptbox.Size = new Size(1178, 671);
            ptbox.TabIndex = 0;
            ptbox.TabStop = false;
            ptbox.Paint += ptbox_Paint;
            ptbox.MouseDown += ptbox_MouseDown;
            ptbox.MouseMove += ptbox_MouseMove;
            ptbox.MouseUp += ptbox_MouseUp;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 671);
            Controls.Add(ptbox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)ptbox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox ptbox;
    }
}