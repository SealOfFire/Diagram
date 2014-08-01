using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram.DataFormat.Database
{
    public class TableCollection : BaseData.EntityCollection
    {
        /// <summary>
        /// 所有的外键列
        /// </summary>
        private List<ForeignKey> fkColumns = new List<ForeignKey>();

        /// <summary>
        /// 建立外键
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void AddForeignKey(Column from, Column to)
        {
            // 检查外键是否已经存在
            foreach (ForeignKey fk in fkColumns)
                if (fk.FromColumn.Identity == from.Identity && fk.ToColumn.Identity == to.Identity)
                    return;
            // 创建外键
            from.ForeignKeyColumn = to;
            this.fkColumns.Add(new ForeignKey(from, to));
        }

        #region sql

        /// <summary>
        /// 生成建表的sql文
        /// </summary>
        /// <returns></returns>
        public string CreateTableSQLText()
        {
            return TableCollection.CreateTableSQLText(this);
        }

        /// <summary>
        /// 生成建表的sql文
        /// </summary>
        /// <param name="tables"></param>
        /// <returns></returns>
        public static string CreateTableSQLText(TableCollection tables)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Table table in tables)
            {
                sb.AppendLine("-- 创建表[" + table.PhysicsName + "]开始--------------------");
                sb.AppendLine(table.CreateTableSQLText());
                sb.AppendLine("-- 创建表[" + table.PhysicsName + "]结束--------------------");
                sb.AppendLine();
            }
            return sb.ToString();
        }

        #endregion
    }
}
