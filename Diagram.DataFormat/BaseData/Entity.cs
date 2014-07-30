using System;

namespace Diagram.DataFormat.BaseData
{
    public class Entity
    {
        protected Guid identity = Guid.Empty;
        protected ItemCollection items;

        public Guid Identity { get { return this.identity; } set { this.identity = value; } }
        public ItemCollection Items { get { return this.items; } set { this.items = value; } }

        public Entity()
        {
            this.identity = Guid.NewGuid();
        }
    }
}
