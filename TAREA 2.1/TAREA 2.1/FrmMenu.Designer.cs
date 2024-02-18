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
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnAreas = new System.Windows.Forms.Button();
            this.lblMenu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInventario
            // 
            this.btnInventario.Location = new System.Drawing.Point(114, 186);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(75, 23);
            this.btnInventario.TabIndex = 0;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnAreas
            // 
            this.btnAreas.Location = new System.Drawing.Point(114, 285);
            this.btnAreas.Name = "btnAreas";
            this.btnAreas.Size = new System.Drawing.Size(75, 23);
            this.btnAreas.TabIndex = 1;
            this.btnAreas.Text = "Areas";
            this.btnAreas.UseVisualStyleBackColor = true;
            this.btnAreas.Click += new System.EventHandler(this.btnAreas_Click);
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Location = new System.Drawing.Point(150, 82);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(39, 13);
            this.lblMenu.TabIndex = 2;
            this.lblMenu.Text = "MENU";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PROYECTO_U3.Properties.Resources.fondo_oscuro;
            this.ClientSize = new System.Drawing.Size(317, 450);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.btnAreas);
            this.Controls.Add(this.btnInventario);
            this.Name = "FrmMenu";
            this.Text = "FrmMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnAreas;
        private System.Windows.Forms.Label lblMenu;
    }
}