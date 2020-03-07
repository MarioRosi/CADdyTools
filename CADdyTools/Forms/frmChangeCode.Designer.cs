namespace org.rosenbohm.csharp.CADdyTools.Forms
{
    partial class frmChangeCode
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
            this.cbCodeOld = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPChangePKTCode = new System.Windows.Forms.TabPage();
            this.cbCodePKTNeu = new System.Windows.Forms.ComboBox();
            this.btnPktChangeCode = new System.Windows.Forms.Button();
            this.lblPKTCodeNeu = new System.Windows.Forms.Label();
            this.lblPunktnummer = new System.Windows.Forms.Label();
            this.tabPCode = new System.Windows.Forms.TabPage();
            this.cbCodeNew = new System.Windows.Forms.ComboBox();
            this.btnChangeCode = new System.Windows.Forms.Button();
            this.lblCodeNew = new System.Windows.Forms.Label();
            this.lblCodeOld = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPChangePKTCode.SuspendLayout();
            this.tabPCode.SuspendLayout();
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
            // cbCodeOld
            // 
            this.cbCodeOld.FormattingEnabled = true;
            this.cbCodeOld.Location = new System.Drawing.Point(110, 6);
            this.cbCodeOld.Name = "cbCodeOld";
            this.cbCodeOld.Size = new System.Drawing.Size(121, 21);
            this.cbCodeOld.TabIndex = 13;
            this.toolTip1.SetToolTip(this.cbCodeOld, "Möglichkeiten:\r\n\"normale Code\" = genau dieser Code\r\n*13 = alle Codes, die auf 13 " +
        "enden\r\n13* = alle Codes, die mit 13 beginnen\r\n* = ALLE Codes\r\n... oder vollständ" +
        "ige REGEX-Ausdrücke");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPChangePKTCode);
            this.tabControl1.Controls.Add(this.tabPCode);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(284, 262);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPChangePKTCode
            // 
            this.tabPChangePKTCode.Controls.Add(this.cbCodePKTNeu);
            this.tabPChangePKTCode.Controls.Add(this.cbPunktnummer);
            this.tabPChangePKTCode.Controls.Add(this.btnPktChangeCode);
            this.tabPChangePKTCode.Controls.Add(this.lblPKTCodeNeu);
            this.tabPChangePKTCode.Controls.Add(this.lblPunktnummer);
            this.tabPChangePKTCode.Location = new System.Drawing.Point(4, 22);
            this.tabPChangePKTCode.Name = "tabPChangePKTCode";
            this.tabPChangePKTCode.Padding = new System.Windows.Forms.Padding(3);
            this.tabPChangePKTCode.Size = new System.Drawing.Size(276, 236);
            this.tabPChangePKTCode.TabIndex = 0;
            this.tabPChangePKTCode.Text = "Punktnummer";
            this.tabPChangePKTCode.UseVisualStyleBackColor = true;
            // 
            // cbCodePKTNeu
            // 
            this.cbCodePKTNeu.FormattingEnabled = true;
            this.cbCodePKTNeu.Location = new System.Drawing.Point(110, 33);
            this.cbCodePKTNeu.Name = "cbCodePKTNeu";
            this.cbCodePKTNeu.Size = new System.Drawing.Size(121, 21);
            this.cbCodePKTNeu.TabIndex = 16;
            // 
            // btnPktChangeCode
            // 
            this.btnPktChangeCode.Location = new System.Drawing.Point(110, 60);
            this.btnPktChangeCode.Name = "btnPktChangeCode";
            this.btnPktChangeCode.Size = new System.Drawing.Size(75, 23);
            this.btnPktChangeCode.TabIndex = 8;
            this.btnPktChangeCode.Text = "setze Code";
            this.btnPktChangeCode.UseVisualStyleBackColor = true;
            this.btnPktChangeCode.Click += new System.EventHandler(this.btnPktChangeCode_Click);
            // 
            // lblPKTCodeNeu
            // 
            this.lblPKTCodeNeu.AutoSize = true;
            this.lblPKTCodeNeu.Location = new System.Drawing.Point(8, 36);
            this.lblPKTCodeNeu.Name = "lblPKTCodeNeu";
            this.lblPKTCodeNeu.Size = new System.Drawing.Size(53, 13);
            this.lblPKTCodeNeu.TabIndex = 6;
            this.lblPKTCodeNeu.Text = "Code neu";
            // 
            // lblPunktnummer
            // 
            this.lblPunktnummer.AutoSize = true;
            this.lblPunktnummer.Location = new System.Drawing.Point(8, 9);
            this.lblPunktnummer.Name = "lblPunktnummer";
            this.lblPunktnummer.Size = new System.Drawing.Size(72, 13);
            this.lblPunktnummer.TabIndex = 4;
            this.lblPunktnummer.Text = "Punktnummer";
            // 
            // tabPCode
            // 
            this.tabPCode.Controls.Add(this.cbCodeNew);
            this.tabPCode.Controls.Add(this.cbCodeOld);
            this.tabPCode.Controls.Add(this.btnChangeCode);
            this.tabPCode.Controls.Add(this.lblCodeNew);
            this.tabPCode.Controls.Add(this.lblCodeOld);
            this.tabPCode.Location = new System.Drawing.Point(4, 22);
            this.tabPCode.Name = "tabPCode";
            this.tabPCode.Padding = new System.Windows.Forms.Padding(3);
            this.tabPCode.Size = new System.Drawing.Size(276, 236);
            this.tabPCode.TabIndex = 1;
            this.tabPCode.Text = "Code";
            this.tabPCode.UseVisualStyleBackColor = true;
            // 
            // cbCodeNew
            // 
            this.cbCodeNew.FormattingEnabled = true;
            this.cbCodeNew.Location = new System.Drawing.Point(110, 33);
            this.cbCodeNew.Name = "cbCodeNew";
            this.cbCodeNew.Size = new System.Drawing.Size(121, 21);
            this.cbCodeNew.TabIndex = 14;
            // 
            // btnChangeCode
            // 
            this.btnChangeCode.Location = new System.Drawing.Point(110, 60);
            this.btnChangeCode.Name = "btnChangeCode";
            this.btnChangeCode.Size = new System.Drawing.Size(75, 23);
            this.btnChangeCode.TabIndex = 12;
            this.btnChangeCode.Text = "setze Code";
            this.btnChangeCode.UseVisualStyleBackColor = true;
            this.btnChangeCode.Click += new System.EventHandler(this.btnChangeCode_Click);
            // 
            // lblCodeNew
            // 
            this.lblCodeNew.AutoSize = true;
            this.lblCodeNew.Location = new System.Drawing.Point(8, 36);
            this.lblCodeNew.Name = "lblCodeNew";
            this.lblCodeNew.Size = new System.Drawing.Size(53, 13);
            this.lblCodeNew.TabIndex = 10;
            this.lblCodeNew.Text = "Code neu";
            // 
            // lblCodeOld
            // 
            this.lblCodeOld.AutoSize = true;
            this.lblCodeOld.Location = new System.Drawing.Point(8, 9);
            this.lblCodeOld.Name = "lblCodeOld";
            this.lblCodeOld.Size = new System.Drawing.Size(46, 13);
            this.lblCodeOld.TabIndex = 8;
            this.lblCodeOld.Text = "Code alt";
            // 
            // frmChangeCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmChangeCode";
            this.Text = "Code tauschen";
            this.tabControl1.ResumeLayout(false);
            this.tabPChangePKTCode.ResumeLayout(false);
            this.tabPChangePKTCode.PerformLayout();
            this.tabPCode.ResumeLayout(false);
            this.tabPCode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPChangePKTCode;
        private System.Windows.Forms.Label lblPKTCodeNeu;
        private System.Windows.Forms.Label lblPunktnummer;
        private System.Windows.Forms.Button btnPktChangeCode;
        private System.Windows.Forms.TabPage tabPCode;
        private System.Windows.Forms.Button btnChangeCode;
        private System.Windows.Forms.Label lblCodeNew;
        private System.Windows.Forms.Label lblCodeOld;
        private System.Windows.Forms.ComboBox cbCodeNew;
        private System.Windows.Forms.ComboBox cbCodeOld;
        private System.Windows.Forms.ComboBox cbCodePKTNeu;
        private System.Windows.Forms.ComboBox cbPunktnummer;
    }
}