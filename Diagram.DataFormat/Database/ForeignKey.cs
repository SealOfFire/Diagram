using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram.DataFormat.Database
{
    public class ForeignKey
    {
        private Column fromColumn;
        private Column toColumn;
        private string name;

        public Column FromColumn { get { return this.fromColumn; } set { this.fromColumn = value; } }
        public Column ToColumn { get { return this.toColumn; } set { this.toColumn = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }

        public ForeignKey(Column from, Column to)
        {
            this.fromColumn = from;
            this.toColumn = to;
            // this.name = string.Format("fk_{0}.{1}_{2}.{3}", from.Parent.PhysicsName, from.PhysicsName, to.Parent.PhysicsName, to.PhysicsName);
        }
    }
}
