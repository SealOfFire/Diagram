using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Diagram.DataFormat.BaseData
{
    public class EntityCollection<TEntity> : IEnumerable, IList<Entity>, IListSource where TEntity : Entity
    {
        private List<Entity> entities = new List<Entity>();

        #region 实现接口

        #region IEnumerable

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IList

        public int IndexOf(Entity item)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(int index, Entity item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new System.NotImplementedException();
        }

        public Entity this[int index]
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

        public void Add(Entity item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(Entity item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(Entity[] array, int arrayIndex)
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

        public bool Remove(Entity item)
        {
            throw new System.NotImplementedException();
        }

        IEnumerator<Entity> IEnumerable<Entity>.GetEnumerator()
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
