using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

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


			timer1.Start();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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





			TheCube.Scale(60);
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
			// 
			// timer1
			// 
			this.timer1.Interval = 10;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Name = "Form1";
			this.Text = "3-D Rotation of a Cube";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);

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
			TheCube.RotateAt(TheCube.GetCenter(), AngleCount);
			AngleCount += 1;
			Invalidate();

		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			TheCube = (ThreeDObject)((ICloneable)TheCubeOriginal).Clone(); // recopy original object
			TheCube.SortPolygonsInZOrder();
			TheCube.RotateAt(TheCube.GetCenter(), AngleCount);
			AngleCount += 1;
			Invalidate();
		}

		private void button1_Click_1(object sender, System.EventArgs e)
		{
			TheCube = (ThreeDObject)((ICloneable)TheCubeOriginal).Clone(); // recopy original object
			TheCube.SortPolygonsInZOrder();
			TheCube.RotateAt(TheCube.GetCenter(), AngleCount);
			AngleCount += 1;
			Invalidate();
		}
	}
}
