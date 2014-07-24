using System.Collections.Generic;
using System.Windows.Forms;

namespace Diagram.Windows.Forms.Controls
{
    public class Canvas
    {
        private List<Table> children = new List<Table>();

        public Table AddTable()
        {
            Table table = new Table(this);
            this.children.Add(table);
            return table;
        }

        public void RemoveTable(Table item)
        {
            this.children.Remove(item);
        }
    }
}
