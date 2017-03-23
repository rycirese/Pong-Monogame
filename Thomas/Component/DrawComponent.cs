using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Diagnostics;

namespace Thomas
{
	public class DrawComponent : Component
	{
		private Texture2D texture;

		public DrawComponent(Entity entity, string spriteName) : base("DrawComponent")
		{
			this.entity = entity;

			texture = ContentManagerUtil.Content.Load<Texture2D>(spriteName);
        }

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);

			spriteBatch.Draw(texture, ((PositionComponent)entity.GetComponent("PositionComponent")).position, Color.White);
		}

		public int getTextureWidth() { return texture.Width; }

		public int getTextureHeight() { return texture.Height; }

	}
}
