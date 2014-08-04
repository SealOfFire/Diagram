using System.Text;

namespace Diagram.DataFormat.Database
{
    public class Column : BaseData.Item
    {
        #region 字段

        private string physicsName = "column_name";
        private string conceptName = "column_name";
        private string annotation = string.Empty;
        private string dataType = "char";
        private string defaultValue = string.Empty;
        private int size = 10;
        private int d = -1;
        private bool isPrimaryKey = false;
        private bool allowNulls = true;
        private Column fkCoumn;
        private new Table parent;

        #endregion

        #region 属性

        public string PhysicsName { get { return this.physicsName; } set { this.physicsName = value; } }
        public string ConceptName { get { return this.conceptName; } set { this.conceptName = value; } }
        public string Annotation { get { return this.annotation; } set { this.annotation = value; } }
        public string DataType { get { return this.dataType; } set { this.dataType = value; } }
        public string DefaultValue { get { return this.defaultValue; } set { this.defaultValue = value; } }
        public int Size { get { return this.size; } set { this.size = value; } }
        public int Decimal { get { return this.d; } set { this.d = value; } }
        public Column ForeignKeyColumn { get { return this.fkCoumn; } set { this.fkCoumn = value; } }
        public bool AllowNulls { get { return this.allowNulls; } set { this.allowNulls = value; } }
        public bool PrimaryKey
        {
            get { return this.isPrimaryKey; }
            set
            {
                this.isPrimaryKey = value;
                this.allowNulls = !value;
            }
        }

        public string Length
        {
            get
            {
                return this.size.ToString() + (d > 0 ? "," + d.ToString() : string.Empty);
            }
            set
            {
                if (value == null)
                {
                    this.size = -1;
                    this.d = -1;
                }
                else
                {
                    string[] val = value.Split(',');
                    if (val.Length > 0)
                    {
                        int.TryParse(val[0], out this.size);
                        this.d = -1;
                    }
                    if (val.Length > 1)
                        int.TryParse(val[1], out this.d);
                }
            }
        }

        public new Table Parent
        {
            get
            {
                return this.parent;
            }
        }

        #endregion

        #region 构造函数

        public Column(Table table)
            : base(table) { this.parent = table; }

        #endregion

        #region 方法

        #region override

        public override string ToString()
        {
            return (this.isPrimaryKey ? "PK " : "   ") + Column.CreateColumnSQLText(this);
        }

        #endregion

        #region sql

        public string CreateColumnSQLText()
        {
            return Column.CreateColumnSQLText(this);
        }

        public static string CreateColumnSQLText(Column column)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(column.PhysicsName); // 列名
            sb.Append(" "); // 空格
            sb.Append(column.DataType); // 数据类型
            if (column.Size >= 0)
            {
                sb.Append("(");
                sb.Append(column.Size); // 长度
                if (column.Decimal >= 0)
                {
                    sb.Append(",");
                    sb.Append(column.Decimal);
                }
                sb.Append(")");
            }
            // 默认值
            if (string.IsNullOrEmpty(column.DefaultValue))
            {
                // 准许空
                if (column.AllowNulls)
                    sb.Append(" NULL ");
                else
                    sb.Append(" NOT NULL ");
            }
            else
            {
                sb.Append(" DEFAULT ");
                sb.Append(column.DefaultValue);
                sb.Append(" ");
            }
            return sb.ToString();
        }

        #endregion

        #endregion
    }
}
