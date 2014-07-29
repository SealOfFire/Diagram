using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram.DataFormat
{
    /// <summary>
    /// 
    /// </summary>
    public class ForeignKeyEntity
    {
        private ColumnEntity fromColumn;
        private ColumnEntity toColumn;
        private string name;

        public ColumnEntity FromColumn { get { return this.fromColumn; } set { this.fromColumn = value; } }
        public ColumnEntity ToColumn { get { return this.toColumn; } set { this.toColumn = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }

        public ForeignKeyEntity(ColumnEntity from, ColumnEntity to)
        {
            this.fromColumn = from;
            this.toColumn = to;
            this.name = string.Format("fk_{0}.{1}_{2}.{3}", from.Parent.PhysicsName, from.PhysicsName, to.Parent.PhysicsName, to.PhysicsName);
        }
    }
}
