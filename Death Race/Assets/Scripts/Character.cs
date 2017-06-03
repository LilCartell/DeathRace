using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

[RequireComponent(typeof(AudioSource))]
public class Character : MonoBehaviour {

	public Player controller;
    public AudioClip[] deathScreams;

	private Animator _animator;
	private Trap _killedBy;
    private AudioSource _audioSource;

	private void Awake(){
		_animator = GetComponent<Animator> ();
        _audioSource = GetComponent<AudioSource>();
	}

	public void Die(Trap trap)
	{
		_killedBy = trap;
		_animator.SetTrigger ("DEATH_" + trap.causeOfDeath.ToString ());
        _audioSource.clip = deathScreams[Random.Range(0, deathScreams.Length)];
        _audioSource.Play();
	}

	private void EndDeath()
	{
		controller.OnCharacterIsDead (_killedBy);
	}
}
