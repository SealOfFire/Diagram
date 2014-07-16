using System;
using System.Text;
using System.Xml;

namespace DataFormat
{
    public class ColumnEntity
    {
        private Guid identity = Guid.NewGuid();
        private string physicsName = "column_name";
        private string conceptName = "column_name";
        private string annotation = string.Empty;
        private string dataType = "char";
        private int size = 10;
        private int d = -1;


        public Guid Identity { get { return this.identity; } set { this.identity = value; } }
        public string PhysicsName { get { return this.physicsName; } set { this.physicsName = value; } }
        public string ConceptName { get { return this.conceptName; } set { this.conceptName = value; } }
        public string Annotation { get { return this.annotation; } set { this.annotation = value; } }
        public string DataType { get { return this.dataType; } set { this.dataType = value; } }
        public int Size { get { return this.size; } set { this.size = value; } }
        public int Decimal { get { return this.d; } set { this.d = value; } }

        public override string ToString()
        {
            return base.ToString();
        }

        public static ColumnEntity Load(XmlNode node)
        {
            ColumnEntity column = new ColumnEntity();
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
    }
}
