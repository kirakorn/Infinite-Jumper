using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;
	public Transform wallCheck;


	private bool grounded = false;
	private bool onWall = false;
	private Animator anim;
	private Rigidbody2D rb2d;
	private bool jumpedOffWall;


	// Use this for initialization
	void Awake () 
	{
		//anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Start () 
	{
		GameManager.instance.player = this.gameObject;
	}

	// Update is called once per frame
	void Update () 
	{
		
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		onWall = Physics2D.Linecast(transform.position, wallCheck.position, 1 << LayerMask.NameToLayer("Wall"));

		if (Input.GetButtonDown("Jump") && grounded || Input.GetButtonDown("Jump") && onWall)
		{
			jump = true;
		}
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");

		//anim.SetFloat("Speed", Mathf.Abs(h));

		if (h * rb2d.velocity.x < maxSpeed )
			rb2d.AddForce(Vector2.right * h * moveForce);

		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
			rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

		if (h > 0 && !facingRight)
			Flip ();
		else if (h < 0 && facingRight)
			Flip ();

		if (jump)
		{
			//anim.SetTrigger("Jump");
			if (onWall) {
				rb2d.AddForce (Vector2.right * -h * (jumpForce * 2.5f));
				rb2d.AddForce (Vector2.up * jumpForce);
			}
			if (!onWall) {
				rb2d.AddForce (new Vector2 (0f, jumpForce));
			}
			jump = false;
		}
	}


	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
