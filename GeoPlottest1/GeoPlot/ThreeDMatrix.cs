using System;

namespace GeoPlot
{
    /// ************************ 3D - Modeling Library ********************
    /// By Michael Gold
    /// Copyright 2002.  All Rights Reserved
    /// *********************************************************

    /// <summary>
    /// Summary description for ThreeDMatrix.
    /// </summary>
    public class ThreeDMatrix
    {
        public float[,] Elements = new float[4, 4];

        public ThreeDMatrix()
        {
            SetToIdentity();
        }

        public void SetToIdentity()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == j)
                    {
                        Elements[i, j] = 1;
                    }
                    else
                    {
                        Elements[i, j] = 0;
                    }
                }
            }

        }


        public ThreeDMatrix(float m11, float m12, float m13, float m14,
                            float m21, float m22, float m23, float m24,
                            float m31, float m32, float m33, float m34,
                            float m41, float m42, float m43, float m44)
        {
            Elements[0, 0] = m11;
            Elements[0, 1] = m12;
            Elements[0, 2] = m13;
            Elements[0, 3] = m14;
            Elements[1, 0] = m21;
            Elements[1, 1] = m22;
            Elements[1, 2] = m23;
            Elements[1, 3] = m24;
            Elements[2, 0] = m31;
            Elements[2, 1] = m32;
            Elements[2, 2] = m33;
            Elements[2, 3] = m34;
            Elements[3, 0] = m41;
            Elements[3, 1] = m42;
            Elements[3, 2] = m43;
            Elements[3, 3] = m44;
            //
            // TODO: Add constructor logic here
            //
        }

        public static ThreeDMatrix operator *(ThreeDMatrix m1, ThreeDMatrix m2)
        {
            ThreeDMatrix result = new ThreeDMatrix();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result.Elements[i, j] += m1.Elements[i, j] * m2.Elements[j, i];
                }
            }

            return result;
        }

        public float[] VectorMultiply(float[] vector)
        {
            float[] result = new float[4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i] += vector[j] * Elements[j, i];
                }
            }

            return result;
        }

        public void SetToXAxisRotation(float angle)
        {
            SetToIdentity();
            Elements[1, 1] = (float)Math.Cos(2 * Math.PI * angle / 360.0f);
            Elements[1, 2] = (float)Math.Sin(2 * Math.PI * angle / 360.0f);
            Elements[1, 3] = -(float)Math.Sin(2 * Math.PI * angle / 360.0f);
            Elements[3, 3] = (float)Math.Cos(2 * Math.PI * angle / 360.0f);
        }
        public void SetToNegativeXAxisRotation(float angle)
        {
            SetToIdentity();
            Elements[1, 1] = (float)Math.Cos(2 * Math.PI * angle / 360.0f);
            Elements[2, 1] = (float)Math.Sin(2 * Math.PI * angle / 360.0f);
            Elements[1, 2] = -(float)Math.Sin(2 * Math.PI * angle / 360.0f);
            Elements[2, 2] = (float)Math.Cos(2 * Math.PI * angle / 360.0f);
        }
        public void SetToYAxisRotation(float angle)
        {
            SetToIdentity();
            Elements[0, 0] = (float)Math.Cos(2 * Math.PI * angle / 360.0f);
            Elements[0, 2] = -(float)Math.Sin(2 * Math.PI * angle / 360.0f);
            Elements[2, 0] = (float)Math.Sin(2 * Math.PI * angle / 360.0f);
            Elements[2, 2] = (float)Math.Cos(2 * Math.PI * angle / 360.0f);
        }
        public void SetToNegativeYAxisRotation(float angle)
        {
            SetToIdentity();
            Elements[0, 0] = (float)Math.Cos(2 * Math.PI * angle / 360.0f);
            Elements[2, 0] = -(float)Math.Sin(2 * Math.PI * angle / 360.0f);
            Elements[0, 2] = (float)Math.Sin(2 * Math.PI * angle / 360.0f);
            Elements[2, 2] = (float)Math.Cos(2 * Math.PI * angle / 360.0f);
        }
        public void SetToZAxisRotation(float angle)
        {
            SetToIdentity();
            Elements[0, 0] = (float)Math.Cos(2 * Math.PI * angle / 360.0f);
            Elements[0, 1] = (float)Math.Sin(2 * Math.PI * angle / 360.0f);
            Elements[1, 0] = -(float)Math.Sin(2 * Math.PI * angle / 360.0f);
            Elements[1, 1] = (float)Math.Cos(2 * Math.PI * angle / 360.0f);
        }
        public void SetToNegativeZAxisRotation(float angle)
        {
            SetToIdentity();
            Elements[0, 0] = (float)Math.Cos(2 * Math.PI * angle / 360.0f);
            Elements[1, 0] = (float)Math.Sin(2 * Math.PI * angle / 360.0f);
            Elements[0, 1] = -(float)Math.Sin(2 * Math.PI * angle / 360.0f);
            Elements[1, 1] = (float)Math.Cos(2 * Math.PI * angle / 360.0f);
        }

        public void SetToScale(float scale)
        {
            SetToIdentity();
            Elements[0, 0] = scale;
            Elements[1, 1] = scale;
            Elements[2, 2] = scale;
            Elements[3, 3] = scale;
        }

        public void SetToTranslate(float[] v)
        {
            SetToIdentity();
            Elements[3, 0] = v[0];
            Elements[3, 1] = v[1];
            Elements[3, 2] = v[2];
        }




    }
}
