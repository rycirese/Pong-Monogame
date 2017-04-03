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
        public Collider collider;

		public bool drawable;

		public Entity(string ID)
        {
			this.ID = ID;
            components = new List<Component>();
			collider = null;
            
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

			if (collider != null)
			{
				collider.Update();
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

        /// <summary>
        /// Add a component to 'components'
        /// </summary>
        /// <param name="component"></param>
        public void AddComponent(Component component)
        {
            if (!components.Contains(component))
            {
                components.Add(component);
				if (component.GetType() == typeof(DrawComponent)) drawable = true;
            }
        }

        /// <summary>
        /// Remove component from 'components'
        /// </summary>
        /// <param name="component"></param>
        public void RemoveComponent(Component component)
        {
            if (components.Contains(component))
            {
                components.Remove(component);
            }
        }

        /// <summary>
        /// Return Component of type T from 'components'
        /// or null if it doesn't exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>() where T : Component
        {
            foreach (var c in components)
                if (c is T)
                    return c as T;
            return null;
        }

        /// <summary>
        /// Creates a Collider and attaches it
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
		public void AddCollider(float x, float y, float width, float height)
		{
			collider = new Collider(this, (int)x, (int)y, (int)width, (int)height);
		}

        /// <summary>
        /// Returns width value of texture
        /// </summary>
        /// <returns></returns>
		public int GetWidth()
		{
			if (drawable)
			{
				return Get<DrawComponent>().GetTextureWidth();
			}

			return 0;
		}

        /// <summary>
        /// Returns height valvue of texture
        /// </summary>
        /// <returns></returns>
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
