using Diagram.WindowsFormsApplication.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Diagram.WindowsFormsApplication.Controls
{
    /// <summary>
    /// 实体图标
    /// </summary>
    public partial class EntityChart : UserControl
    {
        private Point pt;
        private bool moves = true;
        private ItemChartCollection items;
        private DataFormat.TableEntity table = new DataFormat.TableEntity();

        private Canvas parent;

        public DataFormat.TableEntity Table { get { return this.table; } set { this.table = value; } }

        public EntityChart(Canvas parent, bool autoAdd = true)
        {
            this.InitializeComponent();
            this.parent = parent;
            if (autoAdd) this.parent.Tables.Add(this.table);
            this.items = new ItemChartCollection(this);
        }

        public void SetForm()
        {
            this.lblTableName.Text = this.table.PhysicsName;
            // 清除其他内容
            this.pnlColumns.Controls.Clear();
            this.pnlColumns.RowCount = this.table.Columns.Count;
            for (int i = 0; i < this.items.Count; i++)
            {
                this.pnlColumns.Controls.Add(this.items[i], 0, i);
            }
        }

        public ItemChart AddItem()
        {
            ItemChart item = new ItemChart(this, this.table.AddColumnEntity());
            this.items.Add(item);
            return item;
        }

        #region xml

        public XmlElement SaveUI(XmlDocument document)
        {
            XmlElement ele = document.CreateElement("Table");
            //
            XmlAttribute att0 = document.CreateAttribute("Identity");
            att0.Value = table.Identity.ToString();
            ele.Attributes.Append(att0);
            //
            XmlAttribute att1 = document.CreateAttribute("Location");
            att1.Value = this.Location.X + "," + this.Location.Y;
            ele.Attributes.Append(att1);
            return ele;
        }

        public static EntityChart LoadUI(Canvas parent, XmlNode node, out Guid identity)
        {
            EntityChart table = new EntityChart(parent, false);
            int x = 0;
            int y = 0;
            string[] value = node.Attributes["Location"].Value.Split(',');
            if (value.Length >= 0) int.TryParse(value[0], out x);
            if (value.Length >= 1) int.TryParse(value[1], out y);
            table.Location = new Point(x, y);
            identity = Guid.Parse(node.Attributes["Identity"].Value);
            return table;
        }

        #endregion

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
            new TableEdit(this).ShowDialog();
            this.SetForm();
        }

        #endregion

        private void menuDeleteTable_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否删除表?", "删除确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.parent.removeTable(this);
            }
        }
    }
}
