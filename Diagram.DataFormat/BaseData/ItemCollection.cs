using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Diagram.DataFormat.BaseData
{
    [Serializable()]
    public class ItemCollection<TItem> : IList<TItem>, IListSource, IEnumerable where TItem : Item
    {
        private Entity parent;
        private List<TItem> items = new List<TItem>();

        public TItem this[Guid identity]
        {
            get
            {
                foreach (TItem item in this.items) if (item.Identity == identity) return item;
                return null;
            }
        }

        public ItemCollection(Entity entity)
        {
            this.parent = entity;
        }

        #region 实现接口

        #region IEnumerable

        public IEnumerator GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        #endregion

        #region IList

        public int IndexOf(TItem item)
        {
            return this.items.IndexOf(item);
        }

        public void Insert(int index, TItem item)
        {
            this.items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this.items.RemoveAt(index);
        }

        public TItem this[int index]
        {
            get
            {
                return this.items[index];
            }
            set
            {
                this.items[index] = value;
            }
        }

        public void Add(TItem item)
        {
            this.items.Add(item);
        }

        public void Clear()
        {
            this.items.Clear();
        }

        public bool Contains(TItem item)
        {
            return this.items.Contains(item);
        }

        public void CopyTo(TItem[] array, int arrayIndex)
        {
            this.items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.items.Count; }
        }

        public bool IsReadOnly
        {
            get { throw new System.NotImplementedException(); }
        }

        public bool Remove(TItem item)
        {
            return this.items.Remove(item);
        }

        IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        #endregion

        #region IListSource

        public bool ContainsListCollection
        {
            get { throw new System.NotImplementedException(); }
        }

        public IList GetList()
        {
            return this.items;
        }

        #endregion

        #endregion
    }
}
