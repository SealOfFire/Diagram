using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Diagram.WindowsFormsApplication.Controls
{
    public class ItemChartCollection : IEnumerable, IList<ItemChart>, IListSource
    {
        private EntityChart parent;
        private List<ItemChart> items = new List<ItemChart>();

        public ItemChartCollection(EntityChart entity)
        {
            this.parent = entity;
        }

        public ItemChart this[Guid identity]
        {
            get
            {
                foreach (ItemChart item in this.items) if (item.Identity == identity) return item;
                return null;
            }
        }

        #region 实现接口

        #region IEnumerable

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IList

        public int IndexOf(ItemChart item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, ItemChart item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public ItemChart this[int index]
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

        public void Add(ItemChart item)
        {
            this.items.Add(item);
        }

        public void Clear()
        {
            this.items.Clear();
        }

        public bool Contains(ItemChart item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(ItemChart[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return this.items.Count; }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(ItemChart item)
        {
            throw new NotImplementedException();
        }

        IEnumerator<ItemChart> IEnumerable<ItemChart>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IListSource

        public bool ContainsListCollection
        {
            get { throw new NotImplementedException(); }
        }

        public IList GetList()
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
