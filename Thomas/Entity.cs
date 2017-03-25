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
		private bool drawable;

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
				if (component.ID == "DrawableComponent") drawable = true;
				Debug.WriteLine(component.ID + " has been added");
            }
        }

        public void RemoveComponent(Component component)
        {
            if (components.Contains(component))
            {
                components.Remove(component);
                Debug.WriteLine("Component has been removed");
            }
        }

		public Component GetComponent(string id)
		{
			if (components != null)
			{
				foreach (var c in components)
				{
					if (c.ID.Equals(id)) return c;
				}
			}

			return null;
		}

		public int GetWidth()
		{
			if (drawable)
			{
				return ((DrawComponent)GetComponent("DrawComponent")).GetTextureWidth();
			}

			return 0;
		}

		public int GetHeight()
		{
			if (drawable)
			{
				return ((DrawComponent)GetComponent("DrawComponent")).GetTextureHeight();
			}

			return 0;
		}
    }
}
