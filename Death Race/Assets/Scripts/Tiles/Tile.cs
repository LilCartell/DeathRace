﻿using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public abstract class Tile : MonoBehaviour
	{
		protected virtual void Awake()
		{
		}

		private void Update()
		{
			if (false) //TODO replace by collision with character
			{
			}
		}

		public abstract void OnEntryFrom(Character character);
	}
}

