using Diagram.WindowsFormsApplication.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Diagram.WindowsFormsApplication.Controls
{
    /// <summary>
    /// 表
    /// </summary>
    public partial class TableEntity : UserControl
    {
        private Point pt;
        private bool moves = true;
        private DataFormat.TableEntity table = new DataFormat.TableEntity();

        private ContextMenu contextMenu;
        private MenuItem menuItemDeleteTableEntity;

        public DataFormat.TableEntity GetTable()
        {
            return this.table;
        }

        public TableEntity()
        {
            this.InitializeComponent();
            this.InitializeContextMenu();
        }

        private void InitializeContextMenu()
        {
            //
            this.menuItemDeleteTableEntity = new MenuItem();
            this.menuItemDeleteTableEntity.Text = "Delete table";
            this.menuItemDeleteTableEntity.Click += new System.EventHandler(menuItemDeleteTableEntity_Click);
            //
            this.contextMenu = new ContextMenu();
            this.contextMenu.MenuItems.Add(this.menuItemDeleteTableEntity);
            this.ContextMenu = this.contextMenu;
        }

        public void SetForm()
        {
            this.lblTableName.Text = this.table.PhysicsName;
            // 清除其他内容
            this.pnlColumns.Controls.Clear();
            foreach (DataFormat.ColumnEntity column in this.table.Columns)
            {
                // 添加项目
                Label lbl = new Label();
                lbl.Text = column.ToString();
                this.pnlColumns.Controls.Clear();
            }
        }

        #region lblTableName事件

        private void lblTableName_MouseDown(object sender, MouseEventArgs e)
        {
            this.pt = Cursor.Position;
        }

        private void lblTableName_MouseUp(object sender, MouseEventArgs e)
        {
            this.moves = true;
        }

        private void lblTableName_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int px = Cursor.Position.X - pt.X;
                int py = Cursor.Position.Y - pt.Y;
                this.Location = new Point(this.Location.X + px, this.Location.Y + py);
                pt = Cursor.Position;
                moves = false;
            }
        }

        private void lblTableName_DoubleClick(object sender, EventArgs e)
        {
            new TableEdit(this.table).ShowDialog();
            this.SetForm();
        }

        #endregion

        private void menuItemDeleteTableEntity_Click(object sender, EventArgs e)
        {

        }

    }
}
