using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour {


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Character c = other.gameObject.GetComponent<Character>();
            if (c)
            {
                c.controller.DebugDie();
            }
        }
    }
}
