using DataFormat;
using System;
using System.Windows.Forms;

namespace Diagram.WindowsFormsApplication.Controls
{
    public partial class Canvas : Panel
    {
        #region

        private TableCollection tables = new TableCollection();
        private ContextMenu contextMenu;
        private MenuItem menuItemAddTableEntity;

        #endregion

        #region 构造函数

        public Canvas()
        {
            InitializeComponent();
            this.InitializeContextMenu();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化上下文菜单
        /// </summary>
        private void InitializeContextMenu()
        {
            //
            this.menuItemAddTableEntity = new MenuItem();
            this.menuItemAddTableEntity.Text = "Add table";
            this.menuItemAddTableEntity.Click += new System.EventHandler(menuItemAddTableEntity_Click);
            //
            this.contextMenu = new ContextMenu();
            this.contextMenu.MenuItems.Add(this.menuItemAddTableEntity);
            this.ContextMenu = this.contextMenu;
        }

        public void LoadData(string path)
        {

        }

        public void Save(string path)
        {

        }

        public string Export()
        {
            return this.tables.CreateTableSQLText();
        }

        public TableEntity AddTable()
        {
            TableEntity control = new TableEntity(this);
            this.Controls.Add(control);
            this.tables.Add(control.GetTable());
            return control;
        }

        public void removeTable(TableEntity table)
        {
            this.Controls.Remove(table);
            this.tables.Remove(table.GetTable());
        }

        #endregion

        #region 事件

        private void Canvas_DragDrop(object sender, DragEventArgs e)
        {
            MessageBox.Show("1");
        }

        private void Canvas_DragEnter(object sender, DragEventArgs e)
        {
            MessageBox.Show("2");
        }

        private void menuItemAddTableEntity_Click(object sender, EventArgs e)
        {
            this.AddTable();
        }

        #endregion
    }
}
