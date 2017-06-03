using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using System.Linq;

public class RandomTrapManager : MonoBehaviour 
{
	public float TimeBetweenTraps = 10f;
	public List<GameObject> trapPrefabs;

	private float timeSinceLastTrap;

	private List<RandomDeathTile> _randomDeathTiles;

	void Awake()
	{
		timeSinceLastTrap = 0f;
	}

	void Start()
	{
		_randomDeathTiles = new List<RandomDeathTile> (FindObjectsOfType<RandomDeathTile> ());
	}

	// Update is called once per frame
	void Update () 
	{
		timeSinceLastTrap += Time.deltaTime;
		if (timeSinceLastTrap >= TimeBetweenTraps && _randomDeathTiles.Count > 0) 
		{
			var deactivatedRandomDeathTiles = _randomDeathTiles.Where(tile => tile.Activated).ToList();
			var chosenTile = deactivatedRandomDeathTiles [Random.Range (0, deactivatedRandomDeathTiles.Count)];
			chosenTile.SpawnNewTrap (trapPrefabs [Random.Range (0, trapPrefabs.Count)]);
			timeSinceLastTrap = 0;
		}
	}
}
