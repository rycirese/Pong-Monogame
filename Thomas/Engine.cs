using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Diagnostics;
using System.Collections.Generic;

namespace Thomas
{
    public class Engine : Game
    {
        static public Engine instance { get; private set; }
        static public GraphicsDeviceManager graphics { get; private set; }
        static public int width { get; private set; }
        static public int height { get; private set; }
        public string title;

        private List<Entity> entities;

        Texture2D texture;
        Vector2 position;

        public Engine(string title, int w, int h, bool fullscreen, bool borderless)
        {
            instance = this;
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";

            this.title = title;
            this.Window.Title = this.title;

            width = w;
            height = h;
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;

            if (fullscreen) graphics.IsFullScreen = true;
            else graphics.IsFullScreen = false;

            if (borderless) this.Window.IsBorderless = true;
            else this.Window.IsBorderless = false;

            Debug.WriteLine(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width);
            Debug.WriteLine(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);

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
            // TODO: Add your initialization logic here
            Thomas.Draw.Initialize(GraphicsDevice);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            texture = Content.Load<Texture2D>("Sprites/center");
            position = new Vector2((width / 2) - (texture.Width / 2), 6);

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

            Thomas.Draw.spriteBatch.Begin();
            Thomas.Draw.spriteBatch.Draw(texture, position, new Rectangle(0, 0, texture.Width / 3, texture.Height), Color.White);

            if (entities != null)
            {
                foreach (var e in entities)
                {
                    e.Draw(Thomas.Draw.spriteBatch);
                }
            }

            Thomas.Draw.spriteBatch.End();
        }

        public void AddEntity(Entity entity) 
        {
            if (!entities.Contains(entity))
            {
                entities.Add(entity);
                Debug.WriteLine("Entity has been added");
            }
        }

        public void RemoveEntity(Entity entity)
        {
            if (entities.Contains(entity))
            {
                entities.Remove(entity);
                Debug.WriteLine("Entity has been removed");
            }
        }
    }
}
