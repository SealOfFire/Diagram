using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DataFormat
{
    public class ColumnEntity : IComparable<ColumnEntity>, IComparer<ColumnEntity>
    {

        #region

        private Guid identity = Guid.NewGuid();
        private string physicsName = "column_name";
        private string conceptName = "column_name";
        private string annotation = string.Empty;
        private string dataType = "char";
        private int size = 10;
        private int d = -1;
        private int sort = 0;
        private TableEntity parent;

        #endregion

        #region 属性

        public Guid Identity { get { return this.identity; } set { this.identity = value; } }
        public string PhysicsName { get { return this.physicsName; } set { this.physicsName = value; } }
        public string ConceptName { get { return this.conceptName; } set { this.conceptName = value; } }
        public string Annotation { get { return this.annotation; } set { this.annotation = value; } }
        public string DataType { get { return this.dataType; } set { this.dataType = value; } }
        public int Size { get { return this.size; } set { this.size = value; } }
        public int Decimal { get { return this.d; } set { this.d = value; } }
        public int Sort { get { return this.sort; } set { this.sort = value; } }
        public TableEntity Parent { get { return this.parent; } set { this.parent = value; } }
        public string Length
        {
            get
            {
                return this.size.ToString() + (d > 0 ? "," + d.ToString() : string.Empty);
            }
            set
            {
                string[] val = value.Split(',');
                if (val.Length >= 0)
                    int.TryParse(val[0], out this.size);
                if (val.Length >= 1)
                    int.TryParse(val[1], out this.d);
            }
        }

        #endregion

        #region 构造函数

        public ColumnEntity(TableEntity parent)
        {
            this.parent = parent;
            this.Initialize();
        }

        #endregion

        #region 方法

        public void Initialize()
        {
            this.sort = this.parent.Columns.Count;
        }

        #region override

        int IComparable<ColumnEntity>.CompareTo(ColumnEntity other)
        {
            return this.sort - other.sort;
        }

        int IComparer<ColumnEntity>.Compare(ColumnEntity x, ColumnEntity y)
        {
            return x.Sort - y.Sort;
        }

        public override string ToString()
        {
            return ColumnEntity.CreateColumnSQLText(this);
        }

        #endregion

        #region sql

        public string CreateColumnSQLText()
        {
            return ColumnEntity.CreateColumnSQLText(this);
        }

        public static string CreateColumnSQLText(ColumnEntity column)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(column.PhysicsName); // 列名
            sb.Append(" "); // 空格
            sb.Append(column.DataType); // 数据类型
            sb.Append("(");
            sb.Append(column.Size); // 长度
            if (column.Decimal >= 0)
            {
                sb.Append(",");
                sb.Append(column.Decimal);
            }
            sb.Append(")");
            return sb.ToString();
        }

        #endregion

        #region xml

        public static ColumnEntity Load(TableEntity parent, XmlNode node)
        {
            ColumnEntity column = new ColumnEntity(parent);
            column.Identity = Guid.Parse(node.Attributes["Identity"].Value);
            column.PhysicsName = node.Attributes["PhysicsName"].Value;
            column.ConceptName = node.Attributes["ConceptName"].Value;
            column.Annotation = node.Attributes["Annotation"].Value;
            column.DataType = node.Attributes["DataType"].Value;
            column.Size = int.Parse(node.Attributes["Size"].Value);
            column.Decimal = int.Parse(node.Attributes["Decimal"].Value);
            return column;
        }

        public XmlElement CreateXmlElement(XmlDocument document)
        {
            return ColumnEntity.CreateXmlElement(this, document);
        }

        public static XmlElement CreateXmlElement(ColumnEntity column, XmlDocument document)
        {
            XmlElement ele = document.CreateElement("Column");
            // 
            XmlAttribute att0 = document.CreateAttribute("Identity");
            att0.Value = column.Identity.ToString();
            ele.Attributes.Append(att0);
            //
            XmlAttribute att1 = document.CreateAttribute("PhysicsName");
            att1.Value = column.PhysicsName;
            ele.Attributes.Append(att1);
            // 
            XmlAttribute att2 = document.CreateAttribute("ConceptName");
            att2.Value = column.ConceptName;
            ele.Attributes.Append(att2);
            // 
            XmlAttribute att3 = document.CreateAttribute("Annotation");
            att3.Value = column.Annotation;
            ele.Attributes.Append(att3);
            // 
            XmlAttribute att4 = document.CreateAttribute("DataType");
            att4.Value = column.DataType;
            ele.Attributes.Append(att4);
            //
            XmlAttribute att5 = document.CreateAttribute("Size");
            att5.Value = column.Size.ToString();
            ele.Attributes.Append(att5);
            //
            XmlAttribute att6 = document.CreateAttribute("Decimal");
            att6.Value = column.Decimal.ToString();
            ele.Attributes.Append(att6);
            return ele;
        }

        #endregion

        #endregion

    }
}
