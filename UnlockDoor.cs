using UnityEngine;
using System.Collections;

public class UnlockDoor : MonoBehaviour {

	public GameObject Door;
	public GameObject KeySprite; //You can rename it if you want
	public bool gotKey = false;

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			gameObject.SetActive (false);
			gotKey = true;
		}
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D collision){
		Debug.Log ("collision = " + collision.collider);

		if ((collision.gameObject.name == "Door") & gotKey == false){
			Debug.Log ("Locked. Need Key!"); //This is when the player doesn't have the key on them
		}

		if (collision.gameObject.name == "KeySprite") {
			Debug.Log ("Got The Key");
			Destroy (collision.gameObject);
			gotKey = true;
		}

		if ((collision.gameObject.name == "Door") & gotKey == true){
			Debug.Log ("Unlocked Door!"); //This is when the player has the key
			Destroy (collision.gameObject);
			gotKey = false;
		}
	}
}
