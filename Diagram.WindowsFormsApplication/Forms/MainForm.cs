using DataFormat;
using System;
using System.Windows.Forms;

namespace Diagram.WindowsFormsApplication.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region 菜单事件

        private void menuExportSQLText_Click(object sender, EventArgs e)
        {
            string script = this.canvas1.Export();
            MessageBox.Show(script);
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {

        }

        private void menuSave_Click(object sender, EventArgs e)
        {

        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
