﻿using System.Collections;
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
    bool _dead = false;

    public Sprite[] corpseSprites;

	private void Awake(){
		_animator = GetComponent<Animator> ();
	}

    public void Start()
    {
        _audioSource = controller.GetComponent<AudioSource>();
    }

    public void Die(Trap trap)
	{
        if (_dead)
            return;
        _dead = true;
        if (trap)
        {
            print("Killed by : " + trap. name + " for " + trap.ScoreModifier + " points !");
    		_killedBy = trap;
	    	_animator.SetTrigger ("DEATH_" + trap.causeOfDeath.ToString ());
        }
        _audioSource.clip = deathScreams[Random.Range(0, deathScreams.Length)];
        _audioSource.Play();
        GetComponent<PlayerController>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
    }

    private void EndDeath()
	{
		controller.OnCharacterIsDead (_killedBy);
	}

    public Sprite deathSprite(CauseOfDeath death)
    {
        return (corpseSprites[(int)death]);
    }
}
