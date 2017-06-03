using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(Rigidbody2D)]
public class PlayerController : MonoBehaviour {

    public int playerIndex = 1;
    public float maxSpeed = 2f;
    public float jumpForce = 1000f;
    public float groundCheckRadius = 0.1f;

    Rigidbody2D playerRigidbody;
    // Use this for initialization
    void Start () {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
	}
    bool jump;
        
        // Update is called once per frame
    void Update () {
        float move = Input.GetAxis("AxeX" + playerIndex.ToString());
        playerRigidbody.velocity = new Vector2(move * maxSpeed, playerRigidbody.velocity.y);
        bool lastJump = jump;
        jump = Input.GetButton("Jump" + playerIndex.ToString());

        bool grounded = Physics2D.OverlapCircleAll(transform.position, groundCheckRadius).Length > 1;

        if (lastJump != jump && jump && grounded)
        {
            playerRigidbody.AddForce(new Vector2(move * maxSpeed, jumpForce));
        }
	}
}
