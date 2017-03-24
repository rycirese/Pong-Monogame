using Microsoft.Xna.Framework;

namespace Thomas
{
	public class PositionComponent : Component
	{
        public Vector2 origin;
		public Vector2 position;

		public PositionComponent(Entity entity) : base("PositionComponent")
		{
			this.entity = entity;

            origin = new Vector2();
			position = new Vector2();
		}
	}
}
