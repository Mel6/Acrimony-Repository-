using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform lookAt;
	private Vector3 offset = new Vector3(0, 0, -6.5f); //Can be readjusted later depending on the position of the player

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = lookAt.transform.position + offset;
	}
}
