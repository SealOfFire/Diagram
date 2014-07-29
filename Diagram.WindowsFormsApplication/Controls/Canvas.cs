using Diagram.DataFormat;
using Diagram.WindowsFormsApplication.Forms;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Diagram.WindowsFormsApplication.Controls
{
    public partial class Canvas : Panel
    {
        #region

        private DataFormat.TableCollection tables = new DataFormat.TableCollection();

        #endregion

        #region 属性

        public DataFormat.TableCollection Tables { get { return this.tables; } }

        #endregion

        #region 构造函数

        public Canvas()
        {
            InitializeComponent();
        }

        #endregion

        #region 方法

        #region xml

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="path"></param>
        public void Load(string path)
        {
            this.Controls.Clear();
            this.tables.Clear();
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            XmlDocument doc = new XmlDocument();
            doc.Load(fileStream);
            fileStream.Close();
            // 读取数据
            this.tables = TableCollection.Load(doc.SelectSingleNode("root"));
            // 读取ui
            this.LoadUI(doc);
        }

        /// <summary>
        /// 读取UI数据
        /// </summary>
        /// <param name="document"></param>
        public void LoadUI(XmlDocument document)
        {
            XmlNode xmlUI = document.SelectSingleNode("root").SelectSingleNode("UI");
            XmlNodeList xmlTables = xmlUI.SelectNodes("Table");
            foreach (XmlNode node in xmlTables)
            {
                Guid id = Guid.Empty;
                EntityChart table = EntityChart.LoadUI(this, node, out id);
                table.Table = tables[id];
                table.SetForm();
                this.Controls.Add(table);
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="path"></param>
        public void Save(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Create);
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(dec);
            // 根节点
            XmlElement root = doc.CreateElement("root");
            doc.AppendChild(root);
            // 数据保存
            root.AppendChild(this.tables.Save(doc));
            // 界面保存
            root.AppendChild(this.SaveUI(doc));
            //保存文件
            doc.Save(fileStream);
            // 保存
            fileStream.Flush();
            fileStream.Close();
            fileStream.Dispose();
        }

        /// <summary>
        /// 保存UI数据
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public XmlElement SaveUI(XmlDocument document)
        {
            XmlElement ele = document.CreateElement("UI");
            foreach (Control col in this.Controls)
            {
                if (col is EntityChart)
                {
                    EntityChart table = col as EntityChart;
                    ele.AppendChild(table.SaveUI(document));
                }
            }
            return ele;
        }

        #endregion

        /// <summary>
        /// 导出sql文
        /// </summary>
        /// <returns></returns>
        public string Export()
        {
            return this.tables.CreateTableSQLText();
        }

        /// <summary>
        /// 追加表
        /// </summary>
        /// <returns></returns>
        public EntityChart AddTable()
        {
            EntityChart control = new EntityChart(this);
            this.Controls.Add(control);
            return control;
        }

        /// <summary>
        /// 删除表
        /// </summary>
        /// <param name="table"></param>
        public void removeTable(EntityChart table)
        {
            this.Controls.Remove(table);
            this.tables.Remove(table.Table);
            table.Dispose();
        }

        /// <summary>
        /// 创建外键
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void CreateForeignKey(ColumnEntity from, ColumnEntity to)
        {
            // 添加数据
            this.tables.CreateForeignKey(from, to);
            // 添加外键控件
            this.Controls.Add(new TextBox());
        }

        #endregion

        #region 事件

        /// <summary>
        /// 添加表菜单单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAddTable_Click(object sender, EventArgs e)
        {
            this.AddTable();
        }

        /// <summary>
        /// 追加外键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAddForeignKey_Click(object sender, EventArgs e)
        {
            new ForeignKeyEditForm(this).ShowDialog();
        }

        #endregion

    }
}
