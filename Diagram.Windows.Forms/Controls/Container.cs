using Diagram.DataFormat.BaseData;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Diagram.Windows.Forms.Controls
{
    public class Container : Control
    {
        private EntityCollection data = new EntityCollection();
        private List<Entity> entities = new List<Entity>();

        public EntityCollection Data { get { return this.data; } }
        public List<Entity> Entities { get { return this.entities; } }

        public virtual Entity AddEntity()
        {
            Entity entity = new Entity(this);
            // 追加控件
            this.entities.Add(entity); // 追加到列表中
            this.Controls.Add(entity); // 追加到画面上
            // 追加数据
            this.data.Add(entity.Data);
            return entity;
        }
    }
}
