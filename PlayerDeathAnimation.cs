using UnityEngine;
using System.Collections;

public class PlayerDeathAnimation : MonoBehaviour {

	private int hitpoint = 3;

	public Vector3 spawnPosition;
	public Transform playerTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(playerTransform.position.y < 10)
		{
			playerTransform.position = spawnPosition;
			hitpoint--;
			if(hitpoint <= 0){
				Debug.Log ("You Haved Failed!");
			}
		}
	}
}
