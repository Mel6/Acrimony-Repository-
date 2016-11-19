using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour {

	public bool IsGrabbed;
	RaycastHit2D hit;
	private float distance = 1f;
	public Transform grabobject;
	private float Throwforce = 10;
	public LayerMask Notgrabbed;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.E)) {
			if (!IsGrabbed) {
				Physics2D.queriesStartInColliders = false;
				hit = Physics2D.Raycast (transform.position, Vector2.right * transform.localScale.x, distance);
				if (hit.collider != null && hit.collider.tag == "grab") 
				{
					IsGrabbed = true;
				}
				//GRAB THE ITEM
				//IF AN EMPTY OBJECT IS CREATED AS USED AS A CHILD, MAKE SURE "X" IS 1.7, SO THE PLAYER CAN GRAB THE OBJECT WITHOUT IT SLIDING AWAY

			} else if (!Physics2D.OverlapPoint (grabobject.position, Notgrabbed)) {
				IsGrabbed = false;

				if (hit.collider.gameObject.GetComponent<Rigidbody2D> () != null) {
					hit.collider.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.localScale.x, 1) * Throwforce;
				}
				//THROW THE ITEM
			}
		}

		if (IsGrabbed) {
			hit.collider.gameObject.transform.position = grabobject.position;
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(transform.position,transform.position+Vector3.right*transform.localScale.x *distance);
	}
}
