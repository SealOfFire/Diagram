using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram.DataFormat.Database
{
    public class TableCollection : BaseData.EntityCollection
    {
        /// <summary>
        /// 建立外键
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void CreateForeignKey(Column from, Column to)
        {
            //// 检查外键是否已经存在
            //foreach (ForeignKey fk in fkColumn)
            //    if (fk.FromColumn.Identity == from.Identity && fk.ToColumn.Identity == to.Identity)
            //        return;
            //// 创建外键
            //from.ForeignKeyColumn = to;
            //this.fkColumn.Add(new ForeignKeyEntity(from, to));
        }
    }
}
