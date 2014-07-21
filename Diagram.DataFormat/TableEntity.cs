using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DataFormat
{
    public class TableEntity
    {
        #region
        private Guid identity = Guid.NewGuid();
        private string physicsName = "table_name";
        private string conceptName = "table_name";
        private string annotation = string.Empty;
        private List<ColumnEntity> columns = new List<ColumnEntity>();

        public Guid Identity { get { return this.identity; } set { this.identity = value; } }
        public string PhysicsName { get { return this.physicsName; } set { this.physicsName = value; } }
        public string ConceptName { get { return this.conceptName; } set { this.conceptName = value; } }
        public string Annotation { get { return this.annotation; } set { this.annotation = value; } }
        public List<ColumnEntity> Columns { get { return this.columns; } set { this.columns = value; } }
        #endregion

        #region

        public void AddColumnEntity(ColumnEntity item)
        {
            this.columns.Add(item);
        }

        public ColumnEntity AddColumnEntity()
        {
            ColumnEntity item = new ColumnEntity(this);
            this.columns.Add(item);
            return item;
        }

        public void InsertColumnEntity(int index, ColumnEntity item)
        {
            this.columns.Insert(index, item);
        }

        public ColumnEntity InsertColumnEntity(int index)
        {
            ColumnEntity item = new ColumnEntity(this);
            this.columns.Insert(index, item);
            return item;
        }

        public void RemoveColumnEntity(ColumnEntity item)
        {
            this.columns.Remove(item);
        }

        #region xml

        public static TableEntity Load(XmlNode node)
        {
            TableEntity table = new TableEntity();
            table.Identity = Guid.Parse(node.Attributes["Identity"].Value);
            table.PhysicsName = node.Attributes["PhysicsName"].Value;
            table.ConceptName = node.Attributes["ConceptName"].Value;
            table.Annotation = node.Attributes["Annotation"].Value;
            XmlNodeList xmlColumnList = node.SelectNodes("Column");
            foreach (XmlNode xmlColumn in xmlColumnList)
            {
                table.columns.Add(ColumnEntity.Load(table, xmlColumn));
                //tables.Add(TableEntity.Load(node));
            }
            return table;
        }

        public XmlElement CreateXmlElement(XmlDocument document)
        {
            return TableEntity.CreateXmlElement(this, document);
        }

        public static XmlElement CreateXmlElement(TableEntity table, XmlDocument document)
        {
            XmlElement ele = document.CreateElement("Table");
            // 
            XmlAttribute att0 = document.CreateAttribute("Identity");
            att0.Value = table.Identity.ToString();
            ele.Attributes.Append(att0);
            // 
            XmlAttribute att1 = document.CreateAttribute("PhysicsName");
            att1.Value = table.PhysicsName;
            ele.Attributes.Append(att1);
            // 
            XmlAttribute att2 = document.CreateAttribute("ConceptName");
            att2.Value = table.ConceptName;
            ele.Attributes.Append(att2);
            // 
            XmlAttribute att3 = document.CreateAttribute("Annotation");
            att3.Value = table.Annotation;
            ele.Attributes.Append(att3);
            foreach (ColumnEntity column in table.Columns)
            {
                ele.AppendChild(column.CreateXmlElement(document));
            }
            return ele;
        }

        #endregion

        #region sql

        public string CreateTableSQLText()
        {
            return TableEntity.CreateTableSQLText(this);
        }

        /// <summary>
        /// 生成建表的sql文
        /// </summary>
        /// <returns></returns>
        public static string CreateTableSQLText(TableEntity table)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE TABLE ");
            sb.Append(table.physicsName); // 表名
            sb.AppendLine("(");
            // 列
            for (int i = 0; i < table.Columns.Count; i++)
            {
                sb.Append(table.columns[i].CreateColumnSQLText());
                if (i < table.columns.Count - 1)
                    sb.AppendLine(",");
                else
                    sb.AppendLine();
            }
            sb.Append(")");
            return sb.ToString();
        }

        #endregion

        #endregion
    }
}
