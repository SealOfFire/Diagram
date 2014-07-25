namespace Diagram.WindowsFormsApplication.Controls
{
    partial class Canvas
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
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddTable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddForeignKey = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddTable,
            this.menuAddForeignKey});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(173, 48);
            // 
            // menuAddTable
            // 
            this.menuAddTable.Name = "menuAddTable";
            this.menuAddTable.Size = new System.Drawing.Size(172, 22);
            this.menuAddTable.Text = "Add Table";
            this.menuAddTable.Click += new System.EventHandler(this.menuAddTable_Click);
            // 
            // menuAddForeignKey
            // 
            this.menuAddForeignKey.Name = "menuAddForeignKey";
            this.menuAddForeignKey.Size = new System.Drawing.Size(172, 22);
            this.menuAddForeignKey.Text = "Add Foreign key";
            this.menuAddForeignKey.Click += new System.EventHandler(this.menuAddForeignKey_Click);
            // 
            // Canvas
            // 
            this.AllowDrop = true;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuAddTable;
        private System.Windows.Forms.ToolStripMenuItem menuAddForeignKey;
    }
}
