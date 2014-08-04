using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Diagram.WindowsFormsApplication.Controls
{
    public class Line : Control
    {
        private List<Point> points;
        private List<Point> outlinePoints;
        private ItemChart fromItem;
        private ItemChart toItem;

        public List<Point> Points { get { return this.points; } set { this.points = value; } }

        public Line(ItemChart from, ItemChart to)
        {
            this.fromItem = from;
            this.toItem = to;
            this.points = new List<Point>();
            this.CalculatePoint();
        }

        public void CalculatePoint()
        {
            this.points.Clear();
            this.points.Add(this.fromItem.GetLocationInCanvas());
            this.points.Add(this.toItem.GetLocationInCanvas());
        }
    }
}
