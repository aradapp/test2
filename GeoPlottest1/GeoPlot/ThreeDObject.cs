using System;
using System.Collections;
using System.Drawing;

namespace GeoPlot
{
    /// ************************ 3D - Modeling Library ********************
    /// By Michael Gold
    /// Copyright 2002.  All Rights Reserved
    /// *********************************************************

    /// <summary>
    /// Summary description for ThreeDObject.
    /// </summary>
    public class ThreeDObject : ICloneable
    {
        public ArrayList Polygons = new ArrayList();
        public ThreeDObject OriginalObject = null;

        public ThreeDObject()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        object ICloneable.Clone()
        {
            ThreeDObject copyObject = new ThreeDObject();
            for (int i = 0; i < Polygons.Count; i++)
            {
                copyObject.AddPolygon((ThreeDPolygon)(((ICloneable)Polygons[i]).Clone()));
            }

            return copyObject;

        }

        public void AddPolygon(ThreeDPoint[] points)
        {
            Polygons.Add(new ThreeDPolygon(points));
        }

        public void AddPolygon(ThreeDPolygon aPolygon)
        {
            Polygons.Add(aPolygon);
        }


        public ThreeDPoint GetCenter()
        {
            ThreeDPoint p = new ThreeDPoint(0, 0, 0, "0");
            for (int i = 0; i < Polygons.Count; i++)
            {
                p = p + ((ThreeDPolygon)Polygons[i]).GetCenter();
            }

            p.DivideThePoint(Polygons.Count);

            return p;

        }

        public void Transform(ThreeDMatrix m)
        {
            for (int i = 0; i < Polygons.Count; i++)
            {
                ((ThreeDPolygon)Polygons[i]).Transform(m);
            }
        }

        public void Scale(float val)
        {
            for (int i = 0; i < Polygons.Count; i++)
            {
                ((ThreeDPolygon)Polygons[i]).Scale(val);
            }
        }

        public void SortPolygonsInZOrder()
        {
            Polygons.Sort();
        }

        public void Translate(float[] v)
        {
            for (int i = 0; i < Polygons.Count; i++)
            {
                ((ThreeDPolygon)Polygons[i]).Translate(v);
            }
        }

        public void RotateAtX(ThreeDPoint p, float angle)
        {
            for (int i = 0; i < Polygons.Count; i++)
            {
                ((ThreeDPolygon)Polygons[i]).RotateAtX(p, angle);
            }
        }

        public void RotateAtXNegative(ThreeDPoint p, float angle)
        {
            for (int i = 0; i < Polygons.Count; i++)
            {
                ((ThreeDPolygon)Polygons[i]).RotateAtXNegative(p, angle);
            }
        }
        public void RotateAtY(ThreeDPoint p, float angle)
        {
            for (int i = 0; i < Polygons.Count; i++)
            {
                ((ThreeDPolygon)Polygons[i]).RotateAtY(p, angle);
            }
        }
        public void RotateAtYNegative(ThreeDPoint p, float angle)
        {
            for (int i = 0; i < Polygons.Count; i++)
            {
                ((ThreeDPolygon)Polygons[i]).RotateAtYNegative(p, angle);
            }
        }
        public void RotateAtZ(ThreeDPoint p, float angle)
        {
            for (int i = 0; i < Polygons.Count; i++)
            {
                ((ThreeDPolygon)Polygons[i]).RotateAtZ(p, angle);
            }
        }
        public void RotateAtZNegative(ThreeDPoint p, float angle)
        {
            for (int i = 0; i < Polygons.Count; i++)
            {
                ((ThreeDPolygon)Polygons[i]).RotateAtZNegative(p, angle);
            }
        }
        public void Draw(Graphics g)
        {
            for (int i = 0; i < Polygons.Count; i++)
            {
                ((ThreeDPolygon)Polygons[i]).Draw(g);
                //((ThreeDPolygon)Polygons[i]).Fill(g, Color.FromArgb(i*30 + 50, i*30 + 50, i*30 + 50));
            }
        }
    }
}
