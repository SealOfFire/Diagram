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

            this.table = table;
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

        #endregion

    }
}
