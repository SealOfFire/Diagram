using Diagram.WindowsFormsApplication.Controls;
using System.Windows.Forms;

namespace Diagram.WindowsFormsApplication.Forms
{
    /// <summary>
    /// 编辑表画面
    /// </summary>
    public partial class TableEdit : Form
    {
        private EntityChart entity;

        public TableEdit(EntityChart entity)
        {
            InitializeComponent();
            this.gvColumnList.AutoGenerateColumns = false;
            this.entity = entity;
            this.SetForm();
        }

        private void SetForm()
        {
            this.txtConceptName.Text = this.entity.Table.ConceptName;
            this.txtPhysicsName.Text = this.entity.Table.PhysicsName;
            this.txtAnnotation.Text = this.entity.Table.Annotation;
            this.gvColumnList.DataSource = this.entity.Table.Columns;
        }

        private void GetForm()
        {
            this.entity.Table.ConceptName = this.txtConceptName.Text;
            this.entity.Table.PhysicsName = this.txtPhysicsName.Text;
            this.entity.Table.Annotation = this.txtAnnotation.Text;
            this.entity.Table.SetPrimaryKeyColumnsFromColumn();
        }

        #region 事件

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            this.GetForm();
            this.Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void menuAddColumn_Click(object sender, System.EventArgs e)
        {
            //this.table.AddColumnEntity();
            this.entity.AddItem();
            this.gvColumnList.DataSource = null;
            this.gvColumnList.DataSource = this.entity.Table.Columns;
        }

        private void menuDelColumn_Click(object sender, System.EventArgs e)
        {

        }

        #endregion

        private void gvColumnList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.GetForm();
        }

    }
}
