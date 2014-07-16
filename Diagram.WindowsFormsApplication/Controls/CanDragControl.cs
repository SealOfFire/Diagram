using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diagram.WindowsFormsApplication.Controls
{
    /// <summary>
    /// 可拖拽控件
    /// </summary>
    public partial class CanDragControl : UserControl
    {
        Point pt;
        bool moves = true;

        public CanDragControl()
        {
            InitializeComponent();
        }

        private void UserControl1_MouseDown(object sender, MouseEventArgs e)
        {
            pt = Cursor.Position;
        }

        private void UserControl1_MouseUp(object sender, MouseEventArgs e)
        {
            moves = true;
        }

        private void UserControl1_MouseMove(object sender, MouseEventArgs e)
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
    }
}
