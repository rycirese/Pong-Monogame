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

		public Entity(string ID)
        {
			this.ID = ID;
            components = new List<Component>();
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
    }
}
