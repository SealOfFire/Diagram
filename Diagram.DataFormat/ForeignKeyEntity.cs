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

        public ColumnEntity FromColumn { get { return this.fromColumn; } set { this.fromColumn = value; } }
        public ColumnEntity ToColumn { get { return this.toColumn; } set { this.toColumn = value; } }

        public ForeignKeyEntity(ColumnEntity from, ColumnEntity to)
        {
            this.fromColumn = from;
            this.toColumn = to;
        }
    }
}
