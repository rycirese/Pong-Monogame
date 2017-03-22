using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Diagnostics;
using System.Collections.Generic;

namespace Thomas
{
    public class Entity
    {
        private List<Component> components;

        public Entity()
        {
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
                Debug.WriteLine("Component has been added");
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
    }
}
