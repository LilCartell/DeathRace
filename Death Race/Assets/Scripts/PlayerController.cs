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
    private SpriteRenderer _renderer;
	private Character _character;

    Rigidbody2D playerRigidbody;
    // Use this for initialization
    void Start () {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
        _renderer = gameObject.GetComponent<SpriteRenderer>();
		_character = gameObject.GetComponent<Character> ();
	}
        
        // Update is called once per frame
    void Update () {
        float move = Input.GetAxis("AxeX" + playerIndex.ToString());
        Vector3 pos = transform.position;
        pos.y += groundCheckPositionOffset;
        bool grounded = false;
        var temp = Physics2D.OverlapCircleAll(pos, groundCheckRadius);
        foreach(var item in temp)
        {
            if (item.gameObject != gameObject)
                grounded |= !item.isTrigger;
        }
        bool lastJump = jump;
        bool lastWalk = _walk;

		var usePowerUp = Input.GetButton ("PowerUp" + playerIndex.ToString ());
		if (usePowerUp) 
		{
			_character.controller.TryUsePowerUp ();
		}

        _renderer.flipX = move < 0;
        if (grounded)
            playerRigidbody.velocity = new Vector2(move * maxSpeed, playerRigidbody.velocity.y);
        else if (!grounded && (move >= 0.5f || move <= -0.5f))
            playerRigidbody.velocity = new Vector2(move * Mathf.Min(Mathf.Abs(playerRigidbody.velocity.x + (move * inAirSpeed)), maxSpeed), playerRigidbody.velocity.y);
        jump = Input.GetButton("Jump" + playerIndex.ToString());
        _walk = grounded && (move >= 0.1f || move <= -0.1f);
        if (_walk != lastWalk)
        {
            if (_walk)
                _animator.SetTrigger("StartWalk");
            else
                _animator.SetTrigger("StopWalk");
        }

        if (lastJump != jump && jump && grounded)
        {
            playerRigidbody.AddForce(new Vector2(move * maxSpeed, jumpForce));
            _animator.SetTrigger("Jump");
        }
        else if (grounded && grounded != lastJump)
            _animator.SetTrigger("StopJump");
	}
}
