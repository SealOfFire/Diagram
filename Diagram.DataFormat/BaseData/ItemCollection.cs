using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Diagram.DataFormat.BaseData
{
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
            throw new System.NotImplementedException();
        }

        #endregion

        #region IList

        public int IndexOf(TItem item)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(int index, TItem item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new System.NotImplementedException();
        }

        public TItem this[int index]
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public void Add(TItem item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(TItem item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(TItem[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public int Count
        {
            get { throw new System.NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new System.NotImplementedException(); }
        }

        public bool Remove(TItem item)
        {
            throw new System.NotImplementedException();
        }

        IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IListSource

        public bool ContainsListCollection
        {
            get { throw new System.NotImplementedException(); }
        }

        public IList GetList()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #endregion
    }
}
