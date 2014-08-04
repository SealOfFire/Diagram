using Diagram.DataFormat;
using Diagram.WindowsFormsApplication.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Diagram.WindowsFormsApplication.Controls
{
    public partial class Canvas : Panel
    {
        #region

        private DataFormat.TableCollection tables = new DataFormat.TableCollection();
        private EntityChartCollection entities = new EntityChartCollection();
        private List<Line> lines = new List<Line>();

        #endregion

        #region 属性

        public DataFormat.TableCollection Tables { get { return this.tables; } }
        public EntityChartCollection Entities { get { return this.entities; } }
        public List<Line> Lines { get { return this.lines; } }

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
                EntityChart entity = EntityChart.LoadUI(this, node, out id);
                entity.Table = tables[id];
                entity.SetForm();
                this.entities.Add(entity);
                this.Controls.Add(entity);
            }

            // 设置外键
            this.lines = new List<Line>();
            foreach (ForeignKeyEntity fk in this.tables.ForeignKeyColumn)
            {
                ItemChart from = this.Entities[fk.FromColumn.Parent.Identity].Items[fk.FromColumn.Identity];
                ItemChart to = this.Entities[fk.ToColumn.Parent.Identity].Items[fk.ToColumn.Identity];
                this.lines.Add(new Line(from, to));
            }
            this.Refresh();
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
            XmlElement[] eles = this.tables.Save(doc);
            foreach (XmlElement ele in eles)
            {
                root.AppendChild(ele);
            }
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
            EntityChart entity = new EntityChart(this);
            this.entities.Add(entity);
            this.Controls.Add(entity);
            return entity;
        }

        /// <summary>
        /// 删除表
        /// </summary>
        /// <param name="table"></param>
        public void removeTable(EntityChart entity)
        {
            this.entities.Remove(entity);
            this.Controls.Remove(entity);
            this.tables.Remove(entity.Table);
            entity.Dispose();
        }

        public void AddForeignKey(ItemChart from, ItemChart to)
        {
            // 添加数据
            if (this.tables.CreateForeignKey(from.Column, to.Column))
            {
                this.lines.Add(new Line(from, to));
            }

            // 刷新
            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            // 根据画面状态划线
            foreach (Line line in this.lines)
            {
                line.CalculatePoint();
                if (line.Points[0].X > line.Points[1].X)
                    line.Points[1] = new Point(line.Points[1].X + 208, line.Points[1].Y);
                else
                    line.Points[0] = new Point(line.Points[0].X + 208, line.Points[0].Y);
                e.Graphics.DrawLines(Pens.Black, line.Points.ToArray());
            }
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
