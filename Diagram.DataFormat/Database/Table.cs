using Diagram.DataFormat.BaseData;
using System.Text;

namespace Diagram.DataFormat.Database
{
    public class Table : BaseData.Entity
    {
        #region 字段

        private string physicsName = "table_name";
        private string conceptName = "table_name";
        private string annotation = string.Empty;
        private ColumnCollection columns;
        private ColumnCollection pkColumns;

        #endregion

        #region 属性

        public string PhysicsName { get { return this.physicsName; } set { this.physicsName = value; } }
        public string ConceptName { get { return this.conceptName; } set { this.conceptName = value; } }
        public string Annotation { get { return this.annotation; } set { this.annotation = value; } }
        public ColumnCollection Columns { get { return this.columns; } set { this.columns = value; } }
        public ColumnCollection PrimaryKeyColumns { get { return this.pkColumns; } set { this.pkColumns = value; } }

        #endregion

        #region 方法

        #region sql

        public string CreateTableSQLText()
        {
            return Table.CreateTableSQLText(this);
        }

        /// <summary>
        /// 生成建表的sql文
        /// </summary>
        /// <returns></returns>
        public static string CreateTableSQLText(Table table)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE TABLE ");
            sb.Append(table.PhysicsName); // 表名
            sb.AppendLine("(");
            // 列
            for (int i = 0; i < table.Items.Count; i++)
            {
                if (i > 0)
                    sb.Append(",");
                else
                    sb.Append(" ");
                sb.AppendLine(table.Columns[i].CreateColumnSQLText());
            }
            // 主键 
            if (table.PrimaryKeyColumns != null && table.PrimaryKeyColumns.Count > 0)
            {
                sb.Append(",CONSTRAINT PK_" + table.PhysicsName + " PRIMARY KEY (");
                for (int i = 0; i < table.PrimaryKeyColumns.Count; i++)
                {
                    if (i > 0)
                        sb.Append(",");
                    sb.Append(table.PrimaryKeyColumns[i].PhysicsName);
                }
                sb.AppendLine(")");
            }
            sb.Append(")");
            return sb.ToString();
        }

        #endregion

        #endregion
    }
}
