using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour {

	public bool IsGrabbed;
	RaycastHit2D hit;
	public float distance=1f;
	public Transform grabobject;
	public float throwforce;
	public LayerMask Notgrabbed;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.E))
		{
			if(!IsGrabbed)
			{
				Physics2D.queriesStartInColliders=false;
				Debug.Log ("Is there a Collider?");
				hit =	Physics2D.Raycast(transform.position,Vector2.right*transform.localScale.x,distance);
				if(hit.collider!=null && hit.collider.tag=="grab")
				{
					IsGrabbed=true;
				}
					
				//Grab the item
			}else if(!Physics2D.OverlapPoint(grabobject.position,Notgrabbed))

			{
				IsGrabbed=false;
				if(hit.collider.gameObject.GetComponent<Rigidbody2D>()!=null)
				{
					hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity= new Vector2(transform.localScale.x,1)*throwforce;
				}
				//Throw the item
			}
		}

		if (IsGrabbed)
			hit.collider.gameObject.transform.position = grabobject.position;
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(transform.position,transform.position+Vector3.right*transform.localScale.x*distance);
	}
}
