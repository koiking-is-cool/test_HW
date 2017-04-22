using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xmin,xmax,zmin,zmax;
}

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;

	public float tilt;
	public float speed;
	public Boundary boundary;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float mhori = Input.GetAxis ("Horizontal");
		float verti = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (mhori,0.0f,verti);
		rb.velocity = movement*speed;
		rb.position = new Vector3 
		(
				Mathf.Clamp(rb.position.x,boundary.xmin,boundary.xmax),
		0.0f,
				Mathf.Clamp(rb.position.z,boundary.zmin,boundary.zmax)
		);
		rb.rotation = Quaternion.Euler (0.0f,0.0f,rb.velocity.x*tilt);
	}
}
