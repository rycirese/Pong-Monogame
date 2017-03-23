using Microsoft.Xna.Framework;

namespace Thomas
{
	public class PositionComponent : Component
	{

		public Vector2 position;
		public float rotation;

		public PositionComponent(Entity entity) : base("PositionComponent")
		{
			this.entity = entity;

			position = new Vector2();
			rotation = 0;
		}
	}
}
