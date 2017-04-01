using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
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
		Entity ball;

		float MAX_BOUNCE_ANGLE;
		readonly float TIME_INTERVAL = 100f;
		float timer;
		bool collisionLocked;

		float ballSpeed;
		float ballVX;
		float ballVY;

		public Pong() : base(Strings.Title, 640, 360, false, false)
		{
			engine = this;
			MAX_BOUNCE_ANGLE = (float)(60 * (Math.PI / 180));
		}

		protected override void Initialize()
		{
			base.Initialize();

			player1 = new Entity("Player1");
			DrawComponent player1DC = new DrawComponent(player1, "Sprites/paddle", Color.White, 0.0f, null, DrawLayer.Player());
			PositionComponent player1PC = new PositionComponent(player1);
			player1PC.position.X = player1PC.origin.X = engine.Width - (player1DC.GetTextureWidth() + 20f);
			player1PC.position.Y = player1PC.origin.Y = (engine.Height / 2f) - (player1DC.GetTextureHeight() / 2f);
			player1.AddComponent(player1DC);
			player1.AddComponent(player1PC);
			player1.AddCollider(player1PC.origin.X, player1PC.origin.Y, player1DC.GetTextureWidth(), player1DC.GetTextureHeight());
			engine.AddEntity(player1);
			
			Debug.WriteLine(player1.Get<DrawComponent>().GetTextureHeight());
			Debug.WriteLine(player1.collider.Height());

			player2 = new Entity("Player2");
			DrawComponent player2DC = new DrawComponent(player2, "Sprites/paddle", Color.White, 0.0f, null, DrawLayer.Player());
			PositionComponent player2PC = new PositionComponent(player2);
			player2PC.position.X = player2PC.origin.X = 20f;
			player2PC.position.Y = player2PC.origin.Y = (engine.Height / 2f) - (player2DC.GetTextureHeight() / 2f);
			player2.AddComponent(player2DC);
			player2.AddComponent(player2PC);
			player2.AddCollider(player2PC.origin.X, player2PC.origin.Y, player2DC.GetTextureWidth(), player2DC.GetTextureHeight());
			engine.AddEntity(player2);

			ball = new Entity("Ball");
			DrawComponent ballDC = new DrawComponent(ball, "Sprites/ball", Color.White, 0.0f, null, DrawLayer.Front());
			PositionComponent ballPC = new PositionComponent(ball);
			ballPC.position.X = ballPC.origin.X = (engine.Width / 2f) - (ballDC.GetTextureWidth() / 2f);
			ballPC.position.Y = ballPC.origin.Y = (engine.Height / 2f) - (ballDC.GetTextureHeight() / 2f);
			ball.AddComponent(ballPC);
			ball.AddComponent(ballDC);
			ball.AddCollider(ballPC.origin.X, ballPC.origin.Y, ballDC.GetTextureWidth(), ballDC.GetTextureHeight());
			engine.AddEntity(ball);

			Entity centerLine = new Entity("centerLine");
			DrawComponent centerLineDC = new DrawComponent(centerLine, "Sprites/center", Color.White, 0.0f, null, DrawLayer.Background());
			PositionComponent centerLinePC = new PositionComponent(centerLine);
			centerLinePC.position.X = (engine.Width / 2f) - (centerLineDC.GetTextureWidth() / 2f);
			centerLinePC.position.Y = 7f;
			centerLine.AddComponent(centerLineDC);
			centerLine.AddComponent(centerLinePC);
			engine.AddEntity(centerLine);

			Reset();
		}

		protected override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			
			//
			// REFERENCE:
			// http://gamedev.stackexchange.com/questions/4253/in-pong-how-do-you-calculate-the-balls-direction-when-it-bounces-off-the-paddl
			//
	
			float deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

			if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
			if (Keyboard.GetState().IsKeyDown(Keys.R)) Reset();
			
			// PLAYER1 CONTROL
			if (Keyboard.GetState().IsKeyDown(Keys.Up)) player1.Get<PositionComponent>().position.Y -= (deltaTime * 0.2f);
			if (Keyboard.GetState().IsKeyDown(Keys.Down)) player1.Get<PositionComponent>().position.Y += (deltaTime * 0.2f);
			
			// PLAYER2 CONTROL
			if (Keyboard.GetState().IsKeyDown(Keys.W)) player2.Get<PositionComponent>().position.Y -= (deltaTime * 0.2f);
			if (Keyboard.GetState().IsKeyDown(Keys.S)) player2.Get<PositionComponent>().position.Y += (deltaTime * 0.2f);

			// BALL CONTROL
			if (!collisionLocked) //Do not check collisions if temporarily locked to avoid multiple triggers
			{
				// Check paddle, top, bottom collision
				if (player1.collider.Collide(ball.collider))
				{
					float intensity = (player1.collider.Center().Y - ball.collider.Center().Y) / (player1.collider.Height() / 2f);
					ballVX = (float)-Math.Cos(intensity * MAX_BOUNCE_ANGLE);
					ballVY = (float)-Math.Sin(intensity * MAX_BOUNCE_ANGLE);
					collisionLocked = true;
				}
				if (player2.collider.Collide(ball.collider))
				{
					float intensity = (player2.collider.Center().Y - ball.collider.Center().Y) / (player2.collider.Height() / 2f);	
					ballVX = (float)Math.Cos(intensity * MAX_BOUNCE_ANGLE);
					ballVY = (float)-Math.Sin(intensity * MAX_BOUNCE_ANGLE);
					collisionLocked = true;
				}
				if (ball.collider.Top() >= engine.Height)
				{
					ballVY *= -1;
					collisionLocked = true;
				}
				if (ball.collider.Bottom() <= 0f)
				{
					ballVY *= -1;
					collisionLocked = true;
				}
				
				// Ball leaves screen
				if (ball.collider.Right() >= engine.Width)
				{
					Reset();
					collisionLocked = true;
				}
				if (ball.collider.Left() <= 0f)
				{
					Reset();
					collisionLocked = true;
				}
			}
			else //Unlock collisionLocked after TIME_INTERVAL Passes
			{
				timer += deltaTime;
				if (timer >= TIME_INTERVAL)
				{
					timer -= TIME_INTERVAL;
					collisionLocked = false;
				}
			}

			ball.Get<PositionComponent>().position.X += (ballVX * (deltaTime * ballSpeed));
			ball.Get<PositionComponent>().position.Y += (ballVY * (deltaTime * ballSpeed));	
		}

		public void Reset()
		{
			timer = 0;
		
			player1.Get<PositionComponent>().position.Y = player1.Get<PositionComponent>().origin.Y;
			player2.Get<PositionComponent>().position.Y = player2.Get<PositionComponent>().origin.Y;
			ball.Get<PositionComponent>().position.X = ball.Get<PositionComponent>().origin.X;
			ball.Get<PositionComponent>().position.Y = ball.Get<PositionComponent>().origin.Y;
			
			ballSpeed = 0.25f;
			ballVX = new Random().Next(0, 2);
			if ((int)ballVX == 0) ballVX = -1;
			else ballVX = 1;
			ballVY = 0;
			
			collisionLocked = false;
		}

	}
}
