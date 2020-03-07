namespace org.rosenbohm.csharp.CADdyTools.Forms
{
    partial class frmTranslateCoord
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbTranslHO = new System.Windows.Forms.TextBox();
            this.tabPTranslation = new System.Windows.Forms.TabPage();
            this.lblTranslHO = new System.Windows.Forms.Label();
            this.btnMakeTransl = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbTranslRW = new System.Windows.Forms.TextBox();
            this.lblTranslRW = new System.Windows.Forms.Label();
            this.tbTranslHW = new System.Windows.Forms.TextBox();
            this.lblTranslHW = new System.Windows.Forms.Label();
            this.tabPTranslation.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbTranslHO
            // 
            this.tbTranslHO.Location = new System.Drawing.Point(125, 58);
            this.tbTranslHO.Name = "tbTranslHO";
            this.tbTranslHO.Size = new System.Drawing.Size(100, 20);
            this.tbTranslHO.TabIndex = 19;
            // 
            // tabPTranslation
            // 
            this.tabPTranslation.Controls.Add(this.tbTranslHW);
            this.tabPTranslation.Controls.Add(this.lblTranslHW);
            this.tabPTranslation.Controls.Add(this.tbTranslRW);
            this.tabPTranslation.Controls.Add(this.lblTranslRW);
            this.tabPTranslation.Controls.Add(this.tbTranslHO);
            this.tabPTranslation.Controls.Add(this.lblTranslHO);
            this.tabPTranslation.Controls.Add(this.btnMakeTransl);
            this.tabPTranslation.Location = new System.Drawing.Point(4, 22);
            this.tabPTranslation.Name = "tabPTranslation";
            this.tabPTranslation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPTranslation.Size = new System.Drawing.Size(276, 236);
            this.tabPTranslation.TabIndex = 0;
            this.tabPTranslation.Text = "Translation";
            this.tabPTranslation.UseVisualStyleBackColor = true;
            // 
            // lblTranslHO
            // 
            this.lblTranslHO.AutoSize = true;
            this.lblTranslHO.Location = new System.Drawing.Point(8, 61);
            this.lblTranslHO.Name = "lblTranslHO";
            this.lblTranslHO.Size = new System.Drawing.Size(101, 13);
            this.lblTranslHO.TabIndex = 18;
            this.lblTranslHO.Text = "Versch. in der Höhe";
            // 
            // btnMakeTransl
            // 
            this.btnMakeTransl.Location = new System.Drawing.Point(125, 95);
            this.btnMakeTransl.Name = "btnMakeTransl";
            this.btnMakeTransl.Size = new System.Drawing.Size(100, 23);
            this.btnMakeTransl.TabIndex = 8;
            this.btnMakeTransl.Text = "Translation";
            this.btnMakeTransl.UseVisualStyleBackColor = true;
            this.btnMakeTransl.Click += new System.EventHandler(this.btnPktRotation_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPTranslation);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(284, 262);
            this.tabControl1.TabIndex = 0;
            // 
            // tbTranslRW
            // 
            this.tbTranslRW.Location = new System.Drawing.Point(125, 6);
            this.tbTranslRW.Name = "tbTranslRW";
            this.tbTranslRW.Size = new System.Drawing.Size(100, 20);
            this.tbTranslRW.TabIndex = 21;
            // 
            // lblTranslRW
            // 
            this.lblTranslRW.AutoSize = true;
            this.lblTranslRW.Location = new System.Drawing.Point(8, 9);
            this.lblTranslRW.Name = "lblTranslRW";
            this.lblTranslRW.Size = new System.Drawing.Size(113, 13);
            this.lblTranslRW.TabIndex = 20;
            this.lblTranslRW.Text = "Versch. im Rechtswert";
            // 
            // tbTranslHW
            // 
            this.tbTranslHW.Location = new System.Drawing.Point(125, 32);
            this.tbTranslHW.Name = "tbTranslHW";
            this.tbTranslHW.Size = new System.Drawing.Size(100, 20);
            this.tbTranslHW.TabIndex = 23;
            // 
            // lblTranslHW
            // 
            this.lblTranslHW.AutoSize = true;
            this.lblTranslHW.Location = new System.Drawing.Point(8, 35);
            this.lblTranslHW.Name = "lblTranslHW";
            this.lblTranslHW.Size = new System.Drawing.Size(105, 13);
            this.lblTranslHW.TabIndex = 22;
            this.lblTranslHW.Text = "Versch. im Hochwert";
            // 
            // frmTranslateCoord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmTranslateCoord";
            this.Text = "Koordinaten schieben";
            this.tabPTranslation.ResumeLayout(false);
            this.tabPTranslation.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPTranslation;
        private System.Windows.Forms.Button btnMakeTransl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox tbTranslHO;
        private System.Windows.Forms.Label lblTranslHO;
        private System.Windows.Forms.TextBox tbTranslHW;
        private System.Windows.Forms.Label lblTranslHW;
        private System.Windows.Forms.TextBox tbTranslRW;
        private System.Windows.Forms.Label lblTranslRW;
    }
}