using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Thomas
{
    public class Component
    {
        public virtual void LoadContent(ContentManager Content, string spriteName)
        {
            Content = new ContentManager(Content.ServiceProvider);
            Content.RootDirectory = "Content";
        }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
