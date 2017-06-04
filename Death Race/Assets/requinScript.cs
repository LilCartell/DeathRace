using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class requinScript : MonoBehaviour {
    Rigidbody2D _rigidbody;
    bool _activated = false;
    Vector3 _startinPoint;
	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.simulated = _activated;
        _startinPoint = transform.position;
        Invoke("Activate", 2f);
	}
	
    void Activate()
    {
        _activated = true;
        _rigidbody.simulated = _activated;
    }

    void DeActivate()
    {
        _activated = false;
        _rigidbody.simulated = _activated;
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
            Invoke("Activate", 2f);
            transform.position = _startinPoint;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("Lama");
            Character c = collision.gameObject.GetComponent<Character>();
            if (c)
                c.Die(GetComponent<Trap>());
        }
    }
}
