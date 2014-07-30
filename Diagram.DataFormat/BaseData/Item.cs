using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram.DataFormat.BaseData
{
    public class Item : IComparable<Item>, IComparer<Item>
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
        }

        public int CompareTo(Item other)
        {
            return this.sort - other.sort;
        }

        public int Compare(Item x, Item y)
        {
            return x.Sort - y.Sort;
        }
    }
}
