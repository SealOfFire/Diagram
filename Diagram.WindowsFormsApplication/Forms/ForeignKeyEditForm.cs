using Diagram.WindowsFormsApplication.Controls;
using System;
using System.Collections;
using System.Windows.Forms;

namespace Diagram.WindowsFormsApplication.Forms
{
    /// <summary>
    /// 外键扁家窗口
    /// </summary>
    public partial class ForeignKeyEditForm : Form
    {
        private Canvas cancvas;

        public ForeignKeyEditForm(Canvas cancvas)
        {
            InitializeComponent();
            this.cancvas = cancvas;
            this.InitializeComboBox();
        }

        /// <summary>
        /// 初始化下拉框
        /// </summary>
        public void InitializeComboBox()
        {
            //
            this.cmbTableFrom.Items.Clear();
            // this.cmbTableFrom.DataSource = cancvas.Tables;
            //
            this.cmdTableTo.Items.Clear();
            // this.cmdTableTo.DataSource = cancvas.Tables;

            foreach (DataFormat.TableEntity table in cancvas.Tables)
            {
                this.cmbTableFrom.Items.Add(new DictionaryEntry(table.Identity, table.PhysicsName));
                this.cmdTableTo.Items.Add(new DictionaryEntry(table.PhysicsName, table.Identity));
            }
        }

        #region 事件

        private void btnSave_Click(object sender, System.EventArgs e)
        {
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
                    foreach (DataFormat.ColumnEntity col in table.Columns)
                    {
                        this.cmbColumnFrom.Items.Add(col.PhysicsName);
                    }
                }

                if (cmb.Name == this.cmdTableTo.Name)
                {
                    foreach (DataFormat.ColumnEntity col in table.Columns)
                    {
                        this.cmbColumnTo.Items.Add(col.PhysicsName);
                    }
                }
            }
        }

        #endregion

    }
}
