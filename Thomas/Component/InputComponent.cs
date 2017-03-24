using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Thomas
{
    class InputComponent : Component
    {
		public InputComponent(Entity entity) : base("InputComponent")
        {
			this.entity = entity;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);


        }

    }
}
