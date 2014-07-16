using DataFormat;
using System;
using System.Windows.Forms;

namespace Diagram.WindowsFormsApplication.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void canvas1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DataFormat.TableEntity table1 = new DataFormat.TableEntity();
            table1.AddColumnEntity(new DataFormat.ColumnEntity());
            table1.AddColumnEntity(new DataFormat.ColumnEntity());
            table1.AddColumnEntity(new DataFormat.ColumnEntity());

            DataFormat.TableEntity table2 = new DataFormat.TableEntity();
            table2.AddColumnEntity(new DataFormat.ColumnEntity());
            table2.AddColumnEntity(new DataFormat.ColumnEntity());
            table2.AddColumnEntity(new DataFormat.ColumnEntity());

            TableCollection tables = new TableCollection();
            tables.Add(table1);
            tables.Add(table2);
            tables.Save(@"D:\table.txt");

            tables = TableCollection.Load(@"D:\table.txt");
            int a = 0;
            a++;
            //DataFormat.TableEntity.CreateTableSQLText(table);
        }
    }
}
