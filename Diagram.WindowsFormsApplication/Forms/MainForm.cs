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
            new ScriptForm(script).ShowDialog();

        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.canvas1.Load(this.openFileDialog1.FileName);
            }
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.canvas1.Save(this.saveFileDialog1.FileName);
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
