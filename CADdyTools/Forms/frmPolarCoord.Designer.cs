namespace org.rosenbohm.csharp.CADdyTools.Forms
{
    partial class frmPolarCoord
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
            this.tbDeltaH = new System.Windows.Forms.TextBox();
            this.tabPPolar = new System.Windows.Forms.TabPage();
            this.tbLength = new System.Windows.Forms.TextBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.tbRiwi = new System.Windows.Forms.TextBox();
            this.lblRiwi = new System.Windows.Forms.Label();
            this.lbldeltaH = new System.Windows.Forms.Label();
            this.btnMakeCalc = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbDistance = new System.Windows.Forms.TextBox();
            this.lblDistance = new System.Windows.Forms.Label();
            this.tbClination = new System.Windows.Forms.TextBox();
            this.lblClination = new System.Windows.Forms.Label();
            this.cbStartpoint = new System.Windows.Forms.ComboBox();
            this.lblStartpoint = new System.Windows.Forms.Label();
            this.cbEndpoint = new System.Windows.Forms.ComboBox();
            this.lblEndpoint = new System.Windows.Forms.Label();
            this.tabPPolar.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDeltaH
            // 
            this.tbDeltaH.Location = new System.Drawing.Point(136, 168);
            this.tbDeltaH.Name = "tbDeltaH";
            this.tbDeltaH.Size = new System.Drawing.Size(100, 20);
            this.tbDeltaH.TabIndex = 19;
            // 
            // tabPPolar
            // 
            this.tabPPolar.Controls.Add(this.cbEndpoint);
            this.tabPPolar.Controls.Add(this.lblEndpoint);
            this.tabPPolar.Controls.Add(this.cbStartpoint);
            this.tabPPolar.Controls.Add(this.lblStartpoint);
            this.tabPPolar.Controls.Add(this.tbClination);
            this.tabPPolar.Controls.Add(this.lblClination);
            this.tabPPolar.Controls.Add(this.tbDistance);
            this.tabPPolar.Controls.Add(this.lblDistance);
            this.tabPPolar.Controls.Add(this.tbLength);
            this.tabPPolar.Controls.Add(this.lblLength);
            this.tabPPolar.Controls.Add(this.tbRiwi);
            this.tabPPolar.Controls.Add(this.lblRiwi);
            this.tabPPolar.Controls.Add(this.tbDeltaH);
            this.tabPPolar.Controls.Add(this.lbldeltaH);
            this.tabPPolar.Controls.Add(this.btnMakeCalc);
            this.tabPPolar.Location = new System.Drawing.Point(4, 22);
            this.tabPPolar.Name = "tabPPolar";
            this.tabPPolar.Padding = new System.Windows.Forms.Padding(3);
            this.tabPPolar.Size = new System.Drawing.Size(276, 475);
            this.tabPPolar.TabIndex = 0;
            this.tabPPolar.Text = "Richtungswinkel & Strecke";
            this.tabPPolar.UseVisualStyleBackColor = true;
            // 
            // tbLength
            // 
            this.tbLength.Location = new System.Drawing.Point(136, 142);
            this.tbLength.Name = "tbLength";
            this.tbLength.Size = new System.Drawing.Size(100, 20);
            this.tbLength.TabIndex = 23;
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(7, 145);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(97, 13);
            this.lblLength.TabIndex = 22;
            this.lblLength.Text = "söhlige Strecke (m)";
            // 
            // tbRiwi
            // 
            this.tbRiwi.Location = new System.Drawing.Point(136, 116);
            this.tbRiwi.Name = "tbRiwi";
            this.tbRiwi.Size = new System.Drawing.Size(100, 20);
            this.tbRiwi.TabIndex = 21;
            // 
            // lblRiwi
            // 
            this.lblRiwi.AutoSize = true;
            this.lblRiwi.Location = new System.Drawing.Point(7, 119);
            this.lblRiwi.Name = "lblRiwi";
            this.lblRiwi.Size = new System.Drawing.Size(123, 13);
            this.lblRiwi.TabIndex = 20;
            this.lblRiwi.Text = "Richtungswinkel in GON";
            // 
            // lbldeltaH
            // 
            this.lbldeltaH.AutoSize = true;
            this.lbldeltaH.Location = new System.Drawing.Point(7, 171);
            this.lbldeltaH.Name = "lbldeltaH";
            this.lbldeltaH.Size = new System.Drawing.Size(111, 13);
            this.lbldeltaH.TabIndex = 18;
            this.lbldeltaH.Text = "Höhenunterschied (m)";
            // 
            // btnMakeCalc
            // 
            this.btnMakeCalc.Location = new System.Drawing.Point(136, 73);
            this.btnMakeCalc.Name = "btnMakeCalc";
            this.btnMakeCalc.Size = new System.Drawing.Size(100, 23);
            this.btnMakeCalc.TabIndex = 8;
            this.btnMakeCalc.Text = "berechnen";
            this.btnMakeCalc.UseVisualStyleBackColor = true;
            this.btnMakeCalc.Click += new System.EventHandler(this.btnMakeCalc_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPPolar);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(284, 501);
            this.tabControl1.TabIndex = 0;
            // 
            // tbDistance
            // 
            this.tbDistance.Location = new System.Drawing.Point(136, 194);
            this.tbDistance.Name = "tbDistance";
            this.tbDistance.Size = new System.Drawing.Size(100, 20);
            this.tbDistance.TabIndex = 25;
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(7, 197);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(102, 13);
            this.lblDistance.TabIndex = 24;
            this.lblDistance.Text = "schräge Strecke (m)";
            // 
            // tbClination
            // 
            this.tbClination.Location = new System.Drawing.Point(136, 220);
            this.tbClination.Name = "tbClination";
            this.tbClination.Size = new System.Drawing.Size(100, 20);
            this.tbClination.TabIndex = 27;
            // 
            // lblClination
            // 
            this.lblClination.AutoSize = true;
            this.lblClination.Location = new System.Drawing.Point(7, 223);
            this.lblClination.Name = "lblClination";
            this.lblClination.Size = new System.Drawing.Size(57, 13);
            this.lblClination.TabIndex = 26;
            this.lblClination.Text = "Gefälle (%)";
            // 
            // cbStartpoint
            // 
            this.cbStartpoint.FormattingEnabled = true;
            this.cbStartpoint.Location = new System.Drawing.Point(136, 6);
            this.cbStartpoint.Name = "cbStartpoint";
            this.cbStartpoint.Size = new System.Drawing.Size(121, 21);
            this.cbStartpoint.TabIndex = 29;
            // 
            // lblStartpoint
            // 
            this.lblStartpoint.AutoSize = true;
            this.lblStartpoint.Location = new System.Drawing.Point(8, 9);
            this.lblStartpoint.Name = "lblStartpoint";
            this.lblStartpoint.Size = new System.Drawing.Size(56, 13);
            this.lblStartpoint.TabIndex = 28;
            this.lblStartpoint.Text = "Startpunkt";
            // 
            // cbEndpoint
            // 
            this.cbEndpoint.FormattingEnabled = true;
            this.cbEndpoint.Location = new System.Drawing.Point(136, 33);
            this.cbEndpoint.Name = "cbEndpoint";
            this.cbEndpoint.Size = new System.Drawing.Size(121, 21);
            this.cbEndpoint.TabIndex = 31;
            // 
            // lblEndpoint
            // 
            this.lblEndpoint.AutoSize = true;
            this.lblEndpoint.Location = new System.Drawing.Point(8, 36);
            this.lblEndpoint.Name = "lblEndpoint";
            this.lblEndpoint.Size = new System.Drawing.Size(53, 13);
            this.lblEndpoint.TabIndex = 30;
            this.lblEndpoint.Text = "Endpunkt";
            // 
            // frmPolarCoord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 501);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmPolarCoord";
            this.Text = "Polarkoordinaten berechnen";
            this.tabPPolar.ResumeLayout(false);
            this.tabPPolar.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPPolar;
        private System.Windows.Forms.Button btnMakeCalc;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox tbDeltaH;
        private System.Windows.Forms.Label lbldeltaH;
        private System.Windows.Forms.TextBox tbLength;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.TextBox tbRiwi;
        private System.Windows.Forms.Label lblRiwi;
        private System.Windows.Forms.TextBox tbClination;
        private System.Windows.Forms.Label lblClination;
        private System.Windows.Forms.TextBox tbDistance;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.ComboBox cbEndpoint;
        private System.Windows.Forms.Label lblEndpoint;
        private System.Windows.Forms.ComboBox cbStartpoint;
        private System.Windows.Forms.Label lblStartpoint;
    }
}