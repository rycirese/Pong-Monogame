using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Thomas
{
    public static class DrawUtil
    {
        /// <summary>
        /// All 2D rendering is done through this SpriteBatch instance
        /// </summary>
        static public SpriteBatch SpriteBatch { get; private set; }

        static internal void Initialize(GraphicsDevice graphicsDevice)
        {
            SpriteBatch = new SpriteBatch(graphicsDevice);
        }
    }
}
