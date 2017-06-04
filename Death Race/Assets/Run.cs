using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour {

    Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame

    void Update () {
        transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        if (transform.position.x > 28)
            transform.position = pos;
	}
}
