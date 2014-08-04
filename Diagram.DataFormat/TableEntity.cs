using Diagram.DataFormat.BaseData;
using System;
using System.Text;
using System.Xml;

namespace Diagram.DataFormat
{
    /// <summary>
    /// 
    /// </summary>
    public class TableEntity
    {
        #region

        private Guid identity = Guid.NewGuid();
        private string physicsName = "table_name";
        private string conceptName = "table_name";
        private string annotation = string.Empty;
        private ColumnCollection columns;
        private ColumnCollection pkColumns;

        public Guid Identity { get { return this.identity; } set { this.identity = value; } }
        public string PhysicsName { get { return this.physicsName; } set { this.physicsName = value; } }
        public string ConceptName { get { return this.conceptName; } set { this.conceptName = value; } }
        public string Annotation { get { return this.annotation; } set { this.annotation = value; } }
        public ColumnCollection Columns { get { return this.columns; } set { this.columns = value; } }
        public ColumnCollection PrimaryKeyColumns { get { return this.pkColumns; } set { this.pkColumns = value; } }

        #endregion

        public TableEntity()
        {
            this.columns = new ColumnCollection(this);
            this.pkColumns = new ColumnCollection(this);
        }

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

        public void SetPrimaryKeyColumnsFromColumn()
        {
            this.PrimaryKeyColumns.Clear();
            foreach (ColumnEntity col in columns)
            {
                if (col.PrimaryKey)
                    this.PrimaryKeyColumns.Add(col);
            }
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
            table.SetPrimaryKeyColumnsFromColumn();
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
            sb.AppendLine("-- 创建表[" + table.PhysicsName + "]开始--------------------");
            sb.Append("CREATE TABLE ");
            sb.Append(table.PhysicsName); // 表名
            sb.AppendLine("(");
            // 列
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (i > 0)
                    sb.Append(",");
                else
                    sb.Append(" ");
                sb.AppendLine(table.columns[i].CreateColumnSQLText());
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
            sb.AppendLine(")");
            sb.AppendLine("-- 创建表[" + table.PhysicsName + "]结束--------------------");
            return sb.ToString();
        }

        #endregion

        #endregion
    }
}
