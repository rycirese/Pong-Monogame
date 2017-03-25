using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using System;

using Thomas;

namespace Pong
{
	public class PlayerPaddle
	{
		Engine engine = Engine.instance;

		public PlayerPaddle()
		{
			Entity playerPaddle = new Entity("PlayerPaddle");
			DrawComponent dc = new DrawComponent(playerPaddle, "Sprites/paddle", Color.White, 0.0f, null, DrawLayer.Player());
			PositionComponent pc = new PositionComponent(playerPaddle);

			pc.position.X = engine.Width - (dc.GetTextureWidth() + 10f);
			pc.position.Y = (engine.Height / 2f) - (dc.GetTextureHeight() / 2f);

			playerPaddle.AddComponent(dc);
			playerPaddle.AddComponent(pc);
			engine.AddEntity(playerPaddle);
		}

		public void Update()
		{
			
		}
	}
}
