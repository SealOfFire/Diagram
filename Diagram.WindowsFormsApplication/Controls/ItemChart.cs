using Diagram.DataFormat;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Diagram.WindowsFormsApplication.Controls
{
    public class ItemChart : Label
    {
        private Guid identity;
        private ColumnEntity column;
        private EntityChart parent;

        public Guid Identity { get { return this.identity; } }

        public ColumnEntity Column
        {
            get { return this.column; }
            set { this.column = value; this.identity = value.Identity; }
        }

        public override string Text
        {
            get
            {
                return column.ToString();
                // return column.ToString().Replace(' ', '|');
            }
        }

        public ItemChart(string text, EntityChart entity, ColumnEntity column)
        {
            this.InitializeComponent();
            this.Text = text;
            this.parent = entity;
            this.column = column;
        }

        public ItemChart(EntityChart entity, ColumnEntity column)
        {
            this.InitializeComponent();
            this.parent = entity;
            this.column = column;
            this.identity = column.Identity;
        }

        public void InitializeComponent()
        {
            this.AutoSize = true;
            this.BackColor = Color.AliceBlue;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        }

        public Point GetLocationInCanvas()
        {
            Point location = new Point();
            if (this.Parent is TableLayoutPanel)
            {
                TableLayoutPanel p1 = this.Parent as TableLayoutPanel;
                location.X = p1.Location.X + this.Location.X;
                location.Y = p1.Location.Y + this.Location.Y;
                if (p1.Parent is EntityChart)
                {
                    EntityChart p2 = p1.Parent as EntityChart;
                    location.X += p2.Location.X;
                    location.Y += p2.Location.Y;
                }
            }
            return location;
        }
    }
}
