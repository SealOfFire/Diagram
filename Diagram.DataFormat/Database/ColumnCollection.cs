using Diagram.DataFormat.BaseData;

namespace Diagram.DataFormat.Database
{
    public class ColumnCollection : ItemCollection<Column>
    {
        public ColumnCollection(Table table)
            : base(table) { }
    }
}
