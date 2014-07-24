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
            this.components = new System.ComponentModel.Container();
            this.lblTableName = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuDeleteTable = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlColumns = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
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
            this.lblTableName.Size = new System.Drawing.Size(214, 28);
            this.lblTableName.TabIndex = 1;
            this.lblTableName.Text = "table name";
            this.lblTableName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTableName.DoubleClick += new System.EventHandler(this.lblTableName_DoubleClick);
            this.lblTableName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTableName_MouseDown);
            this.lblTableName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTableName_MouseMove);
            this.lblTableName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTableName_MouseUp);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDeleteTable});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(150, 26);
            // 
            // menuDeleteTable
            // 
            this.menuDeleteTable.Name = "menuDeleteTable";
            this.menuDeleteTable.Size = new System.Drawing.Size(149, 22);
            this.menuDeleteTable.Text = "Delete Table";
            this.menuDeleteTable.Click += new System.EventHandler(this.menuDeleteTable_Click);
            // 
            // pnlColumns
            // 
            this.pnlColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlColumns.AutoSize = true;
            this.pnlColumns.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlColumns.ColumnCount = 1;
            this.pnlColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlColumns.Location = new System.Drawing.Point(3, 31);
            this.pnlColumns.Name = "pnlColumns";
            this.pnlColumns.RowCount = 1;
            this.pnlColumns.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlColumns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlColumns.Size = new System.Drawing.Size(208, 0);
            this.pnlColumns.TabIndex = 2;
            // 
            // TableEntity
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.pnlColumns);
            this.Controls.Add(this.lblTableName);
            this.Name = "TableEntity";
            this.Size = new System.Drawing.Size(214, 34);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteTable;
        private System.Windows.Forms.TableLayoutPanel pnlColumns;
    }
}
