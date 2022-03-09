using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDWGL
{
    public class Vector2
    {
        public int X;
        public int Y;

        public Vector2() { X = 0; Y = 0; }
        public Vector2(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public Vector2(int XY)
        {
            X = Y = XY;
        }
        public Vector2(Point point)
        {
            X = point.X;
            Y = point.Y;
        }
        public Vector2(Size size)
        {
            X = size.Width;
            Y = size.Height;
        }

        // Convertions
        public Point ToPoint() { return new Point(X, Y); }
        public Size ToSize() { return new Size(X, Y); }

        // Operation Overloads
        public static Vector2 operator +(Vector2 a, Vector2 b) { return new Vector2(a.X + b.X, a.Y + b.Y); }
        public static Vector2 operator -(Vector2 a, Vector2 b) { return new Vector2(a.X - b.X, a.Y - b.Y); }
        public static Vector2 operator *(Vector2 a, Vector2 b) { return new Vector2(a.X * b.X, a.Y * b.Y); }
        public static Vector2 operator /(Vector2 a, Vector2 b) { return new Vector2(a.X / b.X, a.Y / b.Y); }
        public static Vector2 operator %(Vector2 a, Vector2 b) { return new Vector2(a.X % b.X, a.Y % b.Y); }
        public static bool operator ==(Vector2 a, Vector2 b) 
        { 
            if(a.X == b.X && a.Y == b.Y) return true;
            return false;
        }
        public static bool operator !=(Vector2 a, Vector2 b)
        {
            if (a.X != b.X && a.Y != b.Y) return true;
            return false;
        }
        public static bool operator <(Vector2 a, Vector2 b)
        {
            if (a.X <= b.X && a.Y <= b.Y) return true;
            return false;
        }
        public static bool operator >(Vector2 a, Vector2 b)
        {
            if (a.X >= b.X && a.Y >= b.Y) return true;
            return false;
        }

        // Static Functions
        public static Vector2 Zero() { return new Vector2(0); }
        public static Vector2 One() { return new Vector2(1); }
    }
}
