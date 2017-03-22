using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Thomas
{
    public static class Draw
    {
        /// <summary>
        /// All 2D rendering is done through this SpriteBatch instance
        /// </summary>
        static public SpriteBatch spriteBatch { get; private set; }

        static internal void Initialize(GraphicsDevice graphicsDevice)
        {
            spriteBatch = new SpriteBatch(graphicsDevice);
        }
    }
}
