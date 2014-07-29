using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Diagram.DataFormat
{
    /// <summary>
    /// 
    /// </summary>
    public class ColumnCollection : IEnumerable, IList<ColumnEntity>, IListSource
    {
        private TableEntity parent;
        private List<ColumnEntity> columns = new List<ColumnEntity>();

        public ColumnEntity this[Guid identity]
        {
            get
            {
                foreach (ColumnEntity column in this.columns) if (column.Identity == identity) return column;
                return null;
            }
        }

        public ColumnCollection(TableEntity table)
        {
            this.parent = table;
        }

        #region IListSource

        public bool ContainsListCollection
        {
            get { throw new System.NotImplementedException(); }
        }

        public IList GetList()
        {
            return this.columns;
            //throw new System.NotImplementedException();
        }

        #endregion

        #region IList

        public int IndexOf(ColumnEntity item)
        {
            return this.columns.IndexOf(item);
        }

        public void Insert(int index, ColumnEntity item)
        {
            this.columns.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this.columns.RemoveAt(index);
        }

        public ColumnEntity this[int index]
        {
            get
            {
                return this.columns[index];
            }
            set
            {
                this.columns[index] = value;
            }
        }

        public void Add(ColumnEntity item)
        {
            this.columns.Add(item);
        }

        public void Clear()
        {
            this.columns.Clear();
        }

        public bool Contains(ColumnEntity item)
        {
            return this.columns.Contains(item);
        }

        public void CopyTo(ColumnEntity[] array, int arrayIndex)
        {
            this.columns.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.columns.Count; }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(ColumnEntity item)
        {
            return this.columns.Remove(item);
        }

        public IEnumerator<ColumnEntity> GetEnumerator()
        {
            return this.columns.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.columns.GetEnumerator();
        }

        #endregion
    }
}
