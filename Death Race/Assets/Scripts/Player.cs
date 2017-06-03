using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Player : MonoBehaviour {

	public int Score;
	public GameObject characterPrefab;

	private Character _currentCharacter;

	public void AddPoints(int points)
	{
		Score += points;
	}

	public void RemovePoints(int points)
	{
		Score -= points;
		if (Score <= 0) 
		{
			GameManager.Instance.MakePlayerWin (this);
		}
	}

	public void OnCharacterIsDead() //MAYBE TAKE CAUSE OF DEATH ?
	{
		//Remove points according to cause of death ?
		Destroy(_currentCharacter);
	}

	private void SpawnNewCharacter()
	{
		_currentCharacter = Instantiate<GameObject> (characterPrefab);
		//SET CURRENT CHARACTER TRANSFORM ON SPAWN
	}
}
