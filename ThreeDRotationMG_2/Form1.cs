using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace ThreeDRotation
{
	/// ************************ 3D - Modeling Library ********************
	/// By Michael Gold
	/// Copyright 2002.  All Rights Reserved
	/// *********************************************************

	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;

		private ThreeDObject TheCube = new ThreeDObject();
		private ThreeDObject TheCubeOriginal = new ThreeDObject();
		private System.Windows.Forms.Timer timer1;
		public int AngleCount = 0;
        ThreeDPoint point1 = new ThreeDPoint(0, 2, 4);
        ThreeDPoint point2 = new ThreeDPoint(0, 2, 0);
        ThreeDPoint point1or = new ThreeDPoint(0, 2, 4);
        ThreeDPoint point2or = new ThreeDPoint(0, 2, 0);
        ThreeDPoint point = new ThreeDPoint(0, 0, 0);
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        List<ThreeDPoint> points = new List<ThreeDPoint>();
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// reduce flicker

			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.DoubleBuffer, true);

			CreateCube();

			TheCube = (ThreeDObject)((ICloneable)TheCubeOriginal).Clone(); // recopy original object
            point1 = (ThreeDPoint)((ICloneable)point1or).Clone();
            point2 = (ThreeDPoint)((ICloneable)point2or).Clone();
			timer1.Start();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            point.Scale(100);
            point.Translate(new float[] { 150, 150, 0 });
            point1.Scale(100);
            point1.Translate(new float[]{150, 150, 0});
            point2.Scale(100);
            point2.Translate(new float[] { 150, 150, 0 });
            createNetwork();
            point1or = (ThreeDPoint)((ICloneable)point1).Clone();
            point2or = (ThreeDPoint)((ICloneable)point2).Clone(); 
        }
        private void createNetwork()
        {
            ThreeDPoint point1 = new ThreeDPoint(0, 0, 1);
            ThreeDPoint point2 = new ThreeDPoint(1, 0, 0);
            ThreeDPoint point = new ThreeDPoint(0, 0, 0);
            point.Scale(100);
            point.Translate(new float[] { 150, 150, 0 });
            points.Add(point);
            point1.Scale(100);
            point1.Translate(new float[] { 150, 150, 0 });
            points.Add(point1);
            point2.Scale(100);
            point2.Translate(new float[] { 150, 150, 0 });
            points.Add(point2);
        }
		private void OffsetWorldCoordinatesNegativeY(Graphics g)
		{
			g.Transform = new Matrix(1, 0, 0, -1, 0, 0);
			g.TranslateTransform(0, ClientRectangle.Height,
				MatrixOrder.Append);
		}


		private void CreateCube()
		{


			TheCube.AddPolygon(new ThreeDPoint[]{
													new ThreeDPoint(0, 0, 0), 
													new ThreeDPoint(0, 1, 0), 
													new ThreeDPoint(1, 1, 0), 
													new ThreeDPoint(1, 0, 0),
													new ThreeDPoint(0, 0, 0)
												}); 


			TheCube.AddPolygon(new ThreeDPoint[]{
													new ThreeDPoint(0, 0, 0), 
													new ThreeDPoint(0, 0, 1), 
													new ThreeDPoint(0, 1, 1), 
													new ThreeDPoint(0, 1, 0), 
													new ThreeDPoint(0, 0, 0)}); 

			TheCube.AddPolygon(new ThreeDPoint[]{
													new ThreeDPoint(0, 0, 0), 
													new ThreeDPoint(0, 0, 1), 
													new ThreeDPoint(1, 0, 1), 
													new ThreeDPoint(1, 0, 0), 
													new ThreeDPoint(0, 0, 0)}); 



			TheCube.AddPolygon(new ThreeDPoint[]{
													new ThreeDPoint(1, 1, 0), 
													new ThreeDPoint(1, 1, 1), 
													new ThreeDPoint(0, 1, 1), 
													new ThreeDPoint(0, 1, 0),
													new ThreeDPoint(1, 1, 0)
												}); 

			TheCube.AddPolygon(new ThreeDPoint[]{
													new ThreeDPoint(1, 0, 0), 
													new ThreeDPoint(1, 0, 1), 
													new ThreeDPoint(1, 1, 1), 
													new ThreeDPoint(1, 1, 0),
													new ThreeDPoint(1, 0, 0)
												}); 

			TheCube.AddPolygon(new ThreeDPoint[]{
													new ThreeDPoint(0, 0, 1f), 
													new ThreeDPoint(0, 1, 1f), 
													new ThreeDPoint(1, 1, 1f), 
													new ThreeDPoint(1, 0, 1f),
													new ThreeDPoint(0, 0, 1f)
												}); 





			TheCube.Scale(100);
			TheCube.Translate(new float[]{150, 150, 0});
            TheCubeOriginal = (ThreeDObject)((ICloneable)TheCube).Clone();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "+X Rotation";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(319, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "+Y Rotation";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(580, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "+Z Rotation";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(400, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "- Y Rotation";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(661, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "-Z rotation";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(106, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "-X Rotation";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(813, 561);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "3-D Rotation of a Cube";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			OffsetWorldCoordinatesNegativeY(g);

            g.FillRectangle(Brushes.Black, ClientRectangle);
            TheCube.Draw(g);
            //g.DrawEllipse(Pens.Red, point.To2D(TheCube.GetCenter()).X, point.To2D(TheCube.GetCenter()).Y, 5F, 5F);
            g.DrawLine(Pens.White, point1.To2D(TheCube.GetCenter()), point2.To2D(TheCube.GetCenter()));
            //foreach (ThreeDPoint item in points)
            //{
            //    g.DrawEllipse(Pens.Red, item.To2D(TheCube.GetCenter()).X, item.To2D(TheCube.GetCenter()).Y, 5F, 5F);
            //}
		}

		private void trackBar1_Scroll(object sender, System.EventArgs e)
		{
		}

		private void trackBar1_ValueChanged(object sender, System.EventArgs e)
		{
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
            TheCube = (ThreeDObject)((ICloneable)TheCubeOriginal).Clone(); // recopy original object
            TheCube.SortPolygonsInZOrder();
            TheCube.RotateAtX(TheCube.GetCenter(), AngleCount);
			AngleCount += 1;
			Invalidate();

		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
            //TheCube = (ThreeDObject)((ICloneable)TheCubeOriginal).Clone(); // recopy original object
            //point1 = (ThreeDPoint)((ICloneable)point1or).Clone();
            //point2 = (ThreeDPoint)((ICloneable)point2or).Clone(); 
            //TheCube.SortPolygonsInZOrder();
            //TheCube.RotateAtX(TheCube.GetCenter(), AngleCount);
            //point1.RotateAtX(TheCube.GetCenter(), AngleCount);
            //point2.RotateAtX(TheCube.GetCenter(), AngleCount);
            //AngleCount += 1;
            //Invalidate();
		}

		private void button1_Click_1(object sender, System.EventArgs e)
		{
            //TheCube = (ThreeDObject)((ICloneable)TheCubeOriginal).Clone(); // recopy original object
            //TheCube.SortPolygonsInZOrder();
            //TheCube.RotateAtX(TheCube.GetCenter(), AngleCount);
            //AngleCount += 1;
            //Invalidate();
		}

        public void topView()
        {
            TheCube = (ThreeDObject)((ICloneable)TheCubeOriginal).Clone(); // recopy original object
            //TheCube.SortPolygonsInZOrder();
            TheCube.RotateAtX(TheCube.GetCenter(), AngleCount);
            AngleCount += 20;
            Invalidate();
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            topView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TheCube = (ThreeDObject)((ICloneable)TheCubeOriginal).Clone(); // recopy original object
            TheCube.SortPolygonsInZOrder();
            TheCube.RotateAtY(TheCube.GetCenter(), AngleCount);
            AngleCount += 20;
            Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TheCube = (ThreeDObject)((ICloneable)TheCubeOriginal).Clone(); // recopy original object
            point1 = (ThreeDPoint)((ICloneable)point1or).Clone();
            point2 = (ThreeDPoint)((ICloneable)point2or).Clone(); 
            TheCube.SortPolygonsInZOrder();
            TheCube.RotateAtZ(TheCube.GetCenter(), AngleCount);
            point1.RotateAtZ(TheCube.GetCenter(), AngleCount);
            point2.RotateAtZ(TheCube.GetCenter(), AngleCount);
            AngleCount += 20;
            Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TheCube = (ThreeDObject)((ICloneable)TheCubeOriginal).Clone(); // recopy original object
            TheCube.SortPolygonsInZOrder();
            TheCube.RotateAtYNegative(TheCube.GetCenter(), AngleCount);
            AngleCount += 20;
            Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            TheCube = (ThreeDObject)((ICloneable)TheCubeOriginal).Clone(); // recopy original object
            TheCube.SortPolygonsInZOrder();
            TheCube.RotateAtZNegative(TheCube.GetCenter(), AngleCount);
            AngleCount += 20;
            Invalidate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TheCube = (ThreeDObject)((ICloneable)TheCubeOriginal).Clone(); // recopy original object
            TheCube.SortPolygonsInZOrder();
            TheCube.RotateAtXNegative(TheCube.GetCenter(), AngleCount);
            AngleCount += 20;
            Invalidate();
        }
	}
}
