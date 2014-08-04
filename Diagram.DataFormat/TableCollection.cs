using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml;

namespace Diagram.DataFormat
{
    /// <summary>
    /// 
    /// </summary>
    public class TableCollection : IEnumerable, IList<TableEntity>, IListSource
    {

        private List<TableEntity> tables = new List<TableEntity>();
        private List<ForeignKeyEntity> fkColumn = new List<ForeignKeyEntity>();

        #region 属性

        public TableEntity this[int index] { get { return this.tables[index]; } }

        public TableEntity this[Guid identity]
        {
            get
            {
                foreach (TableEntity table in this.tables) if (table.Identity == identity) return table;
                return null;
            }
        }

        public List<ForeignKeyEntity> ForeignKeyColumn
        {
            get
            {
                return this.fkColumn;
            }
        }

        #endregion

        #region 方法

        public void Add(TableEntity item)
        {
            this.tables.Add(item);
        }

        public void Remove(TableEntity item)
        {
            this.tables.Remove(item);
        }

        public void Clear()
        {
            this.tables.Clear();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.tables.GetEnumerator();
        }

        /// <summary>
        /// 建立外键
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public bool CreateForeignKey(ColumnEntity from, ColumnEntity to)
        {
            // 检查是否是用一个表
            if (from.Parent.Identity == to.Parent.Identity)
                return false;

            // 检查外键是否已经存在
            foreach (ForeignKeyEntity fk in fkColumn)
                if (fk.FromColumn.Identity == from.Identity && fk.ToColumn.Identity == to.Identity)
                    return false;

            // 创建外键
            from.ForeignKeyColumn = to;
            this.fkColumn.Add(new ForeignKeyEntity(from, to));
            return true;
        }

        #region sql

        public string CreateTableSQLText()
        {
            return TableCollection.CreateTableSQLText(this);
        }

        public static string CreateTableSQLText(TableCollection tables)
        {
            StringBuilder sb = new StringBuilder();
            foreach (TableEntity table in tables)
            {
                sb.AppendLine(table.CreateTableSQLText());
                sb.AppendLine();
            }
            sb.AppendLine("-- 创建 外键 开始--------------------");
            foreach (ForeignKeyEntity fk in tables.ForeignKeyColumn)
            {
                sb.AppendLine(fk.CreateAddSQL());
            }
            sb.AppendLine("-- 创建 外键 结束--------------------");
            return sb.ToString();
        }

        public string DeleteTableSQLText()
        {
            return TableCollection.DeleteTableSQLText(this);
        }

        public static string DeleteTableSQLText(TableCollection tables)
        {
            StringBuilder sb = new StringBuilder();
            foreach (TableEntity table in tables)
            {
                sb.AppendLine("-- 删除表[" + table.PhysicsName + "]开始--------------------");
                sb.Append("DELETE FROM ");
                sb.Append(table.PhysicsName);
                sb.AppendLine("-- 删除表[" + table.PhysicsName + "]结束--------------------");
                sb.AppendLine();
            }
            return sb.ToString();
        }

        #endregion

        #region xml

        public XmlElement[] Save(XmlDocument document)
        {
            return TableCollection.Save(this, document);
        }

        public static XmlElement[] Save(TableCollection tables, XmlDocument document)
        {
            // 保存表信息
            XmlElement[] value = new XmlElement[2];
            value[0] = document.CreateElement("Tables");
            foreach (TableEntity table in tables)
            {
                value[0].AppendChild(table.CreateXmlElement(document));
            }
            // 保存外键
            value[1] = document.CreateElement("ForeignKey");
            foreach (ForeignKeyEntity fk in tables.ForeignKeyColumn)
            {
                value[1].AppendChild(fk.CreateXmlElement(document));
            }
            return value;
        }

        public static TableCollection Load(XmlNode tablesNode)
        {
            TableCollection tables = new TableCollection();

            XmlNode xmlTables = tablesNode.SelectSingleNode("Tables");
            foreach (XmlNode node in xmlTables)
            {
                tables.Add(TableEntity.Load(node));
            }
            // 读取外键
            XmlNode xmlFK = tablesNode.SelectSingleNode("ForeignKey");
            foreach (XmlNode node in xmlFK)
            {
                tables.ForeignKeyColumn.Add(ForeignKeyEntity.Load(node, tables));
            }
            return tables;
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

        #endregion

        #endregion

        #region IList接口

        int IList<TableEntity>.IndexOf(TableEntity item)
        {
            return this.tables.IndexOf(item);
        }

        void IList<TableEntity>.Insert(int index, TableEntity item)
        {
            this.tables.Insert(index, item);
        }

        void IList<TableEntity>.RemoveAt(int index)
        {
            this.tables.RemoveAt(index);
        }

        TableEntity IList<TableEntity>.this[int index]
        {
            get
            {
                return this.tables[index];
            }
            set
            {
                this.tables[index] = value;
            }
        }

        void ICollection<TableEntity>.Add(TableEntity item)
        {
            this.tables.Add(item);
        }

        void ICollection<TableEntity>.Clear()
        {
            this.tables.Clear();
        }

        bool ICollection<TableEntity>.Contains(TableEntity item)
        {
            return this.tables.Contains(item);
        }

        void ICollection<TableEntity>.CopyTo(TableEntity[] array, int arrayIndex)
        {
            this.tables.CopyTo(array, arrayIndex);
        }

        int ICollection<TableEntity>.Count
        {
            get { return this.tables.Count; }
        }

        bool ICollection<TableEntity>.IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        bool ICollection<TableEntity>.Remove(TableEntity item)
        {
            return this.tables.Remove(item);
        }

        IEnumerator<TableEntity> IEnumerable<TableEntity>.GetEnumerator()
        {
            return this.tables.GetEnumerator();
        }

        #endregion

        #region IListSource接口

        public bool ContainsListCollection
        {
            get { throw new NotImplementedException(); }
        }

        public IList GetList()
        {
            return this.tables;
        }

        #endregion

    }
}
