using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Character : MonoBehaviour {

	public Player controller;

	private Animator _animator;
	private Trap _killedBy;

	private void Awake(){
		_animator = GetComponent<Animator> ();
	}

	public void Die(Trap trap)
	{
		_killedBy = trap;
		_animator.SetTrigger ("DEATH_" + trap.causeOfDeath.ToString ());
	}

	private void EndDeath()
	{
		controller.OnCharacterIsDead (_killedBy);
	}
}
