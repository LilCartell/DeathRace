using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Character : MonoBehaviour {

	public Player controller;
	// Use this for initialization
	private void Start () 
	{
		
	}
	
	// Update is called once per frame
	private void Update () 
	{
		
	}

	public void Die() //TODO Param enum cause of death ?
	{
		//Trigger death animation
	}

	private void EndDeath()
	{
		controller.OnCharacterIsDead ();
	}
}
