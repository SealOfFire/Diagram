using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diagram.WindowsFormsApplication.Forms
{
    public partial class ScriptForm : Form
    {
        private string script = string.Empty;

        public ScriptForm(String script)
        {
            InitializeComponent();
            this.script = script;
        }

        private void ScriptForm_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = this.script;
        }
    }
}
