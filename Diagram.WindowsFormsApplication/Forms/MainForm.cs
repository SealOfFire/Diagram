using System;
using System.Windows.Forms;

namespace Diagram.WindowsFormsApplication.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //Diagram.DataFormat.BaseData.EntityCollection<Diagram.DataFormat.BaseData.Entity> entity = new DataFormat.BaseData.EntityCollection<DataFormat.BaseData.Entity>();
            //entity.Add(new Diagram.DataFormat.BaseData.Entity());
            //entity[0].Items.Add(new DataFormat.BaseData.Item(entity[0]));
            //System.IO.Stream TestFileStream = System.IO.File.Create("d:/c.txt");
            //System.Runtime.Serialization.Formatters.Binary.BinaryFormatter serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            //serializer.Serialize(TestFileStream, entity);
            //TestFileStream.Close();




            //System.IO.Stream TestFileStream2 = System.IO.File.OpenRead("d:/c.txt");
            //System.Runtime.Serialization.Formatters.Binary.BinaryFormatter deserializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            //Diagram.DataFormat.BaseData.EntityCollection<Diagram.DataFormat.BaseData.Entity> entity2 = (Diagram.DataFormat.BaseData.EntityCollection<Diagram.DataFormat.BaseData.Entity>)deserializer.Deserialize(TestFileStream2);
            //TestFileStream.Close();

        }

        #region 菜单事件

        private void menuExportSQLText_Click(object sender, EventArgs e)
        {
            string script = this.canvas1.Export();
            new ScriptForm(script).ShowDialog();

        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.canvas1.Load(this.openFileDialog1.FileName);
            }
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.canvas1.Save(this.saveFileDialog1.FileName);
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
