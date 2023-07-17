
namespace Beauty_Cosmetics
{
    partial class Splash
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.prograssbar1 = new CircularProgressBar.CircularProgressBar();
            this.lnlApplicationName = new System.Windows.Forms.Label();
            this.lblloading = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // prograssbar1
            // 
            this.prograssbar1.AnimationFunction = ((WinFormAnimation.AnimationFunctions.Function)(resources.GetObject("prograssbar1.AnimationFunction")));
            this.prograssbar1.AnimationSpeed = 500;
            this.prograssbar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.prograssbar1.Font = new System.Drawing.Font("Mongolian Baiti", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prograssbar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.prograssbar1.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.prograssbar1.InnerMargin = 2;
            this.prograssbar1.InnerWidth = -1;
            this.prograssbar1.Location = new System.Drawing.Point(46, 108);
            this.prograssbar1.MarqueeAnimationSpeed = 2000;
            this.prograssbar1.Name = "prograssbar1";
            this.prograssbar1.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(28)))), ((int)(((byte)(43)))));
            this.prograssbar1.OuterMargin = -25;
            this.prograssbar1.OuterWidth = 26;
            this.prograssbar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.prograssbar1.ProgressWidth = 6;
            this.prograssbar1.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.prograssbar1.Size = new System.Drawing.Size(150, 150);
            this.prograssbar1.StartAngle = 270;
            this.prograssbar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prograssbar1.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.prograssbar1.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.prograssbar1.SubscriptText = "";
            this.prograssbar1.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.prograssbar1.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.prograssbar1.SuperscriptText = "";
            this.prograssbar1.TabIndex = 0;
            this.prograssbar1.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.prograssbar1.Value = 68;
            // 
            // lnlApplicationName
            // 
            this.lnlApplicationName.AutoSize = true;
            this.lnlApplicationName.Font = new System.Drawing.Font("Mongolian Baiti", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnlApplicationName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.lnlApplicationName.Location = new System.Drawing.Point(12, 45);
            this.lnlApplicationName.Name = "lnlApplicationName";
            this.lnlApplicationName.Size = new System.Drawing.Size(240, 30);
            this.lnlApplicationName.TabIndex = 1;
            this.lnlApplicationName.Text = "Beauty Cosmetics";
            // 
            // lblloading
            // 
            this.lblloading.AutoSize = true;
            this.lblloading.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblloading.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblloading.Location = new System.Drawing.Point(67, 261);
            this.lblloading.Name = "lblloading";
            this.lblloading.Size = new System.Drawing.Size(108, 34);
            this.lblloading.TabIndex = 2;
            this.lblloading.Text = "Loading....";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCopyright.Location = new System.Drawing.Point(28, 353);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(202, 16);
            this.lblCopyright.TabIndex = 3;
            this.lblCopyright.Text = "Beauty Cosmetics © Copyright";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(255, 378);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblloading);
            this.Controls.Add(this.lnlApplicationName);
            this.Controls.Add(this.prograssbar1);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CircularProgressBar.CircularProgressBar prograssbar1;
        private System.Windows.Forms.Label lnlApplicationName;
        private System.Windows.Forms.Label lblloading;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Timer timer1;
    }
}

