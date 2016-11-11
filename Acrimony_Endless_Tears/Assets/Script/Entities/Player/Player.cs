using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Player: HumanoidSuperClass
{
	public bool _jumpButton;

	private BulletDestroyer _destroyerOfBullet;
	private Rigidbody2D _myBody2D;
	public bool _shootKey;

	// Save the bullet of the player
	public GameObject Bullet;


	// Use this for initialization
	private void Start ()
	{
		//All the necessary information for the player to function properly
		ComponentLibrary ();
		_mySpeed = 5;
	}


	// Update is called once per frame
	private void Update ()
	{
		Movement ();
	}


	//Components
	public void ComponentLibrary ()
	{
		_myBody2D = gameObject.GetComponent<Rigidbody2D> ();
		MyAnimator = gameObject.GetComponent<Animator> ();
	}


	//Player controllers
	public void MaintainController ()
	{
		_jumpButton = Input.GetKeyDown (KeyCode.Space);
		_shootKey = Input.GetKeyDown (KeyCode.Z);
	}


	//Have the player move.
	public void Movement ()
	{
		MaintainController ();
		JumpFunction ();
		Attack ();

		//Get the coordinates of the player.
		_myDirection = Input.GetAxisRaw ("Horizontal");
		var mySpeed = _myDirection * _mySpeed;

		// Movement
		_myBody2D.velocity = new Vector2 (mySpeed, _myBody2D.velocity.y);
		MyAnimator.SetFloat ("Speed", Mathf.Abs (mySpeed));
		Rotate (_myDirection);
	}


	//Rotate the player on the horizontal axis
	private void Rotate (float currentAxis)
	{
		//Rotate to the right.
		if (currentAxis > 0)
		{
			transform.eulerAngles = new Vector2 (0, 0);
		}

		//Rotate the player to th left
		if (currentAxis < 0)
		{
			transform.eulerAngles = new Vector2 (0, 180);
		}
	}


	// Jumping function
	public void JumpFunction ()
	{
		// Jumping
		bool myJumpDir = Input.GetButtonDown ("Jump");

		//Check if button working
		if (myJumpDir)
		{
			print ("Jumping");
		}

		//If working, have the player jump
		float jump = Input.GetAxisRaw ("Vertical") * Time.deltaTime;
		float jumpSpeed = jump * _mySpeed;
		_myBody2D.velocity = new Vector2 (_myBody2D.velocity.x, jumpSpeed);
	}


	// Player attack function
	public void Attack ()
	{
		_shootKey = Input.GetKeyDown(KeyCode.Space);

		// Check if the player press the button.
		if (_shootKey)
		{
			GameObject bulletClone = Instantiate(Bullet, transform.position, Quaternion.identity)
				as GameObject;
			_destroyerOfBullet.DestroyBullet(bulletClone);
		}
	} 
}