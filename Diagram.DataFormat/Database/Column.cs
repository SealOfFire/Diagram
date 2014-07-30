using System;
using System.Collections.Generic;
using System.Linq;
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
                    if (val.Length >= 0)
                        int.TryParse(val[0], out this.size);
                    if (val.Length >= 1)
                        int.TryParse(val[1], out this.d);
                }
            }
        }

        #endregion

        #region 构造函数

        public Column(Table table)
            : base(table) { }

        #endregion
    }
}
