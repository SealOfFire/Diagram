using Diagram.WindowsFormsApplication.Controls;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace Diagram.WindowsFormsApplication.Forms
{
    /// <summary>
    /// 外键扁家窗口
    /// </summary>
    public partial class ForeignKeyEditForm : Form
    {
        #region 字段

        private Canvas cancvas;
        private DataTable soruceTableFrom;
        private DataTable soruceTableTo;
        private DataTable soruceColumnFrom;
        private DataTable soruceColumnTo;
        private DataTable[] soruceTables;

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancvas"></param>
        public ForeignKeyEditForm(Canvas cancvas)
        {
            InitializeComponent();
            this.cancvas = cancvas;
            this.InitializeDataTable();
            this.InitializeComboBox();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 
        /// </summary>
        public void InitializeDataTable()
        {
            this.soruceTableFrom = new DataTable();
            this.soruceTableTo = new DataTable();
            this.soruceColumnFrom = new DataTable();
            this.soruceColumnTo = new DataTable();
            this.soruceTables = new DataTable[4];
            this.soruceTables[0] = this.soruceTableFrom;
            this.soruceTables[1] = this.soruceTableTo;
            this.soruceTables[2] = this.soruceColumnFrom;
            this.soruceTables[3] = this.soruceColumnTo;
            foreach (DataTable dt in this.soruceTables)
            {
                dt.Columns.Add(new DataColumn("value"));
                dt.Columns.Add(new DataColumn("display"));
            }
        }

        /// <summary>
        /// 初始化下拉框
        /// </summary>
        public void InitializeComboBox()
        {
            //
            foreach (DataFormat.TableEntity table in cancvas.Tables)
            {
                this.soruceTableFrom.Rows.Add(table.Identity, table.PhysicsName);
                this.soruceTableTo.Rows.Add(table.Identity, table.PhysicsName);
            }
            //
            this.cmbTableFrom.DataSource = this.soruceTableFrom;
            this.cmbTableFrom.DisplayMember = "display";
            this.cmbTableFrom.ValueMember = "value";
            // this.cmbTableFrom.SelectedIndex = 0;
            //
            this.cmdTableTo.DataSource = this.soruceTableTo;
            this.cmdTableTo.DisplayMember = "display";
            this.cmdTableTo.ValueMember = "value";
            // this.cmdTableTo.SelectedIndex = 0;
            //
            this.cmbColumnFrom.DataSource = this.soruceColumnFrom;
            this.cmbColumnFrom.DisplayMember = "display";
            this.cmbColumnFrom.ValueMember = "value";
            //
            this.cmbColumnTo.DataSource = this.soruceColumnTo;
            this.cmbColumnTo.DisplayMember = "display";
            this.cmbColumnTo.ValueMember = "value";
        }

        #endregion

        #region 事件

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            // 获取选中的项目
            Guid fromID = Guid.Empty, toID = Guid.Empty, colFromID, colToID;
            Guid.TryParse(this.cmbTableFrom.SelectedValue.ToString(), out fromID);
            Guid.TryParse(this.cmbTableFrom.SelectedValue.ToString(), out toID);
            Guid.TryParse(this.cmbColumnFrom.SelectedValue.ToString(), out colFromID);
            Guid.TryParse(this.cmbColumnTo.SelectedValue.ToString(), out colToID);
            // this.cancvas.AddForeignKey(this.cancvas.Tables[fromID].Columns[colFromID], this.cancvas.Tables[toID].Columns[colToID]);
            this.Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void ComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (sender is ComboBox)
            {
                ComboBox cmb = sender as ComboBox;
                Guid id = Guid.Empty;
                Guid.TryParse(cmb.SelectedValue == null ? string.Empty : cmb.SelectedValue.ToString(), out id);
                DataFormat.TableEntity table = this.cancvas.Tables[id];
                if (table == null)
                    return;

                if (cmb.Name == this.cmbTableFrom.Name)
                {
                    this.soruceColumnFrom.Clear();
                    foreach (DataFormat.ColumnEntity col in table.Columns) this.soruceColumnFrom.Rows.Add(col.Identity, col.PhysicsName);
                }

                if (cmb.Name == this.cmdTableTo.Name)
                {
                    this.soruceColumnTo.Clear();
                    foreach (DataFormat.ColumnEntity col in table.Columns) this.soruceColumnTo.Rows.Add(col.Identity, col.PhysicsName);
                }
            }
        }

        #endregion
    }
}
