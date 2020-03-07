namespace org.rosenbohm.csharp.CADdyTools.Forms
{
    partial class frmRotateCoord
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
            this.cbRotPoint = new System.Windows.Forms.ComboBox();
            this.cbDirPoint = new System.Windows.Forms.ComboBox();
            this.tabPRotation = new System.Windows.Forms.TabPage();
            this.tbDirection = new System.Windows.Forms.TextBox();
            this.lblDirection = new System.Windows.Forms.Label();
            this.lblDirPoint = new System.Windows.Forms.Label();
            this.btnPktCalcRotation = new System.Windows.Forms.Button();
            this.lblRotPoint = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.chbZTo0 = new System.Windows.Forms.CheckBox();
            this.lblrPointZTo0 = new System.Windows.Forms.Label();
            this.tabPRotation.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbRotPoint
            // 
            this.cbRotPoint.FormattingEnabled = true;
            this.cbRotPoint.Location = new System.Drawing.Point(110, 6);
            this.cbRotPoint.Name = "cbRotPoint";
            this.cbRotPoint.Size = new System.Drawing.Size(121, 21);
            this.cbRotPoint.TabIndex = 15;
            // 
            // cbDirPoint
            // 
            this.cbDirPoint.FormattingEnabled = true;
            this.cbDirPoint.Location = new System.Drawing.Point(110, 56);
            this.cbDirPoint.Name = "cbDirPoint";
            this.cbDirPoint.Size = new System.Drawing.Size(121, 21);
            this.cbDirPoint.TabIndex = 17;
            // 
            // tabPRotation
            // 
            this.tabPRotation.Controls.Add(this.lblrPointZTo0);
            this.tabPRotation.Controls.Add(this.chbZTo0);
            this.tabPRotation.Controls.Add(this.tbDirection);
            this.tabPRotation.Controls.Add(this.lblDirection);
            this.tabPRotation.Controls.Add(this.cbDirPoint);
            this.tabPRotation.Controls.Add(this.lblDirPoint);
            this.tabPRotation.Controls.Add(this.cbRotPoint);
            this.tabPRotation.Controls.Add(this.btnPktCalcRotation);
            this.tabPRotation.Controls.Add(this.lblRotPoint);
            this.tabPRotation.Location = new System.Drawing.Point(4, 22);
            this.tabPRotation.Name = "tabPRotation";
            this.tabPRotation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPRotation.Size = new System.Drawing.Size(276, 236);
            this.tabPRotation.TabIndex = 0;
            this.tabPRotation.Text = "Rotation";
            this.tabPRotation.UseVisualStyleBackColor = true;
            // 
            // tbDirection
            // 
            this.tbDirection.Location = new System.Drawing.Point(110, 83);
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(100, 20);
            this.tbDirection.TabIndex = 19;
            this.toolTip1.SetToolTip(this.tbDirection, "6464654644");
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(8, 86);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(84, 13);
            this.lblDirection.TabIndex = 18;
            this.lblDirection.Text = "Richtung in Gon";
            // 
            // lblDirPoint
            // 
            this.lblDirPoint.AutoSize = true;
            this.lblDirPoint.Location = new System.Drawing.Point(8, 59);
            this.lblDirPoint.Name = "lblDirPoint";
            this.lblDirPoint.Size = new System.Drawing.Size(92, 13);
            this.lblDirPoint.TabIndex = 16;
            this.lblDirPoint.Text = "Punkt in Richtung";
            // 
            // btnPktCalcRotation
            // 
            this.btnPktCalcRotation.Location = new System.Drawing.Point(110, 124);
            this.btnPktCalcRotation.Name = "btnPktCalcRotation";
            this.btnPktCalcRotation.Size = new System.Drawing.Size(100, 23);
            this.btnPktCalcRotation.TabIndex = 8;
            this.btnPktCalcRotation.Text = "Rechne Rotation";
            this.btnPktCalcRotation.UseVisualStyleBackColor = true;
            this.btnPktCalcRotation.Click += new System.EventHandler(this.btnPktRotation_Click);
            // 
            // lblRotPoint
            // 
            this.lblRotPoint.AutoSize = true;
            this.lblRotPoint.Location = new System.Drawing.Point(8, 9);
            this.lblRotPoint.Name = "lblRotPoint";
            this.lblRotPoint.Size = new System.Drawing.Size(57, 13);
            this.lblRotPoint.TabIndex = 4;
            this.lblRotPoint.Text = "Drehpunkt";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPRotation);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(284, 262);
            this.tabControl1.TabIndex = 0;
            // 
            // chbZTo0
            // 
            this.chbZTo0.AutoSize = true;
            this.chbZTo0.Location = new System.Drawing.Point(110, 33);
            this.chbZTo0.Name = "chbZTo0";
            this.chbZTo0.Size = new System.Drawing.Size(96, 17);
            this.chbZTo0.TabIndex = 21;
            this.chbZTo0.Text = "auf 0.0 setzten";
            this.chbZTo0.UseVisualStyleBackColor = true;
            // 
            // lblrPointZTo0
            // 
            this.lblrPointZTo0.AutoSize = true;
            this.lblrPointZTo0.Location = new System.Drawing.Point(8, 34);
            this.lblrPointZTo0.Name = "lblrPointZTo0";
            this.lblrPointZTo0.Size = new System.Drawing.Size(70, 13);
            this.lblrPointZTo0.TabIndex = 22;
            this.lblrPointZTo0.Text = "Drehpunkt  Z";
            // 
            // frmRotateCoord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmRotateCoord";
            this.Text = "Koordinaten rotieren";
            this.tabPRotation.ResumeLayout(false);
            this.tabPRotation.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPRotation;
        private System.Windows.Forms.ComboBox cbRotPoint;
        private System.Windows.Forms.Button btnPktCalcRotation;
        private System.Windows.Forms.Label lblRotPoint;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox tbDirection;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.ComboBox cbDirPoint;
        private System.Windows.Forms.Label lblDirPoint;
        private System.Windows.Forms.Label lblrPointZTo0;
        private System.Windows.Forms.CheckBox chbZTo0;
    }
}