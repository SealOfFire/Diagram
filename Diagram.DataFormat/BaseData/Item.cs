using System;
using System.Collections.Generic;

namespace Diagram.DataFormat.BaseData
{
    // IComparable<Item<Entity>>, IComparer<Item<Entity>>
    public class Item
    {
        protected Guid identity;
        protected Entity parent;
        protected int sort = 0;

        public Guid Identity { get { return this.identity; } set { this.identity = value; } }
        public Entity Parent { get { return this.parent; } }
        public int Sort { get { return this.sort; } set { this.sort = value; } }

        public Item(Entity entity)
        {
            this.parent = entity;
            this.identity = Guid.NewGuid();
            this.Initialize();
        }

        public void Initialize()
        {
            // this.sort = this.parent.Items.Count;
        }

        //public int CompareTo(Item<Entity> other)
        //{
        //    return this.sort - other.sort;
        //}

        //public int Compare(Item<Entity> x, Item<Entity> y)
        //{
        //    return x.Sort - y.Sort;
        //}
    }
}
