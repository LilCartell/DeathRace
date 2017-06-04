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

    public Sprite[] spr;

	private void Awake(){
		_animator = GetComponent<Animator> ();
	}

    public void Start()
    {
        _audioSource = controller.GetComponent<AudioSource>();
    }

    public void Die(Trap trap)
	{
        if (trap)
        {
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
        return (spr[(int)death]);
    }
}
