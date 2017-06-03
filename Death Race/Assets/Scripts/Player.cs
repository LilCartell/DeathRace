﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Player : MonoBehaviour {

	public int StartingScore;

	private int score;
	public GameObject characterPrefab;

	private Character _currentCharacter;

	public void Awake(){
		score = StartingScore;
	}

	private void AddPoints(int points)
	{
		score += points;
	}

	private void RemovePoints(int points)
	{
		score -= points;
		if (score <= 0) 
		{
			GameManager.Instance.MakePlayerWin (this);
		}
	}

	public void ApplyScoreModifier(int points){
		if (points > 0) 
		{
			AddPoints (points);
		} 
		else 
		{
			RemovePoints (-points);
		}
	}

	public void OnCharacterIsDead(Trap trap) //MAYBE TAKE CAUSE OF DEATH ?
	{
		//Remove points according to cause of death ?
		RemovePoints(trap.ScoreModifier);
		Destroy(_currentCharacter);
		SpawnNewCharacter ();
	}

	private void SpawnNewCharacter()
	{
		var newCharacter = Instantiate<GameObject> (characterPrefab);
		_currentCharacter = newCharacter.GetComponent<Character> ();
		//SET CURRENT CHARACTER TRANSFORM ON SPAWN
	}
}
