using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Thomas
{
    public class Component
    {
		public Entity entity;
		public string ID { get; }

		public Component(string ID)
		{
			this.ID = ID;
		}

		public virtual void LoadContent() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
