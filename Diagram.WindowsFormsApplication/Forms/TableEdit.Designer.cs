namespace Diagram.WindowsFormsApplication.Forms
{
    partial class TableEdit
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
            this.lblPhysicsName = new System.Windows.Forms.Label();
            this.txtPhysicsName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConceptName = new System.Windows.Forms.TextBox();
            this.gvColumnList = new System.Windows.Forms.DataGridView();
            this.pk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数据类型 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.注视 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAnnotation = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvColumnList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPhysicsName
            // 
            this.lblPhysicsName.AutoSize = true;
            this.lblPhysicsName.Location = new System.Drawing.Point(26, 13);
            this.lblPhysicsName.Name = "lblPhysicsName";
            this.lblPhysicsName.Size = new System.Drawing.Size(53, 12);
            this.lblPhysicsName.TabIndex = 0;
            this.lblPhysicsName.Text = "物理名称";
            // 
            // txtPhysicsName
            // 
            this.txtPhysicsName.Location = new System.Drawing.Point(85, 10);
            this.txtPhysicsName.Name = "txtPhysicsName";
            this.txtPhysicsName.Size = new System.Drawing.Size(168, 21);
            this.txtPhysicsName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "概念名称";
            // 
            // txtConceptName
            // 
            this.txtConceptName.Location = new System.Drawing.Point(356, 10);
            this.txtConceptName.Name = "txtConceptName";
            this.txtConceptName.Size = new System.Drawing.Size(172, 21);
            this.txtConceptName.TabIndex = 3;
            // 
            // gvColumnList
            // 
            this.gvColumnList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvColumnList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvColumnList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pk,
            this.fk,
            this.ColumnName,
            this.数据类型,
            this.length,
            this.Column2,
            this.Column1,
            this.注视});
            this.gvColumnList.ContextMenuStrip = this.contextMenuStrip1;
            this.gvColumnList.Location = new System.Drawing.Point(12, 129);
            this.gvColumnList.MultiSelect = false;
            this.gvColumnList.Name = "gvColumnList";
            this.gvColumnList.RowHeadersVisible = false;
            this.gvColumnList.RowTemplate.Height = 23;
            this.gvColumnList.Size = new System.Drawing.Size(631, 261);
            this.gvColumnList.TabIndex = 4;
            this.gvColumnList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvColumnList_CellContentClick);
            // 
            // pk
            // 
            this.pk.DataPropertyName = "PrimaryKey";
            this.pk.HeaderText = "PK";
            this.pk.Name = "pk";
            this.pk.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.pk.Width = 25;
            // 
            // fk
            // 
            this.fk.HeaderText = "FK";
            this.fk.Name = "fk";
            this.fk.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.fk.Width = 25;
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "PhysicsName";
            this.ColumnName.HeaderText = "列名";
            this.ColumnName.Name = "ColumnName";
            // 
            // 数据类型
            // 
            this.数据类型.DataPropertyName = "DataType";
            this.数据类型.HeaderText = "数据类型";
            this.数据类型.Items.AddRange(new object[] {
            "uniqueidentifier",
            "int",
            "char",
            "nvarchar",
            "dateTime"});
            this.数据类型.Name = "数据类型";
            this.数据类型.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.数据类型.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // length
            // 
            this.length.DataPropertyName = "Length";
            this.length.HeaderText = "长度";
            this.length.Name = "length";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "AllowNulls";
            this.Column2.HeaderText = "空";
            this.Column2.Name = "Column2";
            this.Column2.Width = 25;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "DefaultValue";
            this.Column1.HeaderText = "默认值 ";
            this.Column1.Name = "Column1";
            // 
            // 注视
            // 
            this.注视.DataPropertyName = "Annotation";
            this.注视.HeaderText = "注释";
            this.注视.Name = "注视";
            this.注视.Width = 200;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddColumn,
            this.menuDelColumn});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(162, 48);
            // 
            // menuAddColumn
            // 
            this.menuAddColumn.Name = "menuAddColumn";
            this.menuAddColumn.Size = new System.Drawing.Size(161, 22);
            this.menuAddColumn.Text = "Add Column";
            this.menuAddColumn.Click += new System.EventHandler(this.menuAddColumn_Click);
            // 
            // menuDelColumn
            // 
            this.menuDelColumn.Name = "menuDelColumn";
            this.menuDelColumn.Size = new System.Drawing.Size(161, 22);
            this.menuDelColumn.Text = "Delete Column";
            this.menuDelColumn.Click += new System.EventHandler(this.menuDelColumn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "注视";
            // 
            // txtAnnotation
            // 
            this.txtAnnotation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnnotation.Location = new System.Drawing.Point(85, 43);
            this.txtAnnotation.Multiline = true;
            this.txtAnnotation.Name = "txtAnnotation";
            this.txtAnnotation.Size = new System.Drawing.Size(443, 69);
            this.txtAnnotation.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(487, 396);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(568, 396);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // TableEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 431);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAnnotation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gvColumnList);
            this.Controls.Add(this.txtConceptName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPhysicsName);
            this.Controls.Add(this.lblPhysicsName);
            this.Name = "TableEdit";
            this.Text = "TableEdit";
            ((System.ComponentModel.ISupportInitialize)(this.gvColumnList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPhysicsName;
        private System.Windows.Forms.TextBox txtPhysicsName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConceptName;
        private System.Windows.Forms.DataGridView gvColumnList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAnnotation;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuAddColumn;
        private System.Windows.Forms.ToolStripMenuItem menuDelColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pk;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fk;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewComboBoxColumn 数据类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn length;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 注视;
    }
}