using System;
using UnityEngine;
using UnityEngine.UI;

namespace AssemblyCSharp
{
	public class WinnerIcon : MonoBehaviour
	{

		public void Awake()
		{
			GetComponent<Image> ().sprite = GameManager.Instance.winner.winSprite;
		}
	}
}

