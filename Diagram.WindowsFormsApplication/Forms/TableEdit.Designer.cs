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
            this.lblPhysicsName = new System.Windows.Forms.Label();
            this.txtPhysicsName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConceptName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(500, 150);
            this.dataGridView1.TabIndex = 4;
            // 
            // TableEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 262);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtConceptName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPhysicsName);
            this.Controls.Add(this.lblPhysicsName);
            this.Name = "TableEdit";
            this.Text = "TableEdit";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPhysicsName;
        private System.Windows.Forms.TextBox txtPhysicsName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConceptName;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}