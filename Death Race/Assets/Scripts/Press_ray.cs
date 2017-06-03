using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press_ray : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !transform.parent.gameObject.GetComponent<Rigidbody2D>())
        {
            transform.parent.gameObject.AddComponent<Rigidbody2D>();
        }
    }
}
