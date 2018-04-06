using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GeoPlot
{
    public partial class Default : Form
    {
        public float rotateAngle = 0.0F;
        public float rotateAngleLeft = 0.0F;
        public int AngleCount = 0;
        private ThreeDObject TheCube = new ThreeDObject();
        public ThreeDObject TheCubeOriginal = new ThreeDObject();
        private System.Windows.Forms.Timer timer1;
        public List<KeyValuePair<string, string>> pointmember = new List<KeyValuePair<string, string>>();
        public List<KeyValuePair<string, string>> pointsmemberOr = new List<KeyValuePair<string, string>>();
        public List<ThreeDPoint> points = new List<ThreeDPoint>();
        public List<ThreeDPoint> pointsor = new List<ThreeDPoint>();
        //public List<ThreeDPoint> points2 = new List<ThreeDPoint>();
        //public List<ThreeDPoint> points2or = new List<ThreeDPoint>();
        Matrix mat = new Matrix(2, 2, 2, 2, 100, 100);
        private System.ComponentModel.IContainer components;
        public Default()
        {
            InitializeComponent();
            this.pictureBox1.MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);
            points = new List<ThreeDPoint>(pointsor);
            pointmember = new List<KeyValuePair<string, string>>(pointsmemberOr);
            TheCube = (ThreeDObject)((ICloneable)TheCubeOriginal).Clone(); // recopy original object  
            //points = (List<ThreeDPoint>)((ICloneable)pointsor).Clone();
            ////points2 = (List<ThreeDPoint>)((ICloneable)points2or).Clone();
            //pointmember = (List<KeyValuePair<string, string>>)((ICloneable)pointsmemberOr).Clone();

        }

        void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            ////pictureBox1.Focus();
            ////if (pictureBox1.Focused == true && e.Delta != 0)
            ////{
            ////    ZoomInScroll(e.Location, e.Delta > 0);
            ////}
            //float oldzoom = zoom;

            //if (e.Delta > 0)
            //{
            //    zoom += 0.1F;
            //}

            //else if (e.Delta < 0)
            //{
            //    zoom = Math.Max(zoom - 0.1F, 0.01F);
            //}

            //MouseEventArgs mouse = e as MouseEventArgs;
            //Point mousePosNow = mouse.Location;

            //int x = mousePosNow.X - pictureBox1.Location.X;    // Where location of the mouse in the pictureframe
            //int y = mousePosNow.Y - pictureBox1.Location.Y;

            //int oldimagex = (int)(x / oldzoom);  // Where in the IMAGE is it now
            //int oldimagey = (int)(y / oldzoom);

            //int newimagex = (int)(x / zoom);     // Where in the IMAGE will it be when the new zoom i made
            //int newimagey = (int)(y / zoom);

            //imgx = newimagex - oldimagex + imgx;  // Where to move image to keep focus on one point
            //imgy = newimagey - oldimagey + imgy;

            //pictureBox1.Refresh(); 
        }
        public ThreeDPoint getXYZ(string n)
        {
            ThreeDPoint p = new ThreeDPoint(0, 0, 0, null);
            foreach (ThreeDPoint item in points)
            {
                if (item.nodeno.Equals(n))
                    return item;
            }
            return p;    
        }
        public KeyValuePair<string, string> getKVP(string n)
        {
          KeyValuePair<string, string> k = new KeyValuePair<string, string>(null,null);
            foreach(KeyValuePair<string,string> item in pointmember)
            {
                if(item.Key.Equals(n))
                    return item;
            }
            return k;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            g.TranslateTransform(80, 140);
            //g.Transform = transform;
            //g.ScaleTransform(zoom, zoom);
            g.ScaleTransform(2, 2);
            g.RotateTransform(rotateAngle);
            g.RotateTransform(rotateAngleLeft);
            foreach (ThreeDPoint item in points)
                {
                    g.DrawEllipse(Pens.Red, item.To2D(TheCube.GetCenter()).X - 1, item.To2D(TheCube.GetCenter()).Y - 1, 2F, 2F);
                }
            foreach (KeyValuePair<string,string> item in pointmember)
                {
                 ThreeDPoint p1 = getXYZ(item.Key);
                 ThreeDPoint p2 = getXYZ(item.Value);
                 g.DrawLine(Pens.Black, p1.To2D(TheCube.GetCenter()), p2.To2D(TheCube.GetCenter()));
                }

            TheCubeOriginal = (ThreeDObject)((ICloneable)TheCube).Clone();
        }
        private void ZoomInScroll(Point location, bool zoomIn)
        {
            //transform.Translate(-location.X, -location.Y);
            //pictureBox1.Invalidate();
            //if (zoomIn)
            //    transform.Scale((float)s_dScrollValue, (float)s_dScrollValue);
            //else
            //    transform.Scale(1 / (float)s_dScrollValue, 1 / (float)s_dScrollValue);
            //transform.Translate(location.X, location.Y);

            //pictureBox1.Invalidate();
        }

        private Matrix pictureScale(Single n, Single m, MatrixOrder order)
        {
            return mat;
            
        }
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }

        private void Default_Load(object sender, EventArgs e)
        {
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Show();
            //Timer timer1 = new Timer();
            //timer1.Tick += new EventHandler(timer1_Tick);
            //timer1.Interval = 10;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //TheCube = (ThreeDObject)((ICloneable)TheCubeOriginal).Clone(); // recopy original object
            //TheCube.SortPolygonsInZOrder();
            //TheCube.RotateAtX(TheCube.GetCenter(), AngleCount);
            //AngleCount += 1;
            //Invalidate();

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ////panning = true;
            ////startingPoint = new Point(e.Location.X - movingPoint.X, e.Location.Y - movingPoint.Y);
            //MouseEventArgs mouse = e as MouseEventArgs;

            //if (mouse.Button == MouseButtons.Left)
            //{
            //    if (!mousepressed)
            //    {
            //        mousepressed = true;
            //        mouseDown = mouse.Location;
            //        startx = imgx;
            //        starty = imgy;
            //    }
            //}
        }

        // to rotate image right

        public void rotateRight()
        {
            rotateAngle += 2.0F;
            if (rotateAngle > 180.0F)
            {
                rotateAngle = 0.0F;
            }
            pictureBox1.Invalidate();
        }

        //To Rotate image Left

        public void rotateLeft()
        {
            rotateAngleLeft += -2.0F;
            if (rotateAngleLeft < -180.0F)
            {
                rotateAngleLeft = 0.0F;
            }
            pictureBox1.Invalidate();
        }
        public void rotateUp()
        {
            TheCube = (ThreeDObject)((ICloneable)TheCubeOriginal).Clone(); // recopy original object
            points = new List<ThreeDPoint>(pointsor);
            pointmember = new List<KeyValuePair<string,string>>(pointsmemberOr);
            TheCube.SortPolygonsInZOrder();
            //TheCube.RotateAtXNegative(TheCube.GetCenter(), AngleCount);
            foreach (ThreeDPoint item in points)
            {
                item.RotateAtX(TheCube.GetCenter(), AngleCount);
                AngleCount += 1;
            }
            Invalidate();
        }

        public void rotateDown()
        {
            TheCube = (ThreeDObject)((ICloneable)TheCubeOriginal).Clone(); // recopy original object
            TheCube.SortPolygonsInZOrder();
            TheCube.RotateAtX(TheCube.GetCenter(), AngleCount);
            AngleCount += 1;
            Invalidate();
        }

        public void leftRotate()
        {
            
            TheCube = (ThreeDObject)((ICloneable)TheCubeOriginal).Clone(); // recopy original object
            TheCube.SortPolygonsInZOrder();
            TheCube.RotateAtYNegative(TheCube.GetCenter(), AngleCount);
            AngleCount += 1;
            Invalidate();
        }

        public void rightRotate()
        {
            TheCube = (ThreeDObject)((ICloneable)TheCubeOriginal).Clone(); // recopy original object
            TheCube.SortPolygonsInZOrder();
            TheCube.RotateAtY(TheCube.GetCenter(), AngleCount);
            AngleCount += 1;
            Invalidate();
        }

        public void spinLeft()
        {
            TheCube = (ThreeDObject)((ICloneable)TheCubeOriginal).Clone(); // recopy original object
            TheCube.SortPolygonsInZOrder();
            TheCube.RotateAtZ(TheCube.GetCenter(), AngleCount);
            AngleCount += 1;
            Invalidate();
        }

        public void spinRight()
        {
            TheCube = (ThreeDObject)((ICloneable)TheCubeOriginal).Clone(); // recopy original object
            TheCube.SortPolygonsInZOrder();
            TheCube.RotateAtZNegative(TheCube.GetCenter(), AngleCount);
            AngleCount += 1;
            Invalidate();
        }

        //private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        //{
        ////    panning = false;
        //    mousepressed = false;
        //}

//        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
//{
//    MouseEventArgs mouse = e as MouseEventArgs;

//    if (mouse.Button == MouseButtons.Left)
//    {
//        Point mousePosNow = mouse.Location;

//        int deltaX = mousePosNow.X - mouseDown.X; // the distance the mouse has been moved since mouse was pressed
//        int deltaY = mousePosNow.Y - mouseDown.Y;

//        imgx = (int)(startx + (deltaX / zoom));  // calculate new offset of image based on the current zoom factor
//        imgy = (int)(starty + (deltaY / zoom));

//        pictureBox1.Refresh();
    //}
    
        }
      
    }

