using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram.WindowsFormsApplication.Controls
{
    /// <summary>
    /// 表
    /// </summary>
    partial class TableEntity
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlColumns = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTableName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlColumns
            // 
            this.pnlColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlColumns.AutoSize = true;
            this.pnlColumns.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlColumns.Location = new System.Drawing.Point(3, 31);
            this.pnlColumns.Margin = new System.Windows.Forms.Padding(0);
            this.pnlColumns.Name = "pnlColumns";
            this.pnlColumns.Size = new System.Drawing.Size(124, 20);
            this.pnlColumns.TabIndex = 0;
            // 
            // lblTableName
            // 
            this.lblTableName.BackColor = System.Drawing.Color.Silver;
            this.lblTableName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTableName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTableName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTableName.ForeColor = System.Drawing.Color.Blue;
            this.lblTableName.Location = new System.Drawing.Point(0, 0);
            this.lblTableName.Margin = new System.Windows.Forms.Padding(0);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(131, 28);
            this.lblTableName.TabIndex = 1;
            this.lblTableName.Text = "table name";
            this.lblTableName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTableName.DoubleClick += new System.EventHandler(this.lblTableName_DoubleClick);
            this.lblTableName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTableName_MouseDown);
            this.lblTableName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTableName_MouseMove);
            this.lblTableName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTableName_MouseUp);
            // 
            // TableEntity
            // 
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblTableName);
            this.Controls.Add(this.pnlColumns);
            this.Name = "TableEntity";
            this.Size = new System.Drawing.Size(131, 57);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlColumns;
        private System.Windows.Forms.Label lblTableName;
    }
}
