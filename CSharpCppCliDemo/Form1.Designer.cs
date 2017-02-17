namespace CSharpCppCliDemo
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.trkLong = new System.Windows.Forms.TrackBar();
            this.trkLat = new System.Windows.Forms.TrackBar();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trkLong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkLat)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(256, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 397);
            this.panel1.TabIndex = 0;
            // 
            // trkLong
            // 
            this.trkLong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trkLong.Location = new System.Drawing.Point(3, 3);
            this.trkLong.Maximum = 359;
            this.trkLong.Name = "trkLong";
            this.trkLong.Size = new System.Drawing.Size(244, 56);
            this.trkLong.TabIndex = 1;
            this.trkLong.Value = 45;
            this.trkLong.Scroll += new System.EventHandler(this.trkLong_Scroll);
            // 
            // trkLat
            // 
            this.trkLat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trkLat.Location = new System.Drawing.Point(3, 65);
            this.trkLat.Maximum = 179;
            this.trkLat.Name = "trkLat";
            this.trkLat.Size = new System.Drawing.Size(244, 56);
            this.trkLat.TabIndex = 2;
            this.trkLat.Value = 135;
            this.trkLat.Scroll += new System.EventHandler(this.trkLat_Scroll);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.trkLat);
            this.panel2.Controls.Add(this.trkLong);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 397);
            this.panel2.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 397);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Fancy Window";
            ((System.ComponentModel.ISupportInitialize)(this.trkLong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkLat)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trkLong;
        private System.Windows.Forms.TrackBar trkLat;
        private System.Windows.Forms.Panel panel2;
    }
}

