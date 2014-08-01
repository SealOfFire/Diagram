using System.Collections.Generic;
using System.Windows.Forms;

namespace Diagram.Windows.Forms.Controls
{
    public class Entity : Control
    {
        private Diagram.DataFormat.BaseData.Entity data = new DataFormat.BaseData.Entity();
        private List<Item> items = new List<Item>();
        private Container parentContainer;

        public Diagram.DataFormat.BaseData.Entity Data { get { return data; } }

        public Entity(Container parent)
        {
            this.parentContainer = parent;
        }

        //public static Entity AddEntity(Container parent)
        //{
        //    Entity entity = new Entity(parent);
        //    parent.Data.Add(entity);
        //    return entity;
        //}
    }
}
