using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChildLaugh : MonoBehaviour {

    public AudioClip[] _clipToPlay;

    private float _TimeBetweenActivations = 5f;
    private float _timeSinceDeactivation = 0;

    private bool activated;
    public bool Activated { get { return activated; } }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!activated)
        {
            _timeSinceDeactivation += Time.deltaTime;
            if (_timeSinceDeactivation >= _TimeBetweenActivations)
            {
                Activate();
            }
        }
    }

    public virtual void Activate()
    {
        //print("Activate");
        if (_clipToPlay != null)
        {
            AudioSource src = GetComponent<AudioSource>();
            if (src)
            {
                print("length: " + _clipToPlay.Length);
                src.clip = _clipToPlay[Random.Range(0, _clipToPlay.Length)];
                src.Play();
                _TimeBetweenActivations = Random.Range(3f, 7f);
                Deactivate();
            }
        }
    }

    public virtual void Deactivate()
    {
        activated = false;
        _timeSinceDeactivation = 0f;
    }
}
