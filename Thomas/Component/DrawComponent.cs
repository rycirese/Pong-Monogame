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
        private SpriteEffects spriteEffects;
        private float layerDepth;

        public DrawComponent(Entity entity, string texture, Color color, float rotation, Vector2? scale, float layerDepth) : base("DrawComponent")
		{
			this.entity = entity;

			this.texture = ContentManagerUtil.Content.Load<Texture2D>(texture);
            this.color = color;
            this.rotation = rotation;
            this.scale = scale;
            spriteEffects = SpriteEffects.None;
            this.layerDepth = layerDepth;
        }

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);

			spriteBatch.Draw(texture, ((PositionComponent)entity.GetComponent("PositionComponent")).position, null, null, ((PositionComponent)entity.GetComponent("PositionComponent")).origin, rotation, scale, color, spriteEffects, layerDepth);
        }

		public int GetTextureWidth() { return texture.Width; }

		public int GetTextureHeight() { return texture.Height; }

	}
}
