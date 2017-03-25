using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Diagnostics;

using Thomas;

namespace Pong
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Pong : Engine
	{
		Engine engine;
		Entity player1;
		Entity player2;

		public Pong() : base(Strings.Title, 640, 360, false, false)
		{
			engine = this;
		}

		protected override void Initialize()
		{
			base.Initialize();

			player1 = new Entity("Player1");
			DrawComponent player1DC = new DrawComponent(player1, "Sprites/paddle", Color.White, 0.0f, null, DrawLayer.Player());
			PositionComponent player1PC = new PositionComponent(player1);
			player1PC.position.X = engine.Width - (player1DC.GetTextureWidth() + 20f);
			player1PC.position.Y = (engine.Height / 2f) - (player1DC.GetTextureHeight() / 2f);
			player1.AddComponent(player1DC);
			player1.AddComponent(player1PC);
			engine.AddEntity(player1);

			player2 = new Entity("Player2");
			DrawComponent player2DC = new DrawComponent(player2, "Sprites/paddle", Color.White, 0.0f, null, DrawLayer.Player());
			PositionComponent player2PC = new PositionComponent(player2);
			player2PC.position.X = 20f;
			player2PC.position.Y = (engine.Height / 2f) - (player2DC.GetTextureHeight() / 2f);
			player2.AddComponent(player2DC);
			player2.AddComponent(player2PC);
			engine.AddEntity(player2);

			Entity centerLine = new Entity("centerLine");
			DrawComponent centerLineDC = new DrawComponent(centerLine, "Sprites/center", Color.White, 0.0f, null, DrawLayer.Background());
			PositionComponent centerLinePC = new PositionComponent(centerLine);
			centerLinePC.position.X = (Width / 2) - (centerLineDC.GetTextureWidth() / 2);
			centerLinePC.position.Y = 7f;
			centerLine.AddComponent(centerLineDC);
			centerLine.AddComponent(centerLinePC);
			engine.AddEntity(centerLine);
		}

		protected override void LoadContent()
		{
			
		}

		protected override void Update(GameTime gameTime)
		{

			float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

			if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

			// PLAYER1 CONTROL
			if (Keyboard.GetState().IsKeyDown(Keys.Up))
			{
				((PositionComponent)player1.GetComponent("PositionComponent")).position.Y -= (delta * 200f);
			}
			if (Keyboard.GetState().IsKeyDown(Keys.Down))
			{
				((PositionComponent)player1.GetComponent("PositionComponent")).position.Y += (delta * 200f);
			}

			// PLAYER2 CONTROL
			if (Keyboard.GetState().IsKeyDown(Keys.W))
			{
				((PositionComponent)player2.GetComponent("PositionComponent")).position.Y -= (delta * 200f);
			}
			if (Keyboard.GetState().IsKeyDown(Keys.S))
			{
				((PositionComponent)player2.GetComponent("PositionComponent")).position.Y += (delta * 200f);
			}
		}

	}
}
