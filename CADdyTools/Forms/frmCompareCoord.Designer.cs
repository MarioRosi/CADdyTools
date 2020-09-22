namespace org.rosenbohm.csharp.CADdyTools.Forms
{
    partial class frmCompareCoord
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dgvCompare = new System.Windows.Forms.DataGridView();
            this.pointName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ep1RW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ep1HW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ep1Z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ep2RW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ep2HW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ep2Z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deltaRW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deltaHW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deltaZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delta2D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delta3D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deltaRiwi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMakeCompare = new System.Windows.Forms.Button();
            this.btnChangeEpochen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblEpoche1 = new System.Windows.Forms.Label();
            this.lblEpoche2 = new System.Windows.Forms.Label();
            this.cbList1 = new System.Windows.Forms.ComboBox();
            this.cbList2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompare)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCompare
            // 
            this.dgvCompare.AllowUserToAddRows = false;
            this.dgvCompare.AllowUserToDeleteRows = false;
            this.dgvCompare.AllowUserToResizeRows = false;
            this.dgvCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCompare.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCompare.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompare.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCompare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompare.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pointName,
            this.ep1RW,
            this.ep1HW,
            this.ep1Z,
            this.ep2RW,
            this.ep2HW,
            this.ep2Z,
            this.deltaRW,
            this.deltaHW,
            this.deltaZ,
            this.delta2D,
            this.delta3D,
            this.deltaRiwi});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCompare.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvCompare.Location = new System.Drawing.Point(0, 62);
            this.dgvCompare.Name = "dgvCompare";
            this.dgvCompare.ReadOnly = true;
            this.dgvCompare.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompare.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvCompare.RowHeadersVisible = false;
            this.dgvCompare.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompare.ShowCellErrors = false;
            this.dgvCompare.ShowCellToolTips = false;
            this.dgvCompare.ShowEditingIcon = false;
            this.dgvCompare.ShowRowErrors = false;
            this.dgvCompare.Size = new System.Drawing.Size(847, 97);
            this.dgvCompare.TabIndex = 0;
            // 
            // pointName
            // 
            this.pointName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pointName.DataPropertyName = "PointName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.pointName.DefaultCellStyle = dataGridViewCellStyle2;
            this.pointName.Frozen = true;
            this.pointName.HeaderText = "Punkt Name";
            this.pointName.Name = "pointName";
            this.pointName.ReadOnly = true;
            this.pointName.Width = 91;
            // 
            // ep1RW
            // 
            this.ep1RW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ep1RW.DataPropertyName = "SEp1RW";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ep1RW.DefaultCellStyle = dataGridViewCellStyle3;
            this.ep1RW.Frozen = true;
            this.ep1RW.HeaderText = "RW";
            this.ep1RW.Name = "ep1RW";
            this.ep1RW.ReadOnly = true;
            this.ep1RW.Width = 51;
            // 
            // ep1HW
            // 
            this.ep1HW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ep1HW.DataPropertyName = "SEp1HW";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ep1HW.DefaultCellStyle = dataGridViewCellStyle4;
            this.ep1HW.Frozen = true;
            this.ep1HW.HeaderText = "HW";
            this.ep1HW.Name = "ep1HW";
            this.ep1HW.ReadOnly = true;
            this.ep1HW.Width = 51;
            // 
            // ep1Z
            // 
            this.ep1Z.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ep1Z.DataPropertyName = "SEp1Z";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ep1Z.DefaultCellStyle = dataGridViewCellStyle5;
            this.ep1Z.Frozen = true;
            this.ep1Z.HeaderText = "Z";
            this.ep1Z.Name = "ep1Z";
            this.ep1Z.ReadOnly = true;
            this.ep1Z.Width = 39;
            // 
            // ep2RW
            // 
            this.ep2RW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ep2RW.DataPropertyName = "SEp2RW";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ep2RW.DefaultCellStyle = dataGridViewCellStyle6;
            this.ep2RW.Frozen = true;
            this.ep2RW.HeaderText = "RW";
            this.ep2RW.Name = "ep2RW";
            this.ep2RW.ReadOnly = true;
            this.ep2RW.Width = 51;
            // 
            // ep2HW
            // 
            this.ep2HW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ep2HW.DataPropertyName = "SEp2HW";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ep2HW.DefaultCellStyle = dataGridViewCellStyle7;
            this.ep2HW.Frozen = true;
            this.ep2HW.HeaderText = "HW";
            this.ep2HW.Name = "ep2HW";
            this.ep2HW.ReadOnly = true;
            this.ep2HW.Width = 51;
            // 
            // ep2Z
            // 
            this.ep2Z.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ep2Z.DataPropertyName = "SEp2Z";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ep2Z.DefaultCellStyle = dataGridViewCellStyle8;
            this.ep2Z.Frozen = true;
            this.ep2Z.HeaderText = "Z";
            this.ep2Z.Name = "ep2Z";
            this.ep2Z.ReadOnly = true;
            this.ep2Z.Width = 39;
            // 
            // deltaRW
            // 
            this.deltaRW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.deltaRW.DataPropertyName = "SDeltaRW";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.deltaRW.DefaultCellStyle = dataGridViewCellStyle9;
            this.deltaRW.Frozen = true;
            this.deltaRW.HeaderText = "Delta RW";
            this.deltaRW.Name = "deltaRW";
            this.deltaRW.ReadOnly = true;
            this.deltaRW.Width = 79;
            // 
            // deltaHW
            // 
            this.deltaHW.DataPropertyName = "SDeltaHW";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.deltaHW.DefaultCellStyle = dataGridViewCellStyle10;
            this.deltaHW.Frozen = true;
            this.deltaHW.HeaderText = "Delta HW";
            this.deltaHW.Name = "deltaHW";
            this.deltaHW.ReadOnly = true;
            this.deltaHW.Width = 79;
            // 
            // deltaZ
            // 
            this.deltaZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.deltaZ.DataPropertyName = "SDeltaZ";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.deltaZ.DefaultCellStyle = dataGridViewCellStyle11;
            this.deltaZ.Frozen = true;
            this.deltaZ.HeaderText = "Delta Z";
            this.deltaZ.Name = "deltaZ";
            this.deltaZ.ReadOnly = true;
            this.deltaZ.Width = 67;
            // 
            // delta2D
            // 
            this.delta2D.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.delta2D.DataPropertyName = "SDelta2D";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.delta2D.DefaultCellStyle = dataGridViewCellStyle12;
            this.delta2D.Frozen = true;
            this.delta2D.HeaderText = "Delta 2D";
            this.delta2D.Name = "delta2D";
            this.delta2D.ReadOnly = true;
            this.delta2D.Width = 74;
            // 
            // delta3D
            // 
            this.delta3D.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.delta3D.DataPropertyName = "SDelta3D";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.delta3D.DefaultCellStyle = dataGridViewCellStyle13;
            this.delta3D.Frozen = true;
            this.delta3D.HeaderText = "Delta 3D";
            this.delta3D.Name = "delta3D";
            this.delta3D.ReadOnly = true;
            this.delta3D.Width = 74;
            // 
            // deltaRiwi
            // 
            this.deltaRiwi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.deltaRiwi.DataPropertyName = "SDeltaRiwi";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.deltaRiwi.DefaultCellStyle = dataGridViewCellStyle14;
            this.deltaRiwi.Frozen = true;
            this.deltaRiwi.HeaderText = "Delta Riwi";
            this.deltaRiwi.Name = "deltaRiwi";
            this.deltaRiwi.ReadOnly = true;
            this.deltaRiwi.Width = 80;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMakeCompare);
            this.panel1.Controls.Add(this.btnChangeEpochen);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(467, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 50);
            this.panel1.TabIndex = 1;
            // 
            // btnMakeCompare
            // 
            this.btnMakeCompare.Location = new System.Drawing.Point(3, 3);
            this.btnMakeCompare.Name = "btnMakeCompare";
            this.btnMakeCompare.Size = new System.Drawing.Size(113, 44);
            this.btnMakeCompare.TabIndex = 2;
            this.btnMakeCompare.Text = "Vergleich durchführen";
            this.btnMakeCompare.UseVisualStyleBackColor = true;
            this.btnMakeCompare.Click += new System.EventHandler(this.btnMakeCompare_Click);
            // 
            // btnChangeEpochen
            // 
            this.btnChangeEpochen.Location = new System.Drawing.Point(122, 3);
            this.btnChangeEpochen.Name = "btnChangeEpochen";
            this.btnChangeEpochen.Size = new System.Drawing.Size(113, 44);
            this.btnChangeEpochen.TabIndex = 1;
            this.btnChangeEpochen.Text = "Epochen tauschen";
            this.btnChangeEpochen.UseVisualStyleBackColor = true;
            this.btnChangeEpochen.Click += new System.EventHandler(this.btnChangeEpochen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(241, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 44);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Vergleich beenden";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblEpoche1
            // 
            this.lblEpoche1.AutoSize = true;
            this.lblEpoche1.Location = new System.Drawing.Point(12, 9);
            this.lblEpoche1.Name = "lblEpoche1";
            this.lblEpoche1.Size = new System.Drawing.Size(96, 13);
            this.lblEpoche1.TabIndex = 2;
            this.lblEpoche1.Text = "Liste der Epoche 1";
            // 
            // lblEpoche2
            // 
            this.lblEpoche2.AutoSize = true;
            this.lblEpoche2.Location = new System.Drawing.Point(12, 36);
            this.lblEpoche2.Name = "lblEpoche2";
            this.lblEpoche2.Size = new System.Drawing.Size(96, 13);
            this.lblEpoche2.TabIndex = 3;
            this.lblEpoche2.Text = "Liste der Epoche 2";
            // 
            // cbList1
            // 
            this.cbList1.FormattingEnabled = true;
            this.cbList1.Location = new System.Drawing.Point(114, 6);
            this.cbList1.Name = "cbList1";
            this.cbList1.Size = new System.Drawing.Size(347, 21);
            this.cbList1.TabIndex = 4;
            // 
            // cbList2
            // 
            this.cbList2.FormattingEnabled = true;
            this.cbList2.Location = new System.Drawing.Point(114, 32);
            this.cbList2.Name = "cbList2";
            this.cbList2.Size = new System.Drawing.Size(347, 21);
            this.cbList2.TabIndex = 5;
            // 
            // frmCompareCoord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 161);
            this.Controls.Add(this.cbList2);
            this.Controls.Add(this.cbList1);
            this.Controls.Add(this.lblEpoche2);
            this.Controls.Add(this.lblEpoche1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvCompare);
            this.MinimumSize = new System.Drawing.Size(870, 200);
            this.Name = "frmCompareCoord";
            this.Text = "Koordinaten vergleichen";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompare)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dgvCompare;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblEpoche1;
        private System.Windows.Forms.Label lblEpoche2;
        private System.Windows.Forms.Button btnChangeEpochen;
        private System.Windows.Forms.ComboBox cbList1;
        private System.Windows.Forms.ComboBox cbList2;
        private System.Windows.Forms.Button btnMakeCompare;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ep1RW;
        private System.Windows.Forms.DataGridViewTextBoxColumn ep1HW;
        private System.Windows.Forms.DataGridViewTextBoxColumn ep1Z;
        private System.Windows.Forms.DataGridViewTextBoxColumn ep2RW;
        private System.Windows.Forms.DataGridViewTextBoxColumn ep2HW;
        private System.Windows.Forms.DataGridViewTextBoxColumn ep2Z;
        private System.Windows.Forms.DataGridViewTextBoxColumn deltaRW;
        private System.Windows.Forms.DataGridViewTextBoxColumn deltaHW;
        private System.Windows.Forms.DataGridViewTextBoxColumn deltaZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn delta2D;
        private System.Windows.Forms.DataGridViewTextBoxColumn delta3D;
        private System.Windows.Forms.DataGridViewTextBoxColumn deltaRiwi;
    }
}