using Diagram.DataFormat;
using System.Windows.Forms;

namespace Diagram.Windows.Forms.Controls
{
    public class Table
    {
        private TableEntity data = new TableEntity();
        private Control control;
        private Container parent;

        public TableEntity Data { get { return this.data; } }

        public Table(Container parent)
        {
            this.parent = parent;
        }

        public void AddColumn() { }
        public void RemoveColumn()
        {
            // this.data.Columns.Remove();
        }
    }
}
