using System;
using System.Xml;

namespace Diagram.DataFormat
{
    /// <summary>
    /// 
    /// </summary>
    public class ForeignKeyEntity
    {
        private ColumnEntity fromColumn;
        private ColumnEntity toColumn;
        private string name;
        private string annotation = string.Empty;

        public ColumnEntity FromColumn { get { return this.fromColumn; } set { this.fromColumn = value; } }
        public ColumnEntity ToColumn { get { return this.toColumn; } set { this.toColumn = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }
        public string Annotation { get { return this.annotation; } set { this.annotation = value; } }

        public ForeignKeyEntity(ColumnEntity from, ColumnEntity to)
        {
            this.fromColumn = from;
            this.toColumn = to;
            this.name = string.Format("fk_{0}.{1}_{2}.{3}", from.Parent.PhysicsName, from.PhysicsName, to.Parent.PhysicsName, to.PhysicsName);
        }

        public string CreateAddSQL()
        {
            return ForeignKeyEntity.CreateAddSQL(this);
        }

        public static string CreateAddSQL(ForeignKeyEntity foreignKey)
        {
            // 
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine(string.Format("-- [{0}]的外键 start", foreignKey.fromColumn.Parent.PhysicsName));
            sb.AppendLine(string.Format("ALTER TABLE {0} ", foreignKey.fromColumn.Parent.PhysicsName));
            if (string.IsNullOrEmpty(foreignKey.name))
                sb.AppendLine(string.Format("ADD FOREIGN KEY ({0}) REFERENCES {1}({2})",
                    foreignKey.fromColumn.PhysicsName, foreignKey.toColumn.Parent.PhysicsName, foreignKey.toColumn.PhysicsName));
            else
                sb.AppendLine(string.Format("ADD CONSTRAINT {0} FOREIGN KEY ({1}) REFERENCES {2}({3}) ",
                    foreignKey.Name, foreignKey.fromColumn.PhysicsName, foreignKey.toColumn.Parent.PhysicsName, foreignKey.toColumn.PhysicsName));
            sb.AppendLine(string.Format("-- [{0}]的外键 end", foreignKey.fromColumn.Parent.PhysicsName));
            sb.AppendLine();
            return sb.ToString();
        }

        public XmlElement CreateXmlElement(XmlDocument document)
        {
            return ForeignKeyEntity.CreateXmlElement(this, document);
        }

        public static XmlElement CreateXmlElement(ForeignKeyEntity foreignKey, XmlDocument document)
        {
            XmlElement ele = document.CreateElement("Column");
            // 
            XmlAttribute att4 = document.CreateAttribute("TableFromIdentity");
            att4.Value = foreignKey.FromColumn.Parent.Identity.ToString();
            ele.Attributes.Append(att4);
            // 
            XmlAttribute att0 = document.CreateAttribute("ColumnFromIdentity");
            att0.Value = foreignKey.FromColumn.Identity.ToString();
            ele.Attributes.Append(att0);
            // 
            XmlAttribute att5 = document.CreateAttribute("TableToIdentity");
            att5.Value = foreignKey.ToColumn.Parent.Identity.ToString();
            ele.Attributes.Append(att5);
            // 
            XmlAttribute att1 = document.CreateAttribute("ColumnToIdentity");
            att1.Value = foreignKey.ToColumn.Identity.ToString();
            ele.Attributes.Append(att1);
            // 
            XmlAttribute att2 = document.CreateAttribute("Name");
            att2.Value = foreignKey.Name;
            ele.Attributes.Append(att2);
            // 
            XmlAttribute att3 = document.CreateAttribute("Annotation");
            att3.Value = foreignKey.Annotation;
            ele.Attributes.Append(att3);
            return ele;
        }

        public static ForeignKeyEntity Load(XmlNode node, TableCollection tables)
        {
            Guid fromTab = Guid.Parse(node.Attributes["TableFromIdentity"].Value);
            Guid fromCol = Guid.Parse(node.Attributes["ColumnFromIdentity"].Value);
            Guid toTab = Guid.Parse(node.Attributes["TableToIdentity"].Value);
            Guid toCol = Guid.Parse(node.Attributes["ColumnToIdentity"].Value);
            //
            ForeignKeyEntity fk = new ForeignKeyEntity(tables[fromTab].Columns[fromCol], tables[toTab].Columns[toCol]);
            return fk;
        }
    }
}
