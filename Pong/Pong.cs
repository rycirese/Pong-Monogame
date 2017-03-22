using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Linq;

using Thomas;

namespace Pong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Pong : Engine
    {

        private Engine engine;
        
        public Pong() : base(Strings.Title, 640, 360, false, false)
        {
            engine = this;

            Entity test = new Entity();
            test.AddComponent(new Component());

            engine.AddEntity(test);
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
        }
    }
}
