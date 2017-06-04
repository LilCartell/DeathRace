using System;
using UnityEngine.SceneManagement;

namespace AssemblyCSharp
{
	public class GameManager
	{
		private static GameManager instance = null;
		public Player winner;

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
			winner = player;
			SceneManager.LoadScene (2);
		}
	}
}

