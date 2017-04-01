using Microsoft.Xna.Framework;

using System.Diagnostics;

namespace Thomas
{
    public class Collider
    {
		Entity entity;
		public Rectangle rectangle;
    
		public Collider(Entity entity, float x, float y, float width, float height)
		{
			this.entity = entity;
			rectangle = new Rectangle((int)x, (int)y, (int)width, (int)height);
		}

		public void Update()
		{
			rectangle.X = (int)entity.Get<PositionComponent>().position.X;
			rectangle.Y = (int)entity.Get<PositionComponent>().position.Y;
		}

		public bool Collide(Collider a)
		{
			if (rectangle.Intersects(a.rectangle)) return true;
			return false;
		}

		public int Width()
		{
			return rectangle.Width;
		}
		
		public int Height()
		{
			return rectangle.Height;
		}

		public int Left()
		{
			return rectangle.Left;
		}
		
		public int Right()
		{
			return rectangle.Right;
		}

		public int Top()
		{
			return rectangle.Top;
		}

		public int Bottom()
		{
			return rectangle.Bottom;
		}

		public Point Center()
		{
			return rectangle.Center;
		}
    }
}
