namespace org.rosenbohm.csharp.CADdyTools.Forms
{
    partial class frmChangeID
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
            this.cbPunktnummer = new System.Windows.Forms.ComboBox();
            this.tabPChangeID = new System.Windows.Forms.TabPage();
            this.tbNewId = new System.Windows.Forms.TextBox();
            this.btnPktChangeID = new System.Windows.Forms.Button();
            this.lblPointIdNew = new System.Windows.Forms.Label();
            this.lblPointnumber = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPChangeID.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPunktnummer
            // 
            this.cbPunktnummer.FormattingEnabled = true;
            this.cbPunktnummer.Location = new System.Drawing.Point(110, 6);
            this.cbPunktnummer.Name = "cbPunktnummer";
            this.cbPunktnummer.Size = new System.Drawing.Size(121, 21);
            this.cbPunktnummer.TabIndex = 15;
            this.toolTip1.SetToolTip(this.cbPunktnummer, "Möglichkeiten:\r\n\"normale Punktname\" = genau dieser Punkt\r\n*123 = alle Punkte, die" +
        " auf 123 enden\r\n123* = alle Punkte, die mit 123 beginnen\r\n* = ALLE Punkte\r\n... o" +
        "der vollständige REGEX-Ausdrücke");
            // 
            // tabPChangeID
            // 
            this.tabPChangeID.Controls.Add(this.tbNewId);
            this.tabPChangeID.Controls.Add(this.cbPunktnummer);
            this.tabPChangeID.Controls.Add(this.btnPktChangeID);
            this.tabPChangeID.Controls.Add(this.lblPointIdNew);
            this.tabPChangeID.Controls.Add(this.lblPointnumber);
            this.tabPChangeID.Location = new System.Drawing.Point(4, 22);
            this.tabPChangeID.Name = "tabPChangeID";
            this.tabPChangeID.Padding = new System.Windows.Forms.Padding(3);
            this.tabPChangeID.Size = new System.Drawing.Size(276, 236);
            this.tabPChangeID.TabIndex = 0;
            this.tabPChangeID.Text = "Instr.- / Reflektorhöhe";
            this.tabPChangeID.UseVisualStyleBackColor = true;
            // 
            // tbNewId
            // 
            this.tbNewId.Location = new System.Drawing.Point(110, 33);
            this.tbNewId.Name = "tbNewId";
            this.tbNewId.Size = new System.Drawing.Size(121, 20);
            this.tbNewId.TabIndex = 16;
            // 
            // btnPktChangeID
            // 
            this.btnPktChangeID.Location = new System.Drawing.Point(110, 60);
            this.btnPktChangeID.Name = "btnPktChangeID";
            this.btnPktChangeID.Size = new System.Drawing.Size(75, 23);
            this.btnPktChangeID.TabIndex = 8;
            this.btnPktChangeID.Text = "setze i und d";
            this.btnPktChangeID.UseVisualStyleBackColor = true;
            this.btnPktChangeID.Click += new System.EventHandler(this.btnPktChangeID_Click);
            // 
            // lblPointIdNew
            // 
            this.lblPointIdNew.AutoSize = true;
            this.lblPointIdNew.Location = new System.Drawing.Point(8, 36);
            this.lblPointIdNew.Name = "lblPointIdNew";
            this.lblPointIdNew.Size = new System.Drawing.Size(47, 13);
            this.lblPointIdNew.TabIndex = 6;
            this.lblPointIdNew.Text = "i / d neu";
            // 
            // lblPointnumber
            // 
            this.lblPointnumber.AutoSize = true;
            this.lblPointnumber.Location = new System.Drawing.Point(8, 9);
            this.lblPointnumber.Name = "lblPointnumber";
            this.lblPointnumber.Size = new System.Drawing.Size(72, 13);
            this.lblPointnumber.TabIndex = 4;
            this.lblPointnumber.Text = "Punktnummer";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPChangeID);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(284, 262);
            this.tabControl1.TabIndex = 0;
            // 
            // frmChangeID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmChangeID";
            this.Text = "I / D ändern";
            this.tabPChangeID.ResumeLayout(false);
            this.tabPChangeID.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPChangeID;
        private System.Windows.Forms.TextBox tbNewId;
        private System.Windows.Forms.ComboBox cbPunktnummer;
        private System.Windows.Forms.Button btnPktChangeID;
        private System.Windows.Forms.Label lblPointIdNew;
        private System.Windows.Forms.Label lblPointnumber;
        private System.Windows.Forms.TabControl tabControl1;
    }
}