using UnityEngine;
using System.Collections;

public class BulletDestroyer: MonoBehaviour
{
	//Destroy the bullet
	public void DestroyBullet (GameObject bullet)
	{
		float timeLimit = 3;
		Destroy (bullet, timeLimit);
	}
}
