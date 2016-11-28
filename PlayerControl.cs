using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public int speed;
	public int jumpSpeed;
	public int gravity;

	public Transform grounder;
	public float radius;
	public LayerMask ground;
	public bool isGrounded = false;

	private Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate (){
		isGrounded = Physics2D.OverlapCircle (grounder.position, radius, ground);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 moveDirection = new Vector2 (Input.GetAxisRaw("Horizontal") * 4, rb2D.velocity.y); //5 is for the speed
		rb2D.velocity = moveDirection;

		if (Input.GetAxisRaw("Horizontal") == 1){						//Moves Right
			transform.localScale = new Vector3(1, 1, 1);
		} else if (Input.GetAxisRaw("Horizontal") == -1){				//Moves Left
			transform.localScale = new Vector3(-1, 1, 1);
		}

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded==true){				//For Jumping
			rb2D.AddForce (new Vector2 (0, 270)); //270 is for the jumpSpeed
		}
	}
}
