using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Diagram.DataFormat.BaseData
{
    public class ItemCollection : IEnumerable, IList<Item>, IListSource
    {
        private Entity parent;
        private List<Item> items = new List<Item>();

        public Item this[Guid identity]
        {
            get
            {
                foreach (Item item in this.items) if (item.Identity == identity) return item;
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

        public int IndexOf(Item item)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(int index, Item item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new System.NotImplementedException();
        }

        public Item this[int index]
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

        public void Add(Item item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(Item item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(Item[] array, int arrayIndex)
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

        public bool Remove(Item item)
        {
            throw new System.NotImplementedException();
        }

        IEnumerator<Item> IEnumerable<Item>.GetEnumerator()
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
