namespace Diagram.WindowsFormsApplication.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvas1 = new Diagram.WindowsFormsApplication.Controls.Canvas();
            this.tableEntity1 = new Diagram.WindowsFormsApplication.Controls.TableEntity();
            this.canvas1.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas1
            // 
            this.canvas1.AllowDrop = true;
            this.canvas1.AutoScroll = true;
            this.canvas1.BackColor = System.Drawing.Color.White;
            this.canvas1.Controls.Add(this.tableEntity1);
            this.canvas1.Location = new System.Drawing.Point(300, 12);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(451, 398);
            this.canvas1.TabIndex = 0;
            // 
            // tableEntity1
            // 
            this.tableEntity1.BackColor = System.Drawing.Color.White;
            this.tableEntity1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableEntity1.Location = new System.Drawing.Point(141, 135);
            this.tableEntity1.Name = "tableEntity1";
            this.tableEntity1.Size = new System.Drawing.Size(148, 148);
            this.tableEntity1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 457);
            this.Controls.Add(this.canvas1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.canvas1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Canvas canvas1;
        private Controls.TableEntity tableEntity1;





    }
}