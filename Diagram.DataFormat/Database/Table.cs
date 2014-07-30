namespace Diagram.DataFormat.Database
{
    public class Table : BaseData.Entity
    {
        #region 字段

        private string physicsName = "table_name";
        private string conceptName = "table_name";
        private string annotation = string.Empty;

        #endregion

        #region 属性

        public string PhysicsName { get { return this.physicsName; } set { this.physicsName = value; } }
        public string ConceptName { get { return this.conceptName; } set { this.conceptName = value; } }
        public string Annotation { get { return this.annotation; } set { this.annotation = value; } }

        #endregion
    }
}
