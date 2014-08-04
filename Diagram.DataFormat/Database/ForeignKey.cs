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
        private string annotation = string.Empty;

        public Column FromColumn { get { return this.fromColumn; } set { this.fromColumn = value; } }
        public Column ToColumn { get { return this.toColumn; } set { this.toColumn = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }
        public string Annotation { get { return this.annotation; } set { this.annotation = value; } }

        public ForeignKey(Column from, Column to)
        {
            this.fromColumn = from;
            this.toColumn = to;
            this.name = string.Format("fk_{0}.{1}_{2}.{3}", from.Parent.PhysicsName, from.PhysicsName, to.Parent.PhysicsName, to.PhysicsName);
        }

        public string CreateAddSQL()
        {
            return ForeignKey.CreateAddSQL(this);
        }

        public static string CreateAddSQL(ForeignKey foreignKey)
        {
            // 
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine(string.Format("-- [{0}]的外键 开始", foreignKey.fromColumn.Parent.PhysicsName));
            sb.AppendLine(string.Format("ALTER TABLE {0} ", foreignKey.fromColumn.Parent.PhysicsName));
            if (string.IsNullOrEmpty(foreignKey.name))
                sb.AppendLine(string.Format("ADD FOREIGN KEY ({0}) REFERENCES {1}({2})",
                    foreignKey.fromColumn.PhysicsName, foreignKey.toColumn.Parent.PhysicsName, foreignKey.toColumn.PhysicsName));
            else
                sb.AppendLine(string.Format("ADD CONSTRAINT {0} FOREIGN KEY ({1}) REFERENCES {2}({3}) ",
                    foreignKey.Name, foreignKey.fromColumn.PhysicsName, foreignKey.toColumn.Parent.PhysicsName, foreignKey.toColumn.PhysicsName));
            sb.AppendLine(string.Format("-- [{0}]的外键 结束", foreignKey.fromColumn.Parent.PhysicsName));
            sb.AppendLine();
            return sb.ToString();
        }

        public string CreateDropSQL()
        {
            return ForeignKey.CreateDropSQL(this);
        }

        public static string CreateDropSQL(ForeignKey foreignKey)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine(string.Format("-- [{0}]删除 开始", foreignKey.fromColumn.Parent.PhysicsName));
            sb.AppendLine(string.Format("ALTER TABLE {0} ", foreignKey.fromColumn.Parent.PhysicsName));
            sb.AppendLine(string.Format("ALTER TABLE {0} ", foreignKey.fromColumn.Parent.PhysicsName));
            sb.AppendLine(string.Format("-- [{0}]删除 结束", foreignKey.fromColumn.Parent.PhysicsName));
            return "ALTER TABLE Orders DROP FOREIGN KEY fk_PerOrders";
        }
    }
}
