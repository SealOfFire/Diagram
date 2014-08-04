using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Diagram.DataFormat.BaseData
{
    [Serializable()]
    public class EntityCollection<TEntity> : IEnumerable, IList<TEntity>, IListSource where TEntity : Entity
    {
        private List<TEntity> entities = new List<TEntity>();

        #region 实现接口

        #region IEnumerable

        public IEnumerator GetEnumerator()
        {
            return this.entities.GetEnumerator();
        }

        #endregion

        #region IList

        public int IndexOf(TEntity item)
        {
            return this.entities.IndexOf(item);
        }

        public void Insert(int index, TEntity item)
        {
            this.entities.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this.entities.RemoveAt(index);
        }

        public TEntity this[int index]
        {
            get
            {
                return this.entities[index];
            }
            set
            {
                this.entities[index] = value;
            }
        }

        public virtual void Add(TEntity item)
        {
            this.entities.Add(item);
        }

        public void Clear()
        {
            this.entities.Clear();
        }

        public bool Contains(TEntity item)
        {
            return this.entities.Contains(item);
        }

        public void CopyTo(TEntity[] array, int arrayIndex)
        {
            this.entities.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.entities.Count; }
        }

        public bool IsReadOnly
        {
            get { throw new System.NotImplementedException(); }
        }

        public bool Remove(TEntity item)
        {
            return this.entities.Remove(item);
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
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
            return this.entities;
        }

        #endregion

        #endregion
    }
}
