using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public GameObject projectile;
	public Vector2 velocity;
	bool canShoot = true;
	public Vector2 offset = new Vector2(2f, 0.1f);
	public float cooldown = 1f;
	public float delay;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.S) && canShoot)
		{
			GameObject go = (GameObject) Instantiate (projectile,(Vector2) transform.position + offset * transform.localScale.x, Quaternion.identity);
			go.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocity.x * transform.localScale.x, velocity.y);	//50 is good for velocity.x
		}
		}

		IEnumerator CanShoot()
		{
			canShoot = false;
			yield return new WaitForSeconds (cooldown);
			canShoot = true;
		}
	}