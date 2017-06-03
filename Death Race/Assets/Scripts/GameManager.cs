using System;

namespace AssemblyCSharp
{
	public class GameManager
	{
		private static GameManager instance = null;

		public static GameManager Instance 
		{ 
			get 
			{
				if (instance == null)
					instance = new GameManager ();
				return instance;
			}
		}

		public void MakePlayerWin(Player player)
		{
			//TODO What happens when you win ?
		}
	}
}

