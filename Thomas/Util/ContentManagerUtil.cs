using Microsoft.Xna.Framework.Content;

namespace Thomas
{
	public static class ContentManagerUtil
	{
		/// <summary>
		/// All content loading is done through this ContentManger instance
		/// </summary>
		static public ContentManager Content { get; private set; }

		static internal void Initialize(ContentManager content)
		{
			Content = content;
		}
	}
}
