using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public abstract class PowerUp
	{
		public abstract Sprite GetSprite();
		public abstract void Activate (Character character);
	}
}

