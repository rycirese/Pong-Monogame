using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Diagnostics;
using System.Collections.Generic;

namespace Thomas
{
    public class Engine : Game
    {
		static public Engine instance;
		static public GraphicsDeviceManager graphics;
		public int Width;
        public int Height { get; private set; }
        public string Title;

        List<Entity> entities;

        public Engine(string title, int width, int height, bool fullscreen, bool borderless)
        {
            instance = this;
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";

            Title = title;
            Window.Title = Title;

            Width = width;
            Height = height;
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;

            if (fullscreen) graphics.IsFullScreen = true;
            else graphics.IsFullScreen = false;

            if (borderless) Window.IsBorderless = true;
            else Window.IsBorderless = false;
            
            entities = new List<Entity>();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            DrawUtil.Initialize(GraphicsDevice);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
		
            if (entities != null)
            {
                foreach (var e in entities)
                {
                    e.Update(gameTime);
                }
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            GraphicsDevice.Clear(Color.Black);
            
			DrawUtil.SpriteBatch.Begin(SpriteSortMode.BackToFront);

            if (entities != null)
            {
                foreach (var e in entities)
                {
                    if (e.drawable)
                    {
                        e.Draw(DrawUtil.SpriteBatch);
                    }
                }
            }

			DrawUtil.SpriteBatch.End();
        }

        public void AddEntity(Entity entity) 
        {
            if (!entities.Contains(entity))
            {
                entities.Add(entity);
            }
        }

        public void RemoveEntity(Entity entity)
        {
            if (entities.Contains(entity))
            {
                entities.Remove(entity);
            }
        }

		public Entity GetEntity(string id)
		{
			if (entities != null)
			{
				foreach (var e in entities)
				{
					if (e.ID.Equals(id)) return e;
				}
			}

			return null;
		}
    }
}
