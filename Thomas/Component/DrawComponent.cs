using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace Thomas
{
	public class DrawComponent : Component
	{
        private Texture2D texture;
        private Color color;

        public DrawComponent(Entity entity, ContentManager Content, string texture, Color color) : base("DrawComponent")
		{
			this.entity = entity;

			this.texture = Content.Load<Texture2D>(texture);
            this.color = color;
        }

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
            spriteBatch.Draw(texture, entity.Get<PositionComponent>().position, color);
        }

		public int GetTextureWidth() { return texture.Width; }

		public int GetTextureHeight() { return texture.Height; }

	}
}
