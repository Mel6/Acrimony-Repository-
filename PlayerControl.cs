using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public int speed;
	public int jumpSpeed;
	public int gravity;

	Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 moveDirection = new Vector2 (Input.GetAxisRaw("Horizontal") * 4, rb2D.velocity.y); //5 is for the speed
		rb2D.velocity = moveDirection;

		if (Input.GetAxisRaw("Horizontal") == 1){
			transform.localScale = new Vector3(1, 1, 1);
		} else if (Input.GetAxisRaw("Horizontal") == -1){
			transform.localScale = new Vector3(-1, 1, 1);
		}

		if (Input.GetKeyDown(KeyCode.Space)){
			rb2D.AddForce (new Vector2 (0, 270)); //270 is for the jumpSpeed
		}
	}
}
