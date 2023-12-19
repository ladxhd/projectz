using Microsoft.Xna.Framework;
using System;

namespace ProjectZ.Base
{
    public struct Box
    {
        public static readonly Box Empty = new Box();

        public float X;
        public float Y;
        public float Z;

        public float Width;
        public float Height;
        public float Depth;

        public float Left => X;
        public float Right => X + Width;

        public float Back => Y;
        public float Front => Y + Height;

        public float Top => Z + Depth;
        public float Bottom => Z;

        public Vector2 Center => new Vector2(X + Width / 2, Y + Height / 2);

        public RectangleF Rectangle() => new RectangleF(X, Y, Width, Height);

        public Box(float x, float y, float z, float width, float height, float depth)
        {
            X = x;
            Y = y;
            Z = z;

            Width = width;
            Height = height;
            Depth = depth;
        }

        public bool Intersects(Box value)
        {
            return value.Left < Right && Left < value.Right &&
                   value.Back < Front && Back < value.Front &&
                   value.Bottom < Top && Bottom < value.Top;
        }

        public bool Contains(Box value)
        {
            return Left <= value.Left && value.Right <= Right &&
                   Back <= value.Back && value.Front <= Front &&
                   Bottom <= value.Bottom && value.Top <= Top;
        }

        public bool Contains(Vector2 value)
        {
            return Left <= value.X && value.X <= Right &&
                   Back <= value.Y && value.Y <= Front;
        }

        public override bool Equals(object obj)
        {
            return obj is Box box &&
                   X == box.X &&
                   Y == box.Y &&
                   Z == box.Z &&
                   Width == box.Width &&
                   Height == box.Height &&
                   Depth == box.Depth &&
                   Left == box.Left &&
                   Right == box.Right &&
                   Back == box.Back &&
                   Front == box.Front &&
                   Top == box.Top &&
                   Bottom == box.Bottom &&
                   Center.Equals(box.Center);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(X);
            hash.Add(Y);
            hash.Add(Z);
            hash.Add(Width);
            hash.Add(Height);
            hash.Add(Depth);
            hash.Add(Left);
            hash.Add(Right);
            hash.Add(Back);
            hash.Add(Front);
            hash.Add(Top);
            hash.Add(Bottom);
            hash.Add(Center);
            return hash.ToHashCode();
        }

        public static bool operator ==(Box a, Box b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z &&
                   a.Width == b.Width && a.Height == b.Height && a.Depth == b.Depth;
        }

        public static bool operator !=(Box a, Box b)
        {
            return a.X != b.X || a.Y != b.Y || a.Z != b.Z &&
                   a.Width != b.Width || a.Height != b.Height || a.Depth != b.Depth;
        }
    }
}
