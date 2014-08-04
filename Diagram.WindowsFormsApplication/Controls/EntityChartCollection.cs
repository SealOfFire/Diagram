using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Diagram.WindowsFormsApplication.Controls
{
    public class EntityChartCollection : IEnumerable, IList<EntityChart>, IListSource
    {
        private List<EntityChart> entities = new List<EntityChart>();

        public List<EntityChart> Entity { get { return this.entities; } }

        public EntityChart this[Guid identity]
        {
            get
            {
                foreach (EntityChart entity in this.entities) if (entity.Identity == identity) return entity;
                return null;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this.entities.GetEnumerator();
        }

        public bool ContainsListCollection
        {
            get { throw new System.NotImplementedException(); }
        }

        public IList GetList()
        {
            throw new System.NotImplementedException();
        }

        public int IndexOf(EntityChart item)
        {
            return this.entities.IndexOf(item);
        }

        public void Insert(int index, EntityChart item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            this.entities.RemoveAt(index);
        }

        public EntityChart this[int index]
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

        public void Add(EntityChart item)
        {
            this.entities.Add(item);
        }

        public void Clear()
        {
            this.entities.Clear();
        }

        public bool Contains(EntityChart item)
        {
            return this.entities.Contains(item);
        }

        public void CopyTo(EntityChart[] array, int arrayIndex)
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

        public bool Remove(EntityChart item)
        {
            return this.entities.Remove(item);
        }

        IEnumerator<EntityChart> IEnumerable<EntityChart>.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
