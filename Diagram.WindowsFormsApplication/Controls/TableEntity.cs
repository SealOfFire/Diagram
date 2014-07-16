using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram.WindowsFormsApplication.Controls
{
    /// <summary>
    /// 表
    /// </summary>
    public partial class TableEntity : CanDragControl
    {
        private DataFormat.TableEntity table = new DataFormat.TableEntity();

        public TableEntity()
        {
            this.InitializeComponent();
        }
    }
}
