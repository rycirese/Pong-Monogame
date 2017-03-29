using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Diagnostics;
using System.Collections.Generic;

namespace Thomas
{
    public class Entity
    {
		public string ID;
        List<Component> components;

		public bool drawable;

		public Entity(string ID)
        {
			this.ID = ID;
            components = new List<Component>();
			drawable = false;
        }


        public void Update(GameTime gameTime)
        {
            if (components != null)
            {
                foreach (var c in components)
                {
                    c.Update(gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (components != null)
            {
                foreach (var c in components)
                {
                    c.Draw(spriteBatch);
                }
            }
        }

        public void AddComponent(Component component)
        {
            if (!components.Contains(component))
            {
                components.Add(component);
				if (component.GetType() == typeof(DrawComponent)) drawable = true;
            }
        }

        public void RemoveComponent(Component component)
        {
            if (components.Contains(component))
            {
                components.Remove(component);
            }
        }

        public T Get<T>() where T : Component
        {
            foreach (var c in components)
                if (c is T)
                    return c as T;
            return null;
        }

		public int GetWidth()
		{
			if (drawable)
			{
				return Get<DrawComponent>().GetTextureWidth();
			}

			return 0;
		}

		public int GetHeight()
		{
			if (drawable)
			{
				return Get<DrawComponent>().GetTextureHeight();
			}

			return 0;
		}
    }
}
