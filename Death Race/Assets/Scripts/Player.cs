using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Player : MonoBehaviour {

	public int StartingScore;

	private int score;
	public GameObject characterPrefab;
    public Transform spawnPoint;
    public int playerID;

	private Character _currentCharacter;

	public void Awake(){
		score = StartingScore;

		SpawnNewCharacter();
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

	public void OnCharacterIsDead(Trap trap)
	{
        //Remove points according to cause of death ?
        ApplyScoreModifier(trap.ScoreModifier);
		Destroy(_currentCharacter.gameObject);
		SpawnNewCharacter();
	}

	private void SpawnNewCharacter()
	{
		var newCharacter = Instantiate<GameObject> (characterPrefab);
		newCharacter.transform.localScale = this.transform.localScale;
		newCharacter.transform.localPosition = this.transform.localPosition;
		newCharacter.transform.localRotation = this.transform.localRotation;
		_currentCharacter = newCharacter.GetComponent<Character> ();
        _currentCharacter.transform.position = spawnPoint.position;
		_currentCharacter.controller = this;
        _currentCharacter.GetComponent<PlayerController>().playerIndex = playerID;
    }

    public void DebugDie()
    {
        _currentCharacter.Die(null);
		Destroy(_currentCharacter.gameObject);
		SpawnNewCharacter();
    }
}
