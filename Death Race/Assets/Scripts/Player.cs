using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using System;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public int StartingScore;
	public float TimeBetweenPowerUps = 20f;

	private int score;
	public GameObject characterPrefab;
    public int playerID;

	private PowerUp _currentPowerUp;
	private float _timeSinceLastPowerUp;

	private Character _currentCharacter;

	public Image powerUpImage;
	public Text scoreText;

	public void Awake()
	{
		score = StartingScore;

		SpawnNewCharacter();
		_timeSinceLastPowerUp = 0;
		scoreText.text = score.ToString ();
	}

	public void Update()
	{
		_timeSinceLastPowerUp += Time.deltaTime;
		if (_timeSinceLastPowerUp >= TimeBetweenPowerUps && _currentPowerUp == null) 
		{
			PickRandomPowerUp ();
		}
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
		scoreText.text = score.ToString ();
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
		_currentCharacter.controller = this;
        _currentCharacter.GetComponent<PlayerController>().playerIndex = playerID;
    }

	public void TryUsePowerUp()
	{
		if (_currentPowerUp != null) 
		{
			_currentPowerUp.Activate (_currentCharacter);
			_currentPowerUp = null;
			_timeSinceLastPowerUp = 0;
			powerUpImage.gameObject.SetActive(false);
		}
	}

	private void PickRandomPowerUp()
	{
		var powerUpList = Enum.GetValues (typeof(PowerUps));
		var random = (PowerUps) powerUpList.GetValue(UnityEngine.Random.Range(0, powerUpList.Length));
		switch (random) 
		{
			case PowerUps.SWAP:
				_currentPowerUp = new SwapPowerUp ();
				break;
		}
		powerUpImage.gameObject.SetActive (true);
		powerUpImage.sprite = _currentPowerUp.GetSprite ();
		_timeSinceLastPowerUp = 0;
	}

    public void DebugDie()
    {
        _currentCharacter.Die(null);
		Destroy(_currentCharacter.gameObject);
		SpawnNewCharacter();
    }
}
