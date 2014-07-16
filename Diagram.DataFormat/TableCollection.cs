using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DataFormat
{
    public class TableCollection : IEnumerable
    {
        private List<TableEntity> tables = new List<TableEntity>();

        public TableEntity this[int index] { get { return this.tables[index]; } }

        public void Add(TableEntity item)
        {
            this.tables.Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.tables.GetEnumerator();
        }

        public string CreateTableSQLText()
        {
            return TableCollection.CreateTableSQLText(this);
        }

        public static string CreateTableSQLText(TableCollection tables)
        {
            StringBuilder sb = new StringBuilder();
            foreach (TableEntity table in tables)
            {
                sb.AppendLine("-- 创建表[" + table.PhysicsName + "]开始--------------------");
                sb.AppendLine(table.CreateTableSQLText());
                sb.AppendLine("-- 创建表[" + table.PhysicsName + "]结束--------------------");
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public void Save(string path)
        {
            TableCollection.Save(this, path);
        }

        public static void Save(TableCollection tables, string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Create);
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(dec);
            // 根元素
            XmlElement ele = doc.CreateElement("Tables");
            doc.AppendChild(ele);
            foreach (TableEntity table in tables)
            {
                ele.AppendChild(table.CreateXmlElement(doc));
            }
            doc.Save(fileStream);
            // 保存
            fileStream.Flush();
            fileStream.Close();
            fileStream.Dispose();
        }

        public static TableCollection Load(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            XmlDocument doc = new XmlDocument();
            doc.Load(fileStream);
            fileStream.Close();
            TableCollection tables = new TableCollection();

            XmlNode xmlTables = doc.SelectSingleNode("Tables");
            foreach (XmlNode node in xmlTables)
            {
                tables.Add(TableEntity.Load(node));
            }
            return tables;
        }
    }
}
