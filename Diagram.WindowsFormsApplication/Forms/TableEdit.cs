using System.Windows.Forms;

namespace Diagram.WindowsFormsApplication.Forms
{
    /// <summary>
    /// 编辑表画面
    /// </summary>
    public partial class TableEdit : Form
    {
        private DataFormat.TableEntity table;

        public TableEdit(DataFormat.TableEntity table)
        {
            InitializeComponent();
            this.gvColumnList.AutoGenerateColumns = false;
            this.table = table;
            //this.table.AddColumnEntity();
            this.SetForm();
        }

        private void SetForm()
        {
            this.txtConceptName.Text = this.table.ConceptName;
            this.txtPhysicsName.Text = this.table.PhysicsName;
            this.txtAnnotation.Text = this.table.Annotation;
            this.gvColumnList.DataSource = this.table.Columns;
        }

        private void GetForm()
        {
            this.table.ConceptName = this.txtConceptName.Text;
            this.table.PhysicsName = this.txtPhysicsName.Text;
            this.table.Annotation = this.txtAnnotation.Text;
            this.table.SetPrimaryKeyColumnsFromColumn();
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
            this.table.AddColumnEntity();
            this.gvColumnList.DataSource = null;
            this.gvColumnList.DataSource = this.table.Columns;
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
