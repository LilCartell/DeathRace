using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class requinScript : MonoBehaviour {
    Rigidbody2D _rigidbody;
    bool _activated = false;
    Vector3 _startinPoint;
    public float timeBeforeActivation;
    public int spawnRangeY;

    AudioSource _audioSource;

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (_rigidbody)
            _rigidbody.simulated = _activated;
        _startinPoint = transform.position;
        _audioSource = GetComponent<AudioSource>();
        GetComponent<SpriteRenderer>().enabled = false;
        Invoke("Activate", timeBeforeActivation);
	}
	
    void Activate()
    {
        _activated = true;
        _rigidbody.simulated = _activated;
        transform.position = new Vector3(_startinPoint.x, _startinPoint.y + Random.Range(spawnRangeY * - 1, spawnRangeY) * 2, _startinPoint.z);
        GetComponent<SpriteRenderer>().enabled = true;
    }

    void DeActivate()
    {
        _activated = false;
        _rigidbody.simulated = _activated;
        GetComponent<SpriteRenderer>().enabled = false;
    }


    // Update is called once per frame
    void Update () {
        if (_activated)
            _rigidbody.velocity = new Vector3(-5, _rigidbody.velocity.y, 0);
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            DeActivate();
            Invoke("Activate", timeBeforeActivation);
            transform.position = _startinPoint;
        }
        else if (collision.gameObject.tag == "Water")
        {
            GetComponent<Animator>().SetTrigger("Jump");
            _rigidbody.simulated = false;
        }
    }

    public void OnEndAnimation()
    {
        DeActivate();
        Invoke("Activate", timeBeforeActivation);
        transform.position = _startinPoint;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Character c = collision.gameObject.GetComponent<Character>();
            if (c)
                c.Die(GetComponent<Trap>());
            _audioSource.Play();
        }
    }
}
