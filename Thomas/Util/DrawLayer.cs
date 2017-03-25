using System;
using System.Collections.Generic;
using System.Text;

namespace Thomas
{
	public enum layers
	{
		Front, //front-layer
		Player,
		Particles,
		Background, //back-layer
		MAX_LAYER   //Do not use this as a layer
	}

	public static class DrawLayer
	{
		public static float Front()
		{
			return (float)layers.Front / (float)layers.MAX_LAYER;
		}

		public static float Player()
		{
			return (float)layers.Player / (float)layers.MAX_LAYER;
		}

		public static float Particles()
		{
			return (float)layers.Particles / (float)layers.MAX_LAYER;
		}

		public static float Background()
		{
			return (float)layers.Background / (float)layers.MAX_LAYER;
		}
	}
}
