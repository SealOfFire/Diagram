using System;

namespace Diagram.DataFormat.BaseData
{
    [Serializable()]
    public class Entity
    {
        protected Guid identity = Guid.Empty;
        protected ItemCollection<Item> items;
        protected static long count = 0;

        public Guid Identity { get { return this.identity; } set { this.identity = value; } }
        public ItemCollection<Item> Items { get { return this.items; } set { this.items = value; } }

        public Entity()
        {
            this.identity = Guid.NewGuid();
            this.items = new ItemCollection<Item>(this);
            Entity.count++;
        }

        ~Entity()
        {
            // Entity.count--;
        }
    }
}
