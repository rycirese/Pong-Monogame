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

		public Pong() : base(Strings.Title, 640, 360, false, false)
		{
			engine = this;
		}

		protected override void LoadContent()
		{
			Entity centerLine = new Entity("centerLine");

			centerLine.AddComponent(new DrawComponent(centerLine, "Sprites/center", 0.0f, null, 0.0f));

			PositionComponent positionComponent = new PositionComponent(centerLine);
			positionComponent.position.X = ((Width -  ((DrawComponent)centerLine.GetComponent("DrawComponent")).getTextureWidth()) / 2);
			positionComponent.position.Y = 7f;
			centerLine.AddComponent(positionComponent);
            
			engine.AddEntity(centerLine);
		}

		protected override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
		}
	}
}
