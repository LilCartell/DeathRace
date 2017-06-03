using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(Rigidbody2D)]
public class PlayerController : MonoBehaviour {

    public int playerIndex = 1;
    public float maxSpeed = 2f;
    public float inAirSpeed = 0.5f;
    public float jumpForce = 1000f;
    public float groundCheckRadius = 0.1f;
    public float groundCheckPositionOffset = -0.5f;

    private Animator _animator;
    private bool jump;
    private bool _walk;

    Rigidbody2D playerRigidbody;
    // Use this for initialization
    void Start () {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
	}
        
        // Update is called once per frame
    void Update () {
        float move = Input.GetAxis("AxeX" + playerIndex.ToString());
        Vector3 pos = transform.position;
        pos.y += groundCheckPositionOffset;
        bool grounded = Physics2D.OverlapCircleAll(pos, groundCheckRadius).Length > 1;
        bool lastJump = jump;
        bool lastWalk = _walk;

        if (grounded)
            playerRigidbody.velocity = new Vector2(move * maxSpeed, playerRigidbody.velocity.y);
        else if (!grounded && (move >= 0.5f || move <= -0.5f))
            playerRigidbody.velocity = new Vector2(move * Mathf.Min(Mathf.Abs(playerRigidbody.velocity.x + (move * inAirSpeed)), maxSpeed), playerRigidbody.velocity.y);
        jump = Input.GetButton("Jump" + playerIndex.ToString());
        _walk = grounded && (move >= 0.1f || move <= -0.1f);
        if (_walk != lastWalk)
        {
            if (_walk)
                print("Start walking");
            else
                print("Stop walking");

            if (_walk)
                _animator.SetTrigger("StartWalk");
            else
                _animator.SetTrigger("StopWalk");
        }

        if (lastJump != jump && jump && grounded)
        {
            playerRigidbody.AddForce(new Vector2(move * maxSpeed, jumpForce));
            //playerRigidbody.inertia = playerRigidbody.velocity;
        }
	}
}
