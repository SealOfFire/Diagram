using DataFormat;
using System.Windows.Forms;

namespace Diagram.WindowsFormsApplication.Controls
{
    public partial class Canvas : Panel
    {
        private TableCollection tables = new TableCollection();

        public Canvas()
        {
            InitializeComponent();
        }

        #region 方法

        public void LoadData(string path)
        {

        }

        public void Save(string path)
        {

        }

        #endregion

        #region 事件

        private void Canvas_DragDrop(object sender, DragEventArgs e)
        {
            MessageBox.Show("1");
        }

        private void Canvas_DragEnter(object sender, DragEventArgs e)
        {
            MessageBox.Show("2");
        }

        #endregion
    }
}
