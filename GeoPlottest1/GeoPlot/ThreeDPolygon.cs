using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;

namespace GeoPlot
{
    /// ************************ 3D - Modeling Library ********************
    /// By Michael Gold
    /// Copyright 2002.  All Rights Reserved
    /// *********************************************************

    /// <summary>
    /// Summary description for ThreeDPolygon.
    /// </summary>
    public class ThreeDPolygon : IComparable, ICloneable
    {
        public Color TheColor = Color.White;
        public ArrayList Vertices = new ArrayList();
        public ThreeDPolygon()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        // since the # of vertices are the same
        // this gives the approximate z-order of the plane
        float GetZSum(ThreeDPolygon p)
        {
            float sum = 0.0f;
            for (int i = 0; i < Vertices.Count; i++)
            {
                sum += ((ThreeDPoint)p.Vertices[i]).Z;
            }

            return sum;
        }

        float GetXSum(ThreeDPolygon p)
        {
            float sum = 0.0f;
            for (int i = 0; i < Vertices.Count; i++)
            {
                sum += ((ThreeDPoint)p.Vertices[i]).X;
            }

            return sum;
        }

        float GetYSum(ThreeDPolygon p)
        {
            float sum = 0.0f;
            for (int i = 0; i < Vertices.Count; i++)
            {
                sum += ((ThreeDPoint)p.Vertices[i]).Y;
            }

            return sum;
        }

        object ICloneable.Clone()
        {
            ThreeDPolygon copyObject = new ThreeDPolygon();
            for (int i = 0; i < Vertices.Count; i++)
            {
                copyObject.Vertices.Add(((ICloneable)Vertices[i]).Clone());
            }

            return copyObject;

        }



        int IComparable.CompareTo(object obj)
        {
            ThreeDPolygon ptest = (ThreeDPolygon)obj; // unbox
            float sum1 = GetZSum(this);
            float sum2 = GetZSum(ptest);
            if (sum1 > sum2)
            {
                return 1;
            }

            if (sum1 == sum2)
            {
                sum1 = GetXSum(this);
                sum2 = GetXSum(ptest);
                if (sum1 > sum2)
                {
                    return 1;
                }
            }

            if (sum1 == sum2)
            {
                sum1 = GetYSum(this);
                sum2 = GetYSum(ptest);
                if (sum1 > sum2)
                {
                    return 1;
                }
            }


            return -1;
        }

        ThreeDPoint GetLeftmostPoint()
        {

            string nodemin = null;
            float xmin = 1000;
            float ymin = 1000;
            float zmin = 1000;
            for (int i = 0; i < Vertices.Count; i++)
            {
                ThreeDPoint nextPoint = (ThreeDPoint)Vertices[i];
                if (nextPoint.X < xmin)
                    xmin = nextPoint.X;
                if (nextPoint.Y < ymin)
                    ymin = nextPoint.Y;
                if (nextPoint.Z < zmin)
                    zmin = nextPoint.Z;
            }

            ThreeDPoint origin = new ThreeDPoint(xmin, ymin, zmin, nodemin);
            return origin;
        }

        public ThreeDPolygon(ThreeDPoint[] v)
        {
            for (int i = 0; i < v.Length; i++)
                Vertices.Add(v[i]);
        }


        public void AddPoint(float x, float y, float z, string nodeno)
        {
            ThreeDPoint aPoint = new ThreeDPoint(x, y, z, nodeno);
            Vertices.Add(aPoint);
        }

        public void Transform(ThreeDMatrix m)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                ((ThreeDPoint)Vertices[i]).Transform(m);
            }
        }

        public void Scale(float val)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                ((ThreeDPoint)Vertices[i]).Scale(val);
            }
        }

        public void Translate(float[] v)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                ((ThreeDPoint)Vertices[i]).Translate(v);
            }
        }

        public void RotateAtX(ThreeDPoint origin, float angle)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                ((ThreeDPoint)Vertices[i]).RotateAtX(origin, angle);
            }
        }

        public void RotateAtXNegative(ThreeDPoint origin, float angle)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                ((ThreeDPoint)Vertices[i]).RotateAtXNegative(origin, angle);
            }
        }

        public void RotateAtY(ThreeDPoint origin, float angle)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                ((ThreeDPoint)Vertices[i]).RotateAtY(origin, angle);
            }
        }

        public void RotateAtYNegative(ThreeDPoint origin, float angle)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                ((ThreeDPoint)Vertices[i]).RotateAtYNegative(origin, angle);
            }
        }

        public void RotateAtZ(ThreeDPoint origin, float angle)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                ((ThreeDPoint)Vertices[i]).RotateAtZ(origin, angle);
            }
        }

        public void RotateAtZNegative(ThreeDPoint origin, float angle)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                ((ThreeDPoint)Vertices[i]).RotateAtZNegative(origin, angle);
            }
        }

        public ThreeDPoint GetCenter()
        {
            ThreeDPoint p = new ThreeDPoint(0, 0, 0, null);
            for (int i = 0; i < Vertices.Count; i++)
            {
                p = p + (ThreeDPoint)Vertices[i];
            }

            p.DivideThePoint(Vertices.Count);

            return p;

        }

        PointF[] GetVertices2D()
        {
            PointF[] points = new PointF[Vertices.Count];
            for (int i = 0; i < Vertices.Count; i++)
            {
                points[i] = ((ThreeDPoint)Vertices[i]).To2D(GetCenter());
            }

            return points;

        }

        public void Fill(Graphics g, Color aColor)
        {
            // create a polygon in 2d from 3d points
            PointF[] vertices2d = GetVertices2D();
            g.FillPolygon(new SolidBrush(aColor), vertices2d, FillMode.Alternate);
        }

        public void Draw(Graphics g)
        {
            Pen aPen = new Pen(TheColor, 1);
            for (int i = 0; i < Vertices.Count - 1; i++)
            {
                g.DrawLine(aPen,
                    ((ThreeDPoint)Vertices[i]).To2D(GetCenter()),
                    ((ThreeDPoint)Vertices[i + 1]).To2D(GetCenter()));

            }

            aPen.Dispose();
        }
    }
}
