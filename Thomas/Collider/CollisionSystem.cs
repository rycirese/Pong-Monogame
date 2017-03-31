using System;
namespace Thomas
{
	public class CollisionSystem
	{
		public static bool checkCollision(Entity a, Entity b)
		{
			if (a.collider.rectangle.Intersects(b.collider.rectangle)) return true;
			return false;
		}
	}
}
