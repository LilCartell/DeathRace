using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class SwapPowerUp : PowerUp
	{

		public override Sprite GetSprite ()
		{
			return Resources.Load<Sprite> ("Swap");
		}

		public override void Activate(Character character)
		{
			var characters = GameObject.FindObjectsOfType<Character> ();
			var closestDistance = float.MaxValue;
			Character closestCharacter = null;
			foreach(var sceneCharacter in characters)
			{
				if (sceneCharacter != character) 
				{
					var currentDistance = Vector3.Distance (character.transform.position, sceneCharacter.transform.position);
					if (currentDistance < closestDistance) 
					{
						closestDistance = currentDistance;
						closestCharacter = sceneCharacter;
					}
				}
			}

			var position = closestCharacter.transform.position;
			closestCharacter.transform.position = character.transform.position;
			character.transform.position = position;
		}
	}
}

