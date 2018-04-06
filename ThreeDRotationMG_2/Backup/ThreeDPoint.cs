using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ThreeDRotation
{
	/// ************************ 3D - Modeling Library ********************
	/// By Michael Gold
	/// Copyright 2002.  All Rights Reserved
	/// *********************************************************

	/// <summary>
	/// Summary description for ThreeDPoint.
	/// </summary>
	public class ThreeDPoint : ICloneable
	{
		public float X;
		public float Y;
		public float Z;
		public float Distance = 250.0f;
		public ThreeDMatrix RotationMatrix = new ThreeDMatrix();
		public ThreeDMatrix TransformMatrix = new ThreeDMatrix();

		public ThreeDPoint(float x, float y, float z)
		{
			X = x;
			Y = y;
			Z = z;
			//
			// TODO: Add constructor logic here
			//
		}

		object ICloneable.Clone()
		{
			ThreeDPoint copyObject = new ThreeDPoint(X, Y, Z);
			return copyObject;
		}


		public PointF To2D(ThreeDPoint origin)
		{
		  float zsmall = Z;

			if (zsmall == 0.0f)
			{
			  zsmall = 1.0f;
			}
//		  PointF aPoint = new PointF(Distance * X/zsmall, Distance * Y/zsmall);
		  PointF aPoint = new PointF(X * (1 - (Z/Distance)), Y * (1-Z/Distance));
		  return aPoint;
		}

//		public PointF To2D(ThreeDPoint origin)
//		{
//			float zsmall = Z - origin.Z;
//		if (zsmall < 0)
//				zsmall = -zsmall; // absolute value
//
//			if (zsmall == 0.0f)
//			{
//				zsmall = .02f;
//			}
//			PointF aPoint = new PointF(Distance * (X - origin.X)/zsmall, Distance * (Y - origin.Y)/zsmall);
//
//			aPoint.X += origin.X;
//			aPoint.Y += origin.Y;

//			return aPoint;
//		}


		public static ThreeDPoint operator -(ThreeDPoint p1, ThreeDPoint p2) 
		{ 
			return new ThreeDPoint(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
		} 

		public static ThreeDPoint operator +(ThreeDPoint p1, ThreeDPoint p2) 
		{ 
			return new ThreeDPoint(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
		} 

		public void Transform(ThreeDMatrix m)
		{
			float[] result = m.VectorMultiply(new float[]{X, Y, Z, 1});
			X = result[0];
			Y = result[1];
			Z = result[2];
		}

		public void DivideThePoint(float val)
		{
			X = X/val;
			Y = Y/val;
			Z = Z/val;
		}


		public void Scale(float val)
		{
			TransformMatrix.SetToScale(val);
			Transform(TransformMatrix);
		}

		public void Translate(float[] v)
		{
			TransformMatrix.SetToTranslate(v);
			Transform(TransformMatrix);
		}

		public void RotateAt(ThreeDPoint origin, float angle)
		{
			RotationMatrix.SetToXAxisRotation(angle);
			float[] result = RotationMatrix.VectorMultiply(new float[]{X-origin.X, Y-origin.Y, Z-origin.Z, 1});
			X = result[0] + origin.X;
			Y = result[1] + origin.Y;
			Z = result[2] + origin.Z;
		}


		public void RotateX(ThreeDPoint origin, float angle)
		{
			RotationMatrix.SetToXAxisRotation(angle);
			float[] result = RotationMatrix.VectorMultiply(new float[]{X-origin.X, Y-origin.Y, Z-origin.Z, 1});
			X = result[0] + origin.X;
			Y = result[1] + origin.Y;
			Z = result[2] + origin.Z;
		}
	}
}
