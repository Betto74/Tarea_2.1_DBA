namespace PROYECTO_U3
{
    partial class FrmMenu
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
            this.btnVer = new System.Windows.Forms.Button();
            this.btnUpdaate = new System.Windows.Forms.Button();
            this.ptbBackground = new System.Windows.Forms.PictureBox();
            this.ptbIcon = new System.Windows.Forms.PictureBox();
            this.lblDec1 = new System.Windows.Forms.Label();
            this.ptbDec1 = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDec1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVer
            // 
            this.btnVer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVer.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVer.Location = new System.Drawing.Point(740, 206);
            this.btnVer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(95, 27);
            this.btnVer.TabIndex = 0;
            this.btnVer.Text = "See profile";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // btnUpdaate
            // 
            this.btnUpdaate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdaate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdaate.Location = new System.Drawing.Point(740, 238);
            this.btnUpdaate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdaate.Name = "btnUpdaate";
            this.btnUpdaate.Size = new System.Drawing.Size(95, 46);
            this.btnUpdaate.TabIndex = 1;
            this.btnUpdaate.Text = "Update profile";
            this.btnUpdaate.UseVisualStyleBackColor = true;
            this.btnUpdaate.Click += new System.EventHandler(this.btnUpdaate_Click);
            // 
            // ptbBackground
            // 
            this.ptbBackground.Image = global::PROYECTO_U3.Properties.Resources._4588615_2434895;
            this.ptbBackground.Location = new System.Drawing.Point(-8, -2);
            this.ptbBackground.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ptbBackground.Name = "ptbBackground";
            this.ptbBackground.Size = new System.Drawing.Size(936, 443);
            this.ptbBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbBackground.TabIndex = 3;
            this.ptbBackground.TabStop = false;
            this.ptbBackground.Click += new System.EventHandler(this.ptbBackground_Click);
            // 
            // ptbIcon
            // 
            this.ptbIcon.BackColor = System.Drawing.Color.Transparent;
            this.ptbIcon.Image = global::PROYECTO_U3.Properties.Resources.UserIcon;
            this.ptbIcon.Location = new System.Drawing.Point(724, 59);
            this.ptbIcon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ptbIcon.Name = "ptbIcon";
            this.ptbIcon.Size = new System.Drawing.Size(127, 114);
            this.ptbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbIcon.TabIndex = 2;
            this.ptbIcon.TabStop = false;
            // 
            // lblDec1
            // 
            this.lblDec1.AutoSize = true;
            this.lblDec1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDec1.Location = new System.Drawing.Point(821, 26);
            this.lblDec1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDec1.Name = "lblDec1";
            this.lblDec1.Size = new System.Drawing.Size(55, 23);
            this.lblDec1.TabIndex = 4;
            this.lblDec1.Text = "Menu";
            // 
            // ptbDec1
            // 
            this.ptbDec1.Location = new System.Drawing.Point(696, 47);
            this.ptbDec1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ptbDec1.Name = "ptbDec1";
            this.ptbDec1.Size = new System.Drawing.Size(183, 263);
            this.ptbDec1.TabIndex = 5;
            this.ptbDec1.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(763, 178);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(46, 19);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "label1";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 437);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblDec1);
            this.Controls.Add(this.ptbIcon);
            this.Controls.Add(this.btnUpdaate);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.ptbDec1);
            this.Controls.Add(this.ptbBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMenu_FormClosed);
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDec1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Button btnUpdaate;
        private System.Windows.Forms.PictureBox ptbIcon;
        private System.Windows.Forms.PictureBox ptbBackground;
        private System.Windows.Forms.Label lblDec1;
        private System.Windows.Forms.PictureBox ptbDec1;
        private System.Windows.Forms.Label lblName;
    }
}