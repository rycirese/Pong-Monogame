using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace Thomas
{
	public class DrawComponent : Component
	{
        private Texture2D texture;
        private Color color;
        private float rotation;
        private Vector2? scale;
        private float layerDepth;

        public DrawComponent(Entity entity, string texture, Color color, float rotation, Vector2? scale, float layerDepth) : base("DrawComponent")
		{
			this.entity = entity;

			this.texture = ContentManagerUtil.Content.Load<Texture2D>(texture);
            this.color = color;
            this.rotation = rotation;
            this.scale = scale;
            this.layerDepth = layerDepth;
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
