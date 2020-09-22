namespace org.rosenbohm.csharp.CADdyTools.Forms
{
    partial class frmTransformCoord
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dgvTransformation = new System.Windows.Forms.DataGridView();
            this.pointName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SrcRW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SrcHW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SrcZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deltaRW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deltaHW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deltaZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DstRW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DstHW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DstZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usePoint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.useZ = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChangeSrcDest = new System.Windows.Forms.Button();
            this.btnCalcTransform = new System.Windows.Forms.Button();
            this.btnMakeTransform = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblSrc = new System.Windows.Forms.Label();
            this.lblDest = new System.Windows.Forms.Label();
            this.cbListSrc = new System.Windows.Forms.ComboBox();
            this.cbListDest = new System.Windows.Forms.ComboBox();
            this.lblSigmaXY = new System.Windows.Forms.Label();
            this.tbSigmaXY = new System.Windows.Forms.TextBox();
            this.tbSigmaZ = new System.Windows.Forms.TextBox();
            this.lblSigmaZ = new System.Windows.Forms.Label();
            this.cbNewPointsNewTab = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransformation)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTransformation
            // 
            this.dgvTransformation.AllowUserToAddRows = false;
            this.dgvTransformation.AllowUserToDeleteRows = false;
            this.dgvTransformation.AllowUserToOrderColumns = true;
            this.dgvTransformation.AllowUserToResizeRows = false;
            this.dgvTransformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransformation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTransformation.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransformation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pointName,
            this.SrcRW,
            this.SrcHW,
            this.SrcZ,
            this.deltaRW,
            this.deltaHW,
            this.deltaZ,
            this.DstRW,
            this.DstHW,
            this.DstZ,
            this.usePoint,
            this.useZ});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransformation.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvTransformation.Location = new System.Drawing.Point(0, 86);
            this.dgvTransformation.Name = "dgvTransformation";
            this.dgvTransformation.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransformation.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvTransformation.RowHeadersVisible = false;
            this.dgvTransformation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransformation.ShowCellErrors = false;
            this.dgvTransformation.ShowCellToolTips = false;
            this.dgvTransformation.ShowEditingIcon = false;
            this.dgvTransformation.ShowRowErrors = false;
            this.dgvTransformation.Size = new System.Drawing.Size(864, 129);
            this.dgvTransformation.TabIndex = 0;
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
            this.pointName.Width = 91;
            // 
            // SrcRW
            // 
            this.SrcRW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SrcRW.DataPropertyName = "SSrcRW";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SrcRW.DefaultCellStyle = dataGridViewCellStyle3;
            this.SrcRW.HeaderText = "RW";
            this.SrcRW.Name = "SrcRW";
            this.SrcRW.Width = 51;
            // 
            // SrcHW
            // 
            this.SrcHW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SrcHW.DataPropertyName = "SSrcHW";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SrcHW.DefaultCellStyle = dataGridViewCellStyle4;
            this.SrcHW.HeaderText = "HW";
            this.SrcHW.Name = "SrcHW";
            this.SrcHW.Width = 51;
            // 
            // SrcZ
            // 
            this.SrcZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SrcZ.DataPropertyName = "SSrcZ";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SrcZ.DefaultCellStyle = dataGridViewCellStyle5;
            this.SrcZ.HeaderText = "Z";
            this.SrcZ.Name = "SrcZ";
            this.SrcZ.Width = 39;
            // 
            // deltaRW
            // 
            this.deltaRW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.deltaRW.DataPropertyName = "SDeltaRW";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.deltaRW.DefaultCellStyle = dataGridViewCellStyle6;
            this.deltaRW.HeaderText = "Delta RW";
            this.deltaRW.Name = "deltaRW";
            this.deltaRW.Width = 79;
            // 
            // deltaHW
            // 
            this.deltaHW.DataPropertyName = "SDeltaHW";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.deltaHW.DefaultCellStyle = dataGridViewCellStyle7;
            this.deltaHW.HeaderText = "Delta HW";
            this.deltaHW.Name = "deltaHW";
            this.deltaHW.Width = 79;
            // 
            // deltaZ
            // 
            this.deltaZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.deltaZ.DataPropertyName = "SDeltaZ";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.deltaZ.DefaultCellStyle = dataGridViewCellStyle8;
            this.deltaZ.HeaderText = "Delta Z";
            this.deltaZ.Name = "deltaZ";
            this.deltaZ.Width = 67;
            // 
            // DstRW
            // 
            this.DstRW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DstRW.DataPropertyName = "SDesRW";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DstRW.DefaultCellStyle = dataGridViewCellStyle9;
            this.DstRW.HeaderText = "RW";
            this.DstRW.Name = "DstRW";
            this.DstRW.Width = 51;
            // 
            // DstHW
            // 
            this.DstHW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DstHW.DataPropertyName = "SDesHW";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DstHW.DefaultCellStyle = dataGridViewCellStyle10;
            this.DstHW.HeaderText = "HW";
            this.DstHW.Name = "DstHW";
            this.DstHW.Width = 51;
            // 
            // DstZ
            // 
            this.DstZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DstZ.DataPropertyName = "SDesZ";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DstZ.DefaultCellStyle = dataGridViewCellStyle11;
            this.DstZ.HeaderText = "Z";
            this.DstZ.Name = "DstZ";
            this.DstZ.Width = 39;
            // 
            // usePoint
            // 
            this.usePoint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.usePoint.DataPropertyName = "BUsePoint";
            this.usePoint.FalseValue = "false";
            this.usePoint.HeaderText = "nutze Punkt";
            this.usePoint.Name = "usePoint";
            this.usePoint.TrueValue = "true";
            this.usePoint.Width = 70;
            // 
            // useZ
            // 
            this.useZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.useZ.DataPropertyName = "BUseZ";
            this.useZ.FalseValue = "false";
            this.useZ.HeaderText = "nutze Z";
            this.useZ.Name = "useZ";
            this.useZ.TrueValue = "true";
            this.useZ.Width = 49;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnChangeSrcDest);
            this.panel1.Controls.Add(this.btnCalcTransform);
            this.panel1.Controls.Add(this.btnMakeTransform);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(467, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 50);
            this.panel1.TabIndex = 1;
            // 
            // btnChangeSrcDest
            // 
            this.btnChangeSrcDest.Location = new System.Drawing.Point(3, 3);
            this.btnChangeSrcDest.Name = "btnChangeSrcDest";
            this.btnChangeSrcDest.Size = new System.Drawing.Size(95, 44);
            this.btnChangeSrcDest.TabIndex = 3;
            this.btnChangeSrcDest.Text = "Quelle <> Ziel";
            this.btnChangeSrcDest.UseVisualStyleBackColor = true;
            this.btnChangeSrcDest.Click += new System.EventHandler(this.btnChangeSrcDest_Click);
            // 
            // btnCalcTransform
            // 
            this.btnCalcTransform.Location = new System.Drawing.Point(104, 3);
            this.btnCalcTransform.Name = "btnCalcTransform";
            this.btnCalcTransform.Size = new System.Drawing.Size(93, 44);
            this.btnCalcTransform.TabIndex = 2;
            this.btnCalcTransform.Text = "Transformation aktualisieren";
            this.btnCalcTransform.UseVisualStyleBackColor = true;
            this.btnCalcTransform.Click += new System.EventHandler(this.btnCalcTransform_Click);
            // 
            // btnMakeTransform
            // 
            this.btnMakeTransform.Location = new System.Drawing.Point(203, 3);
            this.btnMakeTransform.Name = "btnMakeTransform";
            this.btnMakeTransform.Size = new System.Drawing.Size(87, 44);
            this.btnMakeTransform.TabIndex = 1;
            this.btnMakeTransform.Text = "Neupunkte transformieren";
            this.btnMakeTransform.UseVisualStyleBackColor = true;
            this.btnMakeTransform.Click += new System.EventHandler(this.btnMakeTransform_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(296, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 44);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "schließen";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblSrc
            // 
            this.lblSrc.Location = new System.Drawing.Point(12, 9);
            this.lblSrc.Name = "lblSrc";
            this.lblSrc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSrc.Size = new System.Drawing.Size(96, 18);
            this.lblSrc.TabIndex = 2;
            this.lblSrc.Text = "Liste der Quelle";
            this.lblSrc.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDest
            // 
            this.lblDest.Location = new System.Drawing.Point(12, 36);
            this.lblDest.Name = "lblDest";
            this.lblDest.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDest.Size = new System.Drawing.Size(96, 16);
            this.lblDest.TabIndex = 3;
            this.lblDest.Text = "Liste des Ziel";
            this.lblDest.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbListSrc
            // 
            this.cbListSrc.FormattingEnabled = true;
            this.cbListSrc.Location = new System.Drawing.Point(114, 6);
            this.cbListSrc.Name = "cbListSrc";
            this.cbListSrc.Size = new System.Drawing.Size(347, 21);
            this.cbListSrc.TabIndex = 4;
            this.cbListSrc.SelectedIndexChanged += new System.EventHandler(this.cbListSrc_SelectedIndexChanged);
            // 
            // cbListDest
            // 
            this.cbListDest.FormattingEnabled = true;
            this.cbListDest.Location = new System.Drawing.Point(114, 32);
            this.cbListDest.Name = "cbListDest";
            this.cbListDest.Size = new System.Drawing.Size(347, 21);
            this.cbListDest.TabIndex = 5;
            this.cbListDest.SelectedIndexChanged += new System.EventHandler(this.cbListSrc_SelectedIndexChanged);
            // 
            // lblSigmaXY
            // 
            this.lblSigmaXY.Location = new System.Drawing.Point(12, 63);
            this.lblSigmaXY.Name = "lblSigmaXY";
            this.lblSigmaXY.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSigmaXY.Size = new System.Drawing.Size(96, 13);
            this.lblSigmaXY.TabIndex = 6;
            this.lblSigmaXY.Text = "Sigma X Y";
            this.lblSigmaXY.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbSigmaXY
            // 
            this.tbSigmaXY.Location = new System.Drawing.Point(114, 60);
            this.tbSigmaXY.Name = "tbSigmaXY";
            this.tbSigmaXY.Size = new System.Drawing.Size(100, 20);
            this.tbSigmaXY.TabIndex = 7;
            // 
            // tbSigmaZ
            // 
            this.tbSigmaZ.Location = new System.Drawing.Point(361, 60);
            this.tbSigmaZ.Name = "tbSigmaZ";
            this.tbSigmaZ.Size = new System.Drawing.Size(100, 20);
            this.tbSigmaZ.TabIndex = 9;
            // 
            // lblSigmaZ
            // 
            this.lblSigmaZ.Location = new System.Drawing.Point(259, 63);
            this.lblSigmaZ.Name = "lblSigmaZ";
            this.lblSigmaZ.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSigmaZ.Size = new System.Drawing.Size(96, 17);
            this.lblSigmaZ.TabIndex = 8;
            this.lblSigmaZ.Text = "Sigma Z";
            this.lblSigmaZ.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbNewPointsNewTab
            // 
            this.cbNewPointsNewTab.AutoSize = true;
            this.cbNewPointsNewTab.Checked = true;
            this.cbNewPointsNewTab.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNewPointsNewTab.Location = new System.Drawing.Point(589, 62);
            this.cbNewPointsNewTab.Name = "cbNewPointsNewTab";
            this.cbNewPointsNewTab.Size = new System.Drawing.Size(145, 17);
            this.cbNewPointsNewTab.TabIndex = 10;
            this.cbNewPointsNewTab.Text = "Neupunkte in neuen Tab";
            this.cbNewPointsNewTab.UseVisualStyleBackColor = true;
            // 
            // frmTransformCoord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 217);
            this.Controls.Add(this.cbNewPointsNewTab);
            this.Controls.Add(this.tbSigmaZ);
            this.Controls.Add(this.lblSigmaZ);
            this.Controls.Add(this.tbSigmaXY);
            this.Controls.Add(this.lblSigmaXY);
            this.Controls.Add(this.cbListDest);
            this.Controls.Add(this.cbListSrc);
            this.Controls.Add(this.lblDest);
            this.Controls.Add(this.lblSrc);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvTransformation);
            this.Name = "frmTransformCoord";
            this.Text = "Koordinaten Transformieren";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransformation)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSrc;
        private System.Windows.Forms.Label lblDest;
        private System.Windows.Forms.Button btnMakeTransform;
        private System.Windows.Forms.ComboBox cbListSrc;
        private System.Windows.Forms.ComboBox cbListDest;
        private System.Windows.Forms.Button btnCalcTransform;
        private System.Windows.Forms.Label lblSigmaXY;
        private System.Windows.Forms.TextBox tbSigmaXY;
        private System.Windows.Forms.TextBox tbSigmaZ;
        private System.Windows.Forms.Label lblSigmaZ;
        private System.Windows.Forms.CheckBox cbNewPointsNewTab;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrcRW;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrcHW;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrcZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn deltaRW;
        private System.Windows.Forms.DataGridViewTextBoxColumn deltaHW;
        private System.Windows.Forms.DataGridViewTextBoxColumn deltaZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn DstRW;
        private System.Windows.Forms.DataGridViewTextBoxColumn DstHW;
        private System.Windows.Forms.DataGridViewTextBoxColumn DstZ;
        private System.Windows.Forms.DataGridViewCheckBoxColumn usePoint;
        private System.Windows.Forms.DataGridViewCheckBoxColumn useZ;
        private System.Windows.Forms.DataGridView dgvTransformation;
        private System.Windows.Forms.Button btnChangeSrcDest;
    }
}